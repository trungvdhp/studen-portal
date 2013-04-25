using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class LopHocPhanController : Controller
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/LopHocPhan/

        public ActionResult Index()
        {
            var plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Include(p => p.PLAN_MonTinChi_TC);
            return View(plan_loptinchi_tc.ToList());
        }

        //
        // GET: /Admin/LopHocPhan/Details/5

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
        // GET: /Admin/LopHocPhan/Create

        public ActionResult Create()
        {
            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc");
            return View();
        }

        //
        // POST: /Admin/LopHocPhan/Create

        [HttpPost]
        public ActionResult Create(PLAN_LopTinChi_TC plan_loptinchi_tc)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_LopTinChi_TC.Add(plan_loptinchi_tc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc", plan_loptinchi_tc.ID_mon_tc);
            return View(plan_loptinchi_tc);
        }

        //
        // GET: /Admin/LopHocPhan/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PLAN_LopTinChi_TC plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Find(id);
            if (plan_loptinchi_tc == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc", plan_loptinchi_tc.ID_mon_tc);
            return View(plan_loptinchi_tc);
        }

        //
        // POST: /Admin/LopHocPhan/Edit/5

        [HttpPost]
        public ActionResult Edit(PLAN_LopTinChi_TC plan_loptinchi_tc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_loptinchi_tc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc", plan_loptinchi_tc.ID_mon_tc);
            return View(plan_loptinchi_tc);
        }

        //
        // GET: /Admin/LopHocPhan/Delete/5

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
        // POST: /Admin/LopHocPhan/Delete/5

        [HttpPost, ActionName("Delete")]
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