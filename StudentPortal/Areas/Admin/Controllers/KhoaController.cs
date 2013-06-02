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
    public class KhoaController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/Khoa/

        //[Authorize(Roles="Khoa.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/Khoa//Read

        //[Authorize(Roles="Khoa.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_Khoa.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/Khoa/Details/5

        //[Authorize(Roles="Khoa.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_Khoa stu_khoa = db.STU_Khoa.Find(id);
            if (stu_khoa == null)
            {
                return HttpNotFound();
            }
            return View(stu_khoa);
        }

        //
        // GET: /Admin/Khoa/Create

        //[Authorize(Roles="Khoa.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Khoa/Create

        [HttpPost]
        //[Authorize(Roles="Khoa.Create")]
        public ActionResult Create(STU_Khoa stu_khoa)
        {
            if (ModelState.IsValid)
            {
                db.STU_Khoa.Add(stu_khoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_khoa);
        }

        //
        // GET: /Admin/Khoa/Edit/5
        //[Authorize(Roles="Khoa.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_Khoa stu_khoa = db.STU_Khoa.Find(id);
            if (stu_khoa == null)
            {
                return HttpNotFound();
            }
            return View(stu_khoa);
        }

        //
        // POST: /Admin/Khoa/Edit/5

        [HttpPost]
        //[Authorize(Roles="Khoa.Edit")]
        public ActionResult Edit(STU_Khoa stu_khoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_khoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_khoa);
        }

        //
        // GET: /Admin/Khoa/Delete/5

        //[Authorize(Roles="Khoa.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_Khoa stu_khoa = db.STU_Khoa.Find(id);
            if (stu_khoa == null)
            {
                return HttpNotFound();
            }
            return View(stu_khoa);
        }

        //
        // POST: /Admin/Khoa/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="Khoa.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_Khoa stu_khoa = db.STU_Khoa.Find(id);
            db.STU_Khoa.Remove(stu_khoa);
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