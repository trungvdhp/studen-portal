using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using StudentPortal.Models;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class GroupController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/Group/

        //[Authorize(Roles="Group.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/Group//Read

        //[Authorize(Roles="Group.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.webpages_Group.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/Group/Details/5

        //[Authorize(Roles="Group.Details")]
        public ActionResult Details(int id = 0)
        {
            webpages_Group webpages_group = db.webpages_Group.Find(id);
            if (webpages_group == null)
            {
                return HttpNotFound();
            }
            return View(webpages_group);
        }

        //
        // GET: /Admin/Group/Create

        //[Authorize(Roles="Group.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Group/Create

        [HttpPost]
        //[Authorize(Roles="Group.Create")]
        public ActionResult Create(webpages_Group webpages_group)
        {
            if (ModelState.IsValid)
            {
                db.webpages_Group.Add(webpages_group);
				db.SaveChanges();
				var buf = Request.Form["RoleIds"];
				if (buf != null)
				{
					var RoleIds = buf.Split(new string[] { "," }, StringSplitOptions.None);

					foreach (var roleId in RoleIds)
					{
						db.webpages_Groups_Roles.Add(new webpages_Groups_Roles
						{
							GroupId = webpages_group.GroupId,
							RoleId = Convert.ToInt32(roleId)
						});
					};
				}
				db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webpages_group);
        }

        //
        // GET: /Admin/Group/Edit/5
        //[Authorize(Roles="Group.Edit")]
        public ActionResult Edit(int id = 0)
        {
            webpages_Group webpages_group = db.webpages_Group.Find(id);
            if (webpages_group == null)
            {
                return HttpNotFound();
            }
			var roleIds = db.webpages_Groups_Roles.Where(t => t.GroupId == id).Select(t => new
			{
				t.RoleId
			}).ToList();
			var selectedVals = new List<int>();
			foreach (var r in roleIds) selectedVals.Add(r.RoleId);
			ViewBag.selectedVals = selectedVals;
            return View(webpages_group);
        }

        //
        // POST: /Admin/Group/Edit/5

        [HttpPost]
        //[Authorize(Roles="Group.Edit")]
        public ActionResult Edit(webpages_Group webpages_group)
        {
            if (ModelState.IsValid)
            {
				var buf = Request.Form["RoleIds"];
				if (buf != null)
				{
					var RoleIds = buf.Split(new string[] { "," }, StringSplitOptions.None);
					var oldRole = db.webpages_Groups_Roles.Where(t => t.GroupId == webpages_group.GroupId).ToList();
					foreach (var r in oldRole) db.webpages_Groups_Roles.Remove(r);

					foreach (var roleId in RoleIds)
					{
						db.webpages_Groups_Roles.Add(new webpages_Groups_Roles
						{
							GroupId = webpages_group.GroupId,
							RoleId = Convert.ToInt32(roleId)
						});
					};
				}
                db.Entry(webpages_group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webpages_group);
        }

        //
        // GET: /Admin/Group/Delete/5

        //[Authorize(Roles="Group.Delete")]
        public ActionResult Delete(int id = 0)
        {
            webpages_Group webpages_group = db.webpages_Group.Find(id);
            if (webpages_group == null)
            {
                return HttpNotFound();
            }
            return View(webpages_group);
        }

        //
        // POST: /Admin/Group/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[Authorize(Roles="Group.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            webpages_Group webpages_group = db.webpages_Group.Find(id);
            db.webpages_Group.Remove(webpages_group);
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