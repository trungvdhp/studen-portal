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
    public class MonHocController : Controller
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/MonHoc/

        public ActionResult Index()
        {
			//var mark_monhoc = db.MARK_MonHoc.Include(m => m.PLAN_BoMon).Include(m => m.STU_He);
			//return View(mark_monhoc.ToList());
			return View();
        }

		public ActionResult Read([DataSourceRequest] DataSourceRequest request)
		{
			var mark_monhoc = db.MARK_MonHoc.Include(m => m.PLAN_BoMon).Include(m => m.STU_He);
			return Json(mark_monhoc.ToDataSourceResult(request));
		}

        //
        // GET: /Admin/MonHoc/Details/5

        public ActionResult Details(int id = 0)
        {
            MARK_MonHoc mark_monhoc = db.MARK_MonHoc.Find(id);
            if (mark_monhoc == null)
            {
                return HttpNotFound();
            }
            return View(mark_monhoc);
        }

        //
        // GET: /Admin/MonHoc/Create

        public ActionResult Create()
        {
            ViewBag.ID_bm = new SelectList(db.PLAN_BoMon, "ID_bm", "Bo_mon");
            ViewBag.ID_he_dt = new SelectList(db.STU_He, "ID_he", "Ten_he");
            return View();
        }

        //
        // POST: /Admin/MonHoc/Create

        [HttpPost]
        public ActionResult Create(MARK_MonHoc mark_monhoc)
        {
            if (ModelState.IsValid)
            {
                db.MARK_MonHoc.Add(mark_monhoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_bm = new SelectList(db.PLAN_BoMon, "ID_bm", "Ma_bo_mon", mark_monhoc.ID_bm);
            ViewBag.ID_he_dt = new SelectList(db.STU_He, "ID_he", "Ma_he", mark_monhoc.ID_he_dt);
            return View(mark_monhoc);
        }

        //
        // GET: /Admin/MonHoc/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MARK_MonHoc mark_monhoc = db.MARK_MonHoc.Find(id);
            if (mark_monhoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_bm = new SelectList(db.PLAN_BoMon, "ID_bm", "Ma_bo_mon", mark_monhoc.ID_bm);
            ViewBag.ID_he_dt = new SelectList(db.STU_He, "ID_he", "Ma_he", mark_monhoc.ID_he_dt);
            return View(mark_monhoc);
        }

        //
        // POST: /Admin/MonHoc/Edit/5

        [HttpPost]
        public ActionResult Edit(MARK_MonHoc mark_monhoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mark_monhoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_bm = new SelectList(db.PLAN_BoMon, "ID_bm", "Ma_bo_mon", mark_monhoc.ID_bm);
            ViewBag.ID_he_dt = new SelectList(db.STU_He, "ID_he", "Ma_he", mark_monhoc.ID_he_dt);
            return View(mark_monhoc);
        }

        //
        // GET: /Admin/MonHoc/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MARK_MonHoc mark_monhoc = db.MARK_MonHoc.Find(id);
            if (mark_monhoc == null)
            {
                return HttpNotFound();
            }
            return View(mark_monhoc);
        }

        //
        // POST: /Admin/MonHoc/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MARK_MonHoc mark_monhoc = db.MARK_MonHoc.Find(id);
            db.MARK_MonHoc.Remove(mark_monhoc);
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