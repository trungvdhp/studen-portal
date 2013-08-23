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
    public class KhenThuongController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/KhenThuong/

        //[Authorize(Roles="KhenThuong.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/KhenThuong//Read

        //[Authorize(Roles="KhenThuong.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_khenthuong = db.STU_KhenThuong.Include(s => s.STU_LoaiKhenThuong).Include(s => s.STU_CapKhenThuongKyLuat);
            return Json(stu_khenthuong.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/KhenThuong/Details/5

        //[Authorize(Roles="KhenThuong.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_KhenThuong stu_khenthuong = db.STU_KhenThuong.Find(id);
            if (stu_khenthuong == null)
            {
                return HttpNotFound();
            }
            return View(stu_khenthuong);
        }

        //
        // GET: /Admin/KhenThuong/Create

        //[Authorize(Roles="KhenThuong.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_loai_kt = new SelectList(db.STU_LoaiKhenThuong, "ID_loai_kt", "Loai_khen_thuong");
            ViewBag.ID_cap = new SelectList(db.STU_CapKhenThuongKyLuat, "ID_cap", "Ten_cap");
            return View();
        }

        //
        // POST: /Admin/KhenThuong/Create

        [HttpPost]
        //[Authorize(Roles="KhenThuong.Create")]
        public ActionResult Create(STU_KhenThuong stu_khenthuong)
        {
            if (ModelState.IsValid)
            {
                db.STU_KhenThuong.Add(stu_khenthuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_loai_kt = new SelectList(db.STU_LoaiKhenThuong, "ID_loai_kt", "Loai_khen_thuong", stu_khenthuong.ID_loai_kt);
            ViewBag.ID_cap = new SelectList(db.STU_CapKhenThuongKyLuat, "ID_cap", "Ten_cap", stu_khenthuong.ID_cap);
            return View(stu_khenthuong);
        }

        //
        // GET: /Admin/KhenThuong/Edit/5
        //[Authorize(Roles="KhenThuong.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_KhenThuong stu_khenthuong = db.STU_KhenThuong.Find(id);
            if (stu_khenthuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_loai_kt = new SelectList(db.STU_LoaiKhenThuong, "ID_loai_kt", "Loai_khen_thuong", stu_khenthuong.ID_loai_kt);
            ViewBag.ID_cap = new SelectList(db.STU_CapKhenThuongKyLuat, "ID_cap", "Ten_cap", stu_khenthuong.ID_cap);
            return View(stu_khenthuong);
        }

        //
        // POST: /Admin/KhenThuong/Edit/5

        [HttpPost]
        //[Authorize(Roles="KhenThuong.Edit")]
        public ActionResult Edit(STU_KhenThuong stu_khenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_khenthuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_loai_kt = new SelectList(db.STU_LoaiKhenThuong, "ID_loai_kt", "Loai_khen_thuong", stu_khenthuong.ID_loai_kt);
            ViewBag.ID_cap = new SelectList(db.STU_CapKhenThuongKyLuat, "ID_cap", "Ten_cap", stu_khenthuong.ID_cap);
            return View(stu_khenthuong);
        }

        //
        // GET: /Admin/KhenThuong/Delete/5

        //[Authorize(Roles="KhenThuong.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_KhenThuong stu_khenthuong = db.STU_KhenThuong.Find(id);
            if (stu_khenthuong == null)
            {
                return HttpNotFound();
            }
            return View(stu_khenthuong);
        }

        //
        // POST: /Admin/KhenThuong/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="KhenThuong.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_KhenThuong stu_khenthuong = db.STU_KhenThuong.Find(id);
            db.STU_KhenThuong.Remove(stu_khenthuong);
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