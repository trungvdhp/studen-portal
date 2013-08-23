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
    public class DoiTuongController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/DoiTuong/

        //[Authorize(Roles="DoiTuong.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DoiTuong//Read

        //[Authorize(Roles="DoiTuong.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_DoiTuong.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DoiTuong/Details/5

        //[Authorize(Roles="DoiTuong.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DoiTuong stu_doituong = db.STU_DoiTuong.Find(id);
            if (stu_doituong == null)
            {
                return HttpNotFound();
            }
            return View(stu_doituong);
        }

        //
        // GET: /Admin/DoiTuong/Create

        //[Authorize(Roles="DoiTuong.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/DoiTuong/Create

        [HttpPost]
        //[Authorize(Roles="DoiTuong.Create")]
        public ActionResult Create(STU_DoiTuong stu_doituong)
        {
            if (ModelState.IsValid)
            {
                db.STU_DoiTuong.Add(stu_doituong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_doituong);
        }

        //
        // GET: /Admin/DoiTuong/Edit/5
        //[Authorize(Roles="DoiTuong.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DoiTuong stu_doituong = db.STU_DoiTuong.Find(id);
            if (stu_doituong == null)
            {
                return HttpNotFound();
            }
            return View(stu_doituong);
        }

        //
        // POST: /Admin/DoiTuong/Edit/5

        [HttpPost]
        //[Authorize(Roles="DoiTuong.Edit")]
        public ActionResult Edit(STU_DoiTuong stu_doituong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_doituong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_doituong);
        }

        //
        // GET: /Admin/DoiTuong/Delete/5

        //[Authorize(Roles="DoiTuong.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DoiTuong stu_doituong = db.STU_DoiTuong.Find(id);
            if (stu_doituong == null)
            {
                return HttpNotFound();
            }
            return View(stu_doituong);
        }

        //
        // POST: /Admin/DoiTuong/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DoiTuong.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DoiTuong stu_doituong = db.STU_DoiTuong.Find(id);
            db.STU_DoiTuong.Remove(stu_doituong);
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