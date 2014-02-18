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
    public class QuyDinhDangKyController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/QuyDinhDangKy/

        //[Authorize(Roles="QuyDinhDangKy.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/QuyDinhDangKy//Read

        //[Authorize(Roles="QuyDinhDangKy.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var plan_quydinh_dangky = db.PLAN_QUYDINH_DANGKY.Include(p => p.STU_He).Include(p => p.STU_ChuyenNganh).Include(p => p.PLAN_HocKyDangKy_TC);
            return Json(plan_quydinh_dangky.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/QuyDinhDangKy/Details/5

        //[Authorize(Roles="QuyDinhDangKy.Details")]
        public ActionResult Details(int id = 0)
        {
            PLAN_QUYDINH_DANGKY plan_quydinh_dangky = db.PLAN_QUYDINH_DANGKY.Find(id);
            if (plan_quydinh_dangky == null)
            {
                return HttpNotFound();
            }
            return View(plan_quydinh_dangky);
        }

        //
        // GET: /Admin/QuyDinhDangKy/Create

        //[Authorize(Roles="QuyDinhDangKy.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ten_he");
            ViewBag.ID_Chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Chuyen_nganh");
            ViewBag.Ky_dang_ky = new SelectList(db.PLAN_HocKyDangKy_TC.ToList().Select(t => new ViewModels.KyDangKy { 
                Ky_dang_ky = t.Ky_dang_ky,
                Ten_ky = String.Format("{0}_{1}_{2}",t.Nam_hoc,t.Hoc_ky,t.Dot)
            }).ToList(), "Ky_dang_ky", "Ten_ky");
            return View();
        }

        //
        // POST: /Admin/QuyDinhDangKy/Create

        [HttpPost]
        //[Authorize(Roles="QuyDinhDangKy.Create")]
        public ActionResult Create(PLAN_QUYDINH_DANGKY plan_quydinh_dangky)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_QUYDINH_DANGKY.Add(plan_quydinh_dangky);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", plan_quydinh_dangky.ID_he);
            ViewBag.ID_Chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Chuyen_nganh", plan_quydinh_dangky.ID_Chuyen_nganh);
            ViewBag.Ky_dang_ky = new SelectList(db.PLAN_HocKyDangKy_TC.ToList().Select(t => new ViewModels.KyDangKy
            {
                Ky_dang_ky = t.Ky_dang_ky,
                Ten_ky = String.Format("{0}_{1}_{2}", t.Nam_hoc, t.Hoc_ky, t.Dot)
            }).ToList(), "Ky_dang_ky", "Ten_ky");
            return View(plan_quydinh_dangky);
        }

        //
        // GET: /Admin/QuyDinhDangKy/Edit/5
        //[Authorize(Roles="QuyDinhDangKy.Edit")]
        public ActionResult Edit(int id = 0)
        {
            PLAN_QUYDINH_DANGKY plan_quydinh_dangky = db.PLAN_QUYDINH_DANGKY.Find(id);
            if (plan_quydinh_dangky == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", plan_quydinh_dangky.ID_he);
            ViewBag.ID_Chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Chuyen_nganh", plan_quydinh_dangky.ID_Chuyen_nganh);
            ViewBag.Ky_dang_ky = new SelectList(db.PLAN_HocKyDangKy_TC.ToList().Select(t => new ViewModels.KyDangKy
            {
                Ky_dang_ky = t.Ky_dang_ky,
                Ten_ky = String.Format("{0}_{1}_{2}", t.Nam_hoc, t.Hoc_ky, t.Dot)
            }).ToList(), "Ky_dang_ky", "Ten_ky");
            return View(plan_quydinh_dangky);
        }

        //
        // POST: /Admin/QuyDinhDangKy/Edit/5

        [HttpPost]
        //[Authorize(Roles="QuyDinhDangKy.Edit")]
        public ActionResult Edit(PLAN_QUYDINH_DANGKY plan_quydinh_dangky)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_quydinh_dangky).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", plan_quydinh_dangky.ID_he);
            ViewBag.ID_Chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Ma_chuyen_nganh", plan_quydinh_dangky.ID_Chuyen_nganh);
            ViewBag.Ky_dang_ky = new SelectList(db.PLAN_HocKyDangKy_TC, "Ky_dang_ky", "Nam_hoc", plan_quydinh_dangky.Ky_dang_ky);
            return View(plan_quydinh_dangky);
        }

        //
        // GET: /Admin/QuyDinhDangKy/Delete/5

        //[Authorize(Roles="QuyDinhDangKy.Delete")]
        public ActionResult Delete(int id = 0)
        {
            PLAN_QUYDINH_DANGKY plan_quydinh_dangky = db.PLAN_QUYDINH_DANGKY.Find(id);
            if (plan_quydinh_dangky == null)
            {
                return HttpNotFound();
            }
            return View(plan_quydinh_dangky);
        }

        //
        // POST: /Admin/QuyDinhDangKy/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="QuyDinhDangKy.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAN_QUYDINH_DANGKY plan_quydinh_dangky = db.PLAN_QUYDINH_DANGKY.Find(id);
            db.PLAN_QUYDINH_DANGKY.Remove(plan_quydinh_dangky);
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