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
    public class LopTinChiController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/LopTinChi/

        //[Authorize(Roles="LopTinChi.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/LopTinChi//Read

        //[Authorize(Roles="LopTinChi.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Include(p => p.PLAN_MonTinChi_TC).Include(p => p.PLAN_PhongHoc).Include(p => p.PLAN_GiaoVien);
            return Json(plan_loptinchi_tc.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/LopTinChi/Details/5

        //[Authorize(Roles="LopTinChi.Details")]
        public ActionResult Details(int id = 0)
        {
            PLAN_LopTinChi_TC plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Find(id);
            if (plan_loptinchi_tc == null)
            {
                return HttpNotFound();
            }
            return View(plan_loptinchi_tc);
        }

        //
        // GET: /Admin/LopTinChi/Create

        //[Authorize(Roles="LopTinChi.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc");
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong");
            ViewBag.ID_cb = new SelectList(db.PLAN_GiaoVien, "ID_cb", "Ma_cb");
            return View();
        }

        //
        // POST: /Admin/LopTinChi/Create

        [HttpPost]
        //[Authorize(Roles="LopTinChi.Create")]
        public ActionResult Create(PLAN_LopTinChi_TC plan_loptinchi_tc)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_LopTinChi_TC.Add(plan_loptinchi_tc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc", plan_loptinchi_tc.ID_mon_tc);
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong", plan_loptinchi_tc.ID_phong);
            ViewBag.ID_cb = new SelectList(db.PLAN_GiaoVien, "ID_cb", "Ma_cb", plan_loptinchi_tc.ID_cb);
            return View(plan_loptinchi_tc);
        }

        //
        // GET: /Admin/LopTinChi/Edit/5
        //[Authorize(Roles="LopTinChi.Edit")]
        public ActionResult Edit(int id = 0)
        {
            PLAN_LopTinChi_TC plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Find(id);
            if (plan_loptinchi_tc == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc", plan_loptinchi_tc.ID_mon_tc);
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong", plan_loptinchi_tc.ID_phong);
            ViewBag.ID_cb = new SelectList(db.PLAN_GiaoVien, "ID_cb", "Ma_cb", plan_loptinchi_tc.ID_cb);
            return View(plan_loptinchi_tc);
        }

        //
        // POST: /Admin/LopTinChi/Edit/5

        [HttpPost]
        //[Authorize(Roles="LopTinChi.Edit")]
        public ActionResult Edit(PLAN_LopTinChi_TC plan_loptinchi_tc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_loptinchi_tc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc", plan_loptinchi_tc.ID_mon_tc);
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong", plan_loptinchi_tc.ID_phong);
            ViewBag.ID_cb = new SelectList(db.PLAN_GiaoVien, "ID_cb", "Ma_cb", plan_loptinchi_tc.ID_cb);
            return View(plan_loptinchi_tc);
        }

        //
        // GET: /Admin/LopTinChi/Delete/5

        //[Authorize(Roles="LopTinChi.Delete")]
        public ActionResult Delete(int id = 0)
        {
            PLAN_LopTinChi_TC plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Find(id);
            if (plan_loptinchi_tc == null)
            {
                return HttpNotFound();
            }
            return View(plan_loptinchi_tc);
        }

        //
        // POST: /Admin/LopTinChi/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="LopTinChi.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAN_LopTinChi_TC plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Find(id);
            db.PLAN_LopTinChi_TC.Remove(plan_loptinchi_tc);
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