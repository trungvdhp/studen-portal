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
    public class KyLuatSinhVienController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/KyLuatSinhVien/

        //[Authorize(Roles="KyLuatSinhVien.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/KyLuatSinhVien//Read

        //[Authorize(Roles="KyLuatSinhVien.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_kyluatsinhvien = db.STU_KyLuatSinhVien.Include(s => s.STU_HoSoSinhVien);
            return Json(stu_kyluatsinhvien.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/KyLuatSinhVien/Details/5

        //[Authorize(Roles="KyLuatSinhVien.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_KyLuatSinhVien stu_kyluatsinhvien = db.STU_KyLuatSinhVien.Find(id);
            if (stu_kyluatsinhvien == null)
            {
                return HttpNotFound();
            }
            return View(stu_kyluatsinhvien);
        }

        //
        // GET: /Admin/KyLuatSinhVien/Create

        //[Authorize(Roles="KyLuatSinhVien.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv");
            return View();
        }

        //
        // POST: /Admin/KyLuatSinhVien/Create

        [HttpPost]
        //[Authorize(Roles="KyLuatSinhVien.Create")]
        public ActionResult Create(STU_KyLuatSinhVien stu_kyluatsinhvien)
        {
            if (ModelState.IsValid)
            {
                db.STU_KyLuatSinhVien.Add(stu_kyluatsinhvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_kyluatsinhvien.ID_sv);
            return View(stu_kyluatsinhvien);
        }

        //
        // GET: /Admin/KyLuatSinhVien/Edit/5
        //[Authorize(Roles="KyLuatSinhVien.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_KyLuatSinhVien stu_kyluatsinhvien = db.STU_KyLuatSinhVien.Find(id);
            if (stu_kyluatsinhvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_kyluatsinhvien.ID_sv);
            return View(stu_kyluatsinhvien);
        }

        //
        // POST: /Admin/KyLuatSinhVien/Edit/5

        [HttpPost]
        //[Authorize(Roles="KyLuatSinhVien.Edit")]
        public ActionResult Edit(STU_KyLuatSinhVien stu_kyluatsinhvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_kyluatsinhvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_kyluatsinhvien.ID_sv);
            return View(stu_kyluatsinhvien);
        }

        //
        // GET: /Admin/KyLuatSinhVien/Delete/5

        //[Authorize(Roles="KyLuatSinhVien.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_KyLuatSinhVien stu_kyluatsinhvien = db.STU_KyLuatSinhVien.Find(id);
            if (stu_kyluatsinhvien == null)
            {
                return HttpNotFound();
            }
            return View(stu_kyluatsinhvien);
        }

        //
        // POST: /Admin/KyLuatSinhVien/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="KyLuatSinhVien.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_KyLuatSinhVien stu_kyluatsinhvien = db.STU_KyLuatSinhVien.Find(id);
            db.STU_KyLuatSinhVien.Remove(stu_kyluatsinhvien);
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