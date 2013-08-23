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
    public class DoiTuongHocBongController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/DoiTuongHocBong/

        //[Authorize(Roles="DoiTuongHocBong.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DoiTuongHocBong//Read

        //[Authorize(Roles="DoiTuongHocBong.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_DoiTuongHocBong.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DoiTuongHocBong/Details/5

        //[Authorize(Roles="DoiTuongHocBong.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DoiTuongHocBong stu_doituonghocbong = db.STU_DoiTuongHocBong.Find(id);
            if (stu_doituonghocbong == null)
            {
                return HttpNotFound();
            }
            return View(stu_doituonghocbong);
        }

        //
        // GET: /Admin/DoiTuongHocBong/Create

        //[Authorize(Roles="DoiTuongHocBong.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/DoiTuongHocBong/Create

        [HttpPost]
        //[Authorize(Roles="DoiTuongHocBong.Create")]
        public ActionResult Create(STU_DoiTuongHocBong stu_doituonghocbong)
        {
            if (ModelState.IsValid)
            {
                db.STU_DoiTuongHocBong.Add(stu_doituonghocbong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_doituonghocbong);
        }

        //
        // GET: /Admin/DoiTuongHocBong/Edit/5
        //[Authorize(Roles="DoiTuongHocBong.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DoiTuongHocBong stu_doituonghocbong = db.STU_DoiTuongHocBong.Find(id);
            if (stu_doituonghocbong == null)
            {
                return HttpNotFound();
            }
            return View(stu_doituonghocbong);
        }

        //
        // POST: /Admin/DoiTuongHocBong/Edit/5

        [HttpPost]
        //[Authorize(Roles="DoiTuongHocBong.Edit")]
        public ActionResult Edit(STU_DoiTuongHocBong stu_doituonghocbong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_doituonghocbong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_doituonghocbong);
        }

        //
        // GET: /Admin/DoiTuongHocBong/Delete/5

        //[Authorize(Roles="DoiTuongHocBong.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DoiTuongHocBong stu_doituonghocbong = db.STU_DoiTuongHocBong.Find(id);
            if (stu_doituonghocbong == null)
            {
                return HttpNotFound();
            }
            return View(stu_doituonghocbong);
        }

        //
        // POST: /Admin/DoiTuongHocBong/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DoiTuongHocBong.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DoiTuongHocBong stu_doituonghocbong = db.STU_DoiTuongHocBong.Find(id);
            db.STU_DoiTuongHocBong.Remove(stu_doituonghocbong);
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