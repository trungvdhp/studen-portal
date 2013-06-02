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
    public class NhomDoiTuongController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/NhomDoiTuong/

        //[Authorize(Roles="NhomDoiTuong.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/NhomDoiTuong//Read

        //[Authorize(Roles="NhomDoiTuong.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_NhomDoiTuong.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/NhomDoiTuong/Details/5

        //[Authorize(Roles="NhomDoiTuong.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_NhomDoiTuong stu_nhomdoituong = db.STU_NhomDoiTuong.Find(id);
            if (stu_nhomdoituong == null)
            {
                return HttpNotFound();
            }
            return View(stu_nhomdoituong);
        }

        //
        // GET: /Admin/NhomDoiTuong/Create

        //[Authorize(Roles="NhomDoiTuong.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/NhomDoiTuong/Create

        [HttpPost]
        //[Authorize(Roles="NhomDoiTuong.Create")]
        public ActionResult Create(STU_NhomDoiTuong stu_nhomdoituong)
        {
            if (ModelState.IsValid)
            {
                db.STU_NhomDoiTuong.Add(stu_nhomdoituong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_nhomdoituong);
        }

        //
        // GET: /Admin/NhomDoiTuong/Edit/5
        //[Authorize(Roles="NhomDoiTuong.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_NhomDoiTuong stu_nhomdoituong = db.STU_NhomDoiTuong.Find(id);
            if (stu_nhomdoituong == null)
            {
                return HttpNotFound();
            }
            return View(stu_nhomdoituong);
        }

        //
        // POST: /Admin/NhomDoiTuong/Edit/5

        [HttpPost]
        //[Authorize(Roles="NhomDoiTuong.Edit")]
        public ActionResult Edit(STU_NhomDoiTuong stu_nhomdoituong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_nhomdoituong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_nhomdoituong);
        }

        //
        // GET: /Admin/NhomDoiTuong/Delete/5

        //[Authorize(Roles="NhomDoiTuong.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_NhomDoiTuong stu_nhomdoituong = db.STU_NhomDoiTuong.Find(id);
            if (stu_nhomdoituong == null)
            {
                return HttpNotFound();
            }
            return View(stu_nhomdoituong);
        }

        //
        // POST: /Admin/NhomDoiTuong/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="NhomDoiTuong.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_NhomDoiTuong stu_nhomdoituong = db.STU_NhomDoiTuong.Find(id);
            db.STU_NhomDoiTuong.Remove(stu_nhomdoituong);
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