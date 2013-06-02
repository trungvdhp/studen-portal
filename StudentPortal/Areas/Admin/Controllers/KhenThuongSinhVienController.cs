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
    public class KhenThuongSinhVienController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/KhenThuongSinhVien/

        //[Authorize(Roles="KhenThuongSinhVien.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/KhenThuongSinhVien//Read

        //[Authorize(Roles="KhenThuongSinhVien.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_khenthuongsinhvien = db.STU_KhenThuongSinhVien.Include(s => s.STU_HoSoSinhVien);
            return Json(stu_khenthuongsinhvien.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/KhenThuongSinhVien/Details/5

        //[Authorize(Roles="KhenThuongSinhVien.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_KhenThuongSinhVien stu_khenthuongsinhvien = db.STU_KhenThuongSinhVien.Find(id);
            if (stu_khenthuongsinhvien == null)
            {
                return HttpNotFound();
            }
            return View(stu_khenthuongsinhvien);
        }

        //
        // GET: /Admin/KhenThuongSinhVien/Create

        //[Authorize(Roles="KhenThuongSinhVien.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv");
            return View();
        }

        //
        // POST: /Admin/KhenThuongSinhVien/Create

        [HttpPost]
        //[Authorize(Roles="KhenThuongSinhVien.Create")]
        public ActionResult Create(STU_KhenThuongSinhVien stu_khenthuongsinhvien)
        {
            if (ModelState.IsValid)
            {
                db.STU_KhenThuongSinhVien.Add(stu_khenthuongsinhvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_khenthuongsinhvien.ID_sv);
            return View(stu_khenthuongsinhvien);
        }

        //
        // GET: /Admin/KhenThuongSinhVien/Edit/5
        //[Authorize(Roles="KhenThuongSinhVien.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_KhenThuongSinhVien stu_khenthuongsinhvien = db.STU_KhenThuongSinhVien.Find(id);
            if (stu_khenthuongsinhvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_khenthuongsinhvien.ID_sv);
            return View(stu_khenthuongsinhvien);
        }

        //
        // POST: /Admin/KhenThuongSinhVien/Edit/5

        [HttpPost]
        //[Authorize(Roles="KhenThuongSinhVien.Edit")]
        public ActionResult Edit(STU_KhenThuongSinhVien stu_khenthuongsinhvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_khenthuongsinhvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_khenthuongsinhvien.ID_sv);
            return View(stu_khenthuongsinhvien);
        }

        //
        // GET: /Admin/KhenThuongSinhVien/Delete/5

        //[Authorize(Roles="KhenThuongSinhVien.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_KhenThuongSinhVien stu_khenthuongsinhvien = db.STU_KhenThuongSinhVien.Find(id);
            if (stu_khenthuongsinhvien == null)
            {
                return HttpNotFound();
            }
            return View(stu_khenthuongsinhvien);
        }

        //
        // POST: /Admin/KhenThuongSinhVien/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="KhenThuongSinhVien.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_KhenThuongSinhVien stu_khenthuongsinhvien = db.STU_KhenThuongSinhVien.Find(id);
            db.STU_KhenThuongSinhVien.Remove(stu_khenthuongsinhvien);
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