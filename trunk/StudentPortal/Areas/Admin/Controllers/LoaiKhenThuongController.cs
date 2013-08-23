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
    public class LoaiKhenThuongController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/LoaiKhenThuong/

        //[Authorize(Roles="LoaiKhenThuong.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/LoaiKhenThuong//Read

        //[Authorize(Roles="LoaiKhenThuong.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_loaikhenthuong = db.STU_LoaiKhenThuong.Include(s => s.STU_CapKhenThuongKyLuat);
            return Json(stu_loaikhenthuong.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/LoaiKhenThuong/Details/5

        //[Authorize(Roles="LoaiKhenThuong.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_LoaiKhenThuong stu_loaikhenthuong = db.STU_LoaiKhenThuong.Find(id);
            if (stu_loaikhenthuong == null)
            {
                return HttpNotFound();
            }
            return View(stu_loaikhenthuong);
        }

        //
        // GET: /Admin/LoaiKhenThuong/Create

        //[Authorize(Roles="LoaiKhenThuong.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_cap = new SelectList(db.STU_CapKhenThuongKyLuat, "ID_cap", "Ten_cap");
            return View();
        }

        //
        // POST: /Admin/LoaiKhenThuong/Create

        [HttpPost]
        //[Authorize(Roles="LoaiKhenThuong.Create")]
        public ActionResult Create(STU_LoaiKhenThuong stu_loaikhenthuong)
        {
            if (ModelState.IsValid)
            {
                db.STU_LoaiKhenThuong.Add(stu_loaikhenthuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_cap = new SelectList(db.STU_CapKhenThuongKyLuat, "ID_cap", "Ten_cap", stu_loaikhenthuong.ID_cap);
            return View(stu_loaikhenthuong);
        }

        //
        // GET: /Admin/LoaiKhenThuong/Edit/5
        //[Authorize(Roles="LoaiKhenThuong.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_LoaiKhenThuong stu_loaikhenthuong = db.STU_LoaiKhenThuong.Find(id);
            if (stu_loaikhenthuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_cap = new SelectList(db.STU_CapKhenThuongKyLuat, "ID_cap", "Ten_cap", stu_loaikhenthuong.ID_cap);
            return View(stu_loaikhenthuong);
        }

        //
        // POST: /Admin/LoaiKhenThuong/Edit/5

        [HttpPost]
        //[Authorize(Roles="LoaiKhenThuong.Edit")]
        public ActionResult Edit(STU_LoaiKhenThuong stu_loaikhenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_loaikhenthuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_cap = new SelectList(db.STU_CapKhenThuongKyLuat, "ID_cap", "Ten_cap", stu_loaikhenthuong.ID_cap);
            return View(stu_loaikhenthuong);
        }

        //
        // GET: /Admin/LoaiKhenThuong/Delete/5

        //[Authorize(Roles="LoaiKhenThuong.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_LoaiKhenThuong stu_loaikhenthuong = db.STU_LoaiKhenThuong.Find(id);
            if (stu_loaikhenthuong == null)
            {
                return HttpNotFound();
            }
            return View(stu_loaikhenthuong);
        }

        //
        // POST: /Admin/LoaiKhenThuong/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="LoaiKhenThuong.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_LoaiKhenThuong stu_loaikhenthuong = db.STU_LoaiKhenThuong.Find(id);
            db.STU_LoaiKhenThuong.Remove(stu_loaikhenthuong);
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