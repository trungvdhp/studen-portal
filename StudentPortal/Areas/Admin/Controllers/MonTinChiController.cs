using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using StudentPortal.Lib;


namespace StudentPortal.Areas.Admin.Controllers
{
    public class MonTinChiController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/MonTinChi/

        //[Authorize(Roles="MonTinChi.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/MonTinChi//Read

		public ActionResult getKhoa()
		{
			JsonResult result = new JsonResult();
			result.Data = new SelectList(db.STU_Khoa.ToList(), "ID_khoa", "Ten_khoa");
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return result;
		}

		public ActionResult getHe()
		{
			JsonResult result = new JsonResult();
			result.Data = new SelectList(db.STU_He.ToList(), "ID_he", "Ten_he");
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return result;
		}

        //[Authorize(Roles="MonTinChi.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request,string IDHe,string IDKhoa,string KyThu)
        {
			int ID_khoa = 0, ID_he = 0, Ky_thu = 0;
			try
			{
				ID_he = Convert.ToInt32(IDHe);
				ID_khoa = Convert.ToInt32(IDKhoa);
				Ky_thu = Convert.ToInt32(KyThu);
			}
			catch (Exception) { };
			List<int> mon = ChuongTrinhDaoTao.getMonHoc(ID_he, ID_khoa, Ky_thu);
            var plan_montinchi_tc = db.PLAN_MonTinChi_TC.Include(p => p.MARK_MonHoc).Where(t=>t.ID_mon_tc!=0);
			var result = new List<PLAN_MonTinChi_TC>();
			foreach (var m in plan_montinchi_tc) if (mon.Contains(m.ID_mon)) result.Add(m);
			return Json(result.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/MonTinChi/Details/5

        //[Authorize(Roles="MonTinChi.Details")]
        public ActionResult Details(int id = 0)
        {
            PLAN_MonTinChi_TC plan_montinchi_tc = db.PLAN_MonTinChi_TC.Find(id);
            if (plan_montinchi_tc == null)
            {
                return HttpNotFound();
            }
            return View(plan_montinchi_tc);
        }

        //
        // GET: /Admin/MonTinChi/Create

        //[Authorize(Roles="MonTinChi.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_mon = new SelectList(db.MARK_MonHoc, "ID_mon", "Ten_mon");
            return View();
        }

        //
        // POST: /Admin/MonTinChi/Create

        [HttpPost]
        //[Authorize(Roles="MonTinChi.Create")]
        public ActionResult Create(PLAN_MonTinChi_TC plan_montinchi_tc)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_MonTinChi_TC.Add(plan_montinchi_tc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_mon = new SelectList(db.MARK_MonHoc, "ID_mon", "Ten_mon", plan_montinchi_tc.ID_mon);
            return View(plan_montinchi_tc);
        }

        //
        // GET: /Admin/MonTinChi/Edit/5
        //[Authorize(Roles="MonTinChi.Edit")]
        public ActionResult Edit(int id = 0)
        {
            PLAN_MonTinChi_TC plan_montinchi_tc = db.PLAN_MonTinChi_TC.Find(id);
            if (plan_montinchi_tc == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_mon = new SelectList(db.MARK_MonHoc, "ID_mon", "Ten_mon", plan_montinchi_tc.ID_mon);
            return View(plan_montinchi_tc);
        }

        //
        // POST: /Admin/MonTinChi/Edit/5

        [HttpPost]
        //[Authorize(Roles="MonTinChi.Edit")]
        public ActionResult Edit(PLAN_MonTinChi_TC plan_montinchi_tc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_montinchi_tc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_mon = new SelectList(db.MARK_MonHoc, "ID_mon", "Ten_mon", plan_montinchi_tc.ID_mon);
            return View(plan_montinchi_tc);
        }

        //
        // GET: /Admin/MonTinChi/Delete/5

        //[Authorize(Roles="MonTinChi.Delete")]
        public ActionResult Delete(int id = 0)
        {
            PLAN_MonTinChi_TC plan_montinchi_tc = db.PLAN_MonTinChi_TC.Find(id);
            if (plan_montinchi_tc == null)
            {
                return HttpNotFound();
            }
            return View(plan_montinchi_tc);
        }

        //
        // POST: /Admin/MonTinChi/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="MonTinChi.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAN_MonTinChi_TC plan_montinchi_tc = db.PLAN_MonTinChi_TC.Find(id);
            db.PLAN_MonTinChi_TC.Remove(plan_montinchi_tc);
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