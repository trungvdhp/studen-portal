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
    public class DanhSachLopTinChiController : BasicController
    {
        private DHHH db = new DHHH();

        //
        // GET: /Admin/DanhSachLopTinChi/

        //[Authorize(Roles="DanhSachLopTinChi.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DanhSachLopTinChi//Read

        //[Authorize(Roles="DanhSachLopTinChi.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_danhsachloptinchi = db.STU_DanhSachLopTinChi.Include(s => s.PLAN_LopTinChi_TC).Include(s => s.STU_HoSoSinhVien);
            return Json(stu_danhsachloptinchi.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DanhSachLopTinChi/Details/5

        //[Authorize(Roles="DanhSachLopTinChi.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DanhSachLopTinChi stu_danhsachloptinchi = db.STU_DanhSachLopTinChi.Find(id);
            if (stu_danhsachloptinchi == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachloptinchi);
        }

        //
        // GET: /Admin/DanhSachLopTinChi/Create

        //[Authorize(Roles="DanhSachLopTinChi.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_lop_tc = new SelectList(db.PLAN_LopTinChi_TC, "ID_lop_tc", "Ly_do");
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv");
            return View();
        }

        //
        // POST: /Admin/DanhSachLopTinChi/Create

        [HttpPost]
        //[Authorize(Roles="DanhSachLopTinChi.Create")]
        public ActionResult Create(STU_DanhSachLopTinChi stu_danhsachloptinchi)
        {
            if (ModelState.IsValid)
            {
                db.STU_DanhSachLopTinChi.Add(stu_danhsachloptinchi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_lop_tc = new SelectList(db.PLAN_LopTinChi_TC, "ID_lop_tc", "Ly_do", stu_danhsachloptinchi.ID_lop_tc);
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_danhsachloptinchi.ID_sv);
            return View(stu_danhsachloptinchi);
        }

        //
        // GET: /Admin/DanhSachLopTinChi/Edit/5
        //[Authorize(Roles="DanhSachLopTinChi.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DanhSachLopTinChi stu_danhsachloptinchi = db.STU_DanhSachLopTinChi.Find(id);
            if (stu_danhsachloptinchi == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_lop_tc = new SelectList(db.PLAN_LopTinChi_TC, "ID_lop_tc", "Ly_do", stu_danhsachloptinchi.ID_lop_tc);
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_danhsachloptinchi.ID_sv);
            return View(stu_danhsachloptinchi);
        }

        //
        // POST: /Admin/DanhSachLopTinChi/Edit/5

        [HttpPost]
        //[Authorize(Roles="DanhSachLopTinChi.Edit")]
        public ActionResult Edit(STU_DanhSachLopTinChi stu_danhsachloptinchi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_danhsachloptinchi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_lop_tc = new SelectList(db.PLAN_LopTinChi_TC, "ID_lop_tc", "Ly_do", stu_danhsachloptinchi.ID_lop_tc);
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_danhsachloptinchi.ID_sv);
            return View(stu_danhsachloptinchi);
        }

        //
        // GET: /Admin/DanhSachLopTinChi/Delete/5

        //[Authorize(Roles="DanhSachLopTinChi.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DanhSachLopTinChi stu_danhsachloptinchi = db.STU_DanhSachLopTinChi.Find(id);
            if (stu_danhsachloptinchi == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachloptinchi);
        }

        //
        // POST: /Admin/DanhSachLopTinChi/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DanhSachLopTinChi.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DanhSachLopTinChi stu_danhsachloptinchi = db.STU_DanhSachLopTinChi.Find(id);
            db.STU_DanhSachLopTinChi.Remove(stu_danhsachloptinchi);
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