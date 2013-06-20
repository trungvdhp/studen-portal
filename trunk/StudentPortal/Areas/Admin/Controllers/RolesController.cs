using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using StudentPortal.Lib;
using StudentPortal.Models;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class RolesController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/Roles/

        //[Authorize(Roles="Roles.Index")]
        public ActionResult Index()
        {
			return View();
        }


		public ActionResult Update()
		{
			var roles = GlobalLib.GetControllerActionMethods();
			int i = 0;
			foreach (var r in roles)
			{
				if (db.webpages_Roles.Count(t => t.RoleName == r.RoleName) < 1)
				{
					i++;
					db.webpages_Roles.Add(r);
				}
			}

			return new JsonResult()
			{
				Data = new AjaxResult()
				{
					Title = "Thông báo",
					Message = String.Format("Update {0} action method!",i),
					Status = AjaxStatus.SUCCESS
				}
			};
		}
		//
        // GET: /Admin/Roles//Read

        //[Authorize(Roles="Roles.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.webpages_Roles.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/Roles/Details/5

        //[Authorize(Roles="Roles.Details")]
        public ActionResult Details(int id = 0)
        {
            webpages_Roles webpages_roles = db.webpages_Roles.Find(id);
            if (webpages_roles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_roles);
        }

        //
        // GET: /Admin/Roles/Create

        //[Authorize(Roles="Roles.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Roles/Create

        [HttpPost]
        //[Authorize(Roles="Roles.Create")]
        public ActionResult Create(webpages_Roles webpages_roles)
        {
            if (ModelState.IsValid)
            {
                db.webpages_Roles.Add(webpages_roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webpages_roles);
        }

        //
        // GET: /Admin/Roles/Edit/5
        //[Authorize(Roles="Roles.Edit")]
        public ActionResult Edit(int id = 0)
        {
            webpages_Roles webpages_roles = db.webpages_Roles.Find(id);
            if (webpages_roles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_roles);
        }

        //
        // POST: /Admin/Roles/Edit/5

        [HttpPost]
        //[Authorize(Roles="Roles.Edit")]
        public ActionResult Edit(webpages_Roles webpages_roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webpages_roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webpages_roles);
        }

        //
        // GET: /Admin/Roles/Delete/5

        //[Authorize(Roles="Roles.Delete")]
        public ActionResult Delete(int id = 0)
        {
            webpages_Roles webpages_roles = db.webpages_Roles.Find(id);
            if (webpages_roles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_roles);
        }

        //
        // POST: /Admin/Roles/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="Roles.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            webpages_Roles webpages_roles = db.webpages_Roles.Find(id);
            db.webpages_Roles.Remove(webpages_roles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}