using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


namespace StudentPortal.Areas.Admin.Controllers
{
    public class NganhController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/Nganh/

        //[Authorize(Roles="Nganh.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/Nganh//Read

        //[Authorize(Roles="Nganh.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_Nganh.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/Nganh/Details/5

        //[Authorize(Roles="Nganh.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_Nganh stu_nganh = db.STU_Nganh.Find(id);
            if (stu_nganh == null)
            {
                return HttpNotFound();
            }
            return View(stu_nganh);
        }

        //
        // GET: /Admin/Nganh/Create

        //[Authorize(Roles="Nganh.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Nganh/Create

        [HttpPost]
        //[Authorize(Roles="Nganh.Create")]
        public ActionResult Create(STU_Nganh stu_nganh)
        {
            if (ModelState.IsValid)
            {
                db.STU_Nganh.Add(stu_nganh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_nganh);
        }

        //
        // GET: /Admin/Nganh/Edit/5
        //[Authorize(Roles="Nganh.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_Nganh stu_nganh = db.STU_Nganh.Find(id);
            if (stu_nganh == null)
            {
                return HttpNotFound();
            }
            return View(stu_nganh);
        }

        //
        // POST: /Admin/Nganh/Edit/5

        [HttpPost]
        //[Authorize(Roles="Nganh.Edit")]
        public ActionResult Edit(STU_Nganh stu_nganh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_nganh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_nganh);
        }

        //
        // GET: /Admin/Nganh/Delete/5

        //[Authorize(Roles="Nganh.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_Nganh stu_nganh = db.STU_Nganh.Find(id);
            if (stu_nganh == null)
            {
                return HttpNotFound();
            }
            return View(stu_nganh);
        }

        //
        // POST: /Admin/Nganh/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="Nganh.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_Nganh stu_nganh = db.STU_Nganh.Find(id);
            db.STU_Nganh.Remove(stu_nganh);
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