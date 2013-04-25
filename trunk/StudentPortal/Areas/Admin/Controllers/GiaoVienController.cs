using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.Models;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class GiaoVienController : Controller
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/GiaoVien/

        public ActionResult Index()
        {
            return View(db.PLAN_GiaoVien.ToList());
        }

        //
        // GET: /Admin/GiaoVien/Details/5

        public ActionResult Details(int id = 0)
        {
            PLAN_GiaoVien plan_giaovien = db.PLAN_GiaoVien.Find(id);
            if (plan_giaovien == null)
            {
                return HttpNotFound();
            }
            return View(plan_giaovien);
        }

        //
        // GET: /Admin/GiaoVien/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/GiaoVien/Create

        [HttpPost]
        public ActionResult Create(PLAN_GiaoVien plan_giaovien)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_GiaoVien.Add(plan_giaovien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plan_giaovien);
        }

        //
        // GET: /Admin/GiaoVien/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PLAN_GiaoVien plan_giaovien = db.PLAN_GiaoVien.Find(id);
            if (plan_giaovien == null)
            {
                return HttpNotFound();
            }
            return View(plan_giaovien);
        }

        //
        // POST: /Admin/GiaoVien/Edit/5

        [HttpPost]
        public ActionResult Edit(PLAN_GiaoVien plan_giaovien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_giaovien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan_giaovien);
        }

        //
        // GET: /Admin/GiaoVien/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PLAN_GiaoVien plan_giaovien = db.PLAN_GiaoVien.Find(id);
            if (plan_giaovien == null)
            {
                return HttpNotFound();
            }
            return View(plan_giaovien);
        }

        //
        // POST: /Admin/GiaoVien/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAN_GiaoVien plan_giaovien = db.PLAN_GiaoVien.Find(id);
            db.PLAN_GiaoVien.Remove(plan_giaovien);
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