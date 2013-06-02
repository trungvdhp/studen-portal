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
    public class LopController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/Lop/

        //[Authorize(Roles="Lop.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/Lop//Read

        //[Authorize(Roles="Lop.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_lop = db.STU_Lop.Include(s => s.STU_He).Include(s => s.STU_Khoa).Include(s => s.STU_ChuyenNganh).Include(s => s.STU_DoiTuong).Include(s => s.PLAN_PhongHoc);
            return Json(stu_lop.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/Lop/Details/5

        //[Authorize(Roles="Lop.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_Lop stu_lop = db.STU_Lop.Find(id);
            if (stu_lop == null)
            {
                return HttpNotFound();
            }
            return View(stu_lop);
        }

        //
        // GET: /Admin/Lop/Create

        //[Authorize(Roles="Lop.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he");
            ViewBag.ID_khoa = new SelectList(db.STU_Khoa, "ID_khoa", "Ma_khoa");
            ViewBag.ID_chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Ma_chuyen_nganh");
            ViewBag.ID_dt = new SelectList(db.STU_DoiTuong, "ID_dt", "Ma_dt");
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong");
            return View();
        }

        //
        // POST: /Admin/Lop/Create

        [HttpPost]
        //[Authorize(Roles="Lop.Create")]
        public ActionResult Create(STU_Lop stu_lop)
        {
            if (ModelState.IsValid)
            {
                db.STU_Lop.Add(stu_lop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", stu_lop.ID_he);
            ViewBag.ID_khoa = new SelectList(db.STU_Khoa, "ID_khoa", "Ma_khoa", stu_lop.ID_khoa);
            ViewBag.ID_chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Ma_chuyen_nganh", stu_lop.ID_chuyen_nganh);
            ViewBag.ID_dt = new SelectList(db.STU_DoiTuong, "ID_dt", "Ma_dt", stu_lop.ID_dt);
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong", stu_lop.ID_phong);
            return View(stu_lop);
        }

        //
        // GET: /Admin/Lop/Edit/5
        //[Authorize(Roles="Lop.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_Lop stu_lop = db.STU_Lop.Find(id);
            if (stu_lop == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", stu_lop.ID_he);
            ViewBag.ID_khoa = new SelectList(db.STU_Khoa, "ID_khoa", "Ma_khoa", stu_lop.ID_khoa);
            ViewBag.ID_chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Ma_chuyen_nganh", stu_lop.ID_chuyen_nganh);
            ViewBag.ID_dt = new SelectList(db.STU_DoiTuong, "ID_dt", "Ma_dt", stu_lop.ID_dt);
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong", stu_lop.ID_phong);
            return View(stu_lop);
        }

        //
        // POST: /Admin/Lop/Edit/5

        [HttpPost]
        //[Authorize(Roles="Lop.Edit")]
        public ActionResult Edit(STU_Lop stu_lop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_lop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", stu_lop.ID_he);
            ViewBag.ID_khoa = new SelectList(db.STU_Khoa, "ID_khoa", "Ma_khoa", stu_lop.ID_khoa);
            ViewBag.ID_chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Ma_chuyen_nganh", stu_lop.ID_chuyen_nganh);
            ViewBag.ID_dt = new SelectList(db.STU_DoiTuong, "ID_dt", "Ma_dt", stu_lop.ID_dt);
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong", stu_lop.ID_phong);
            return View(stu_lop);
        }

        //
        // GET: /Admin/Lop/Delete/5

        //[Authorize(Roles="Lop.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_Lop stu_lop = db.STU_Lop.Find(id);
            if (stu_lop == null)
            {
                return HttpNotFound();
            }
            return View(stu_lop);
        }

        //
        // POST: /Admin/Lop/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="Lop.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_Lop stu_lop = db.STU_Lop.Find(id);
            db.STU_Lop.Remove(stu_lop);
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