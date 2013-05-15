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
    public class GiaoVienController : Controller
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/GiaoVien/

        [Authorize(Roles="GiaoVien.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/GiaoVien//Read

        [Authorize(Roles="GiaoVien.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var plan_giaovien = db.PLAN_GiaoVien.Include(p => p.STU_Khoa);
            return Json(plan_giaovien.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/GiaoVien/Details/5

        [Authorize(Roles="GiaoVien.Details")]
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

        [Authorize(Roles="GiaoVien.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_khoa = new SelectList(db.STU_Khoa, "ID_khoa", "Ma_khoa");
            return View();
        }

        //
        // POST: /Admin/GiaoVien/Create

        [HttpPost]
        [Authorize(Roles="GiaoVien.Create")]
        public ActionResult Create(PLAN_GiaoVien plan_giaovien)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_GiaoVien.Add(plan_giaovien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_khoa = new SelectList(db.STU_Khoa, "ID_khoa", "Ma_khoa", plan_giaovien.ID_khoa);
            return View(plan_giaovien);
        }

        //
        // GET: /Admin/GiaoVien/Edit/5
        [Authorize(Roles="GiaoVien.Edit")]
        public ActionResult Edit(int id = 0)
        {
            PLAN_GiaoVien plan_giaovien = db.PLAN_GiaoVien.Find(id);
            if (plan_giaovien == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_khoa = new SelectList(db.STU_Khoa, "ID_khoa", "Ma_khoa", plan_giaovien.ID_khoa);
            return View(plan_giaovien);
        }

        //
        // POST: /Admin/GiaoVien/Edit/5

        [HttpPost]
        [Authorize(Roles="GiaoVien.Edit")]
        public ActionResult Edit(PLAN_GiaoVien plan_giaovien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_giaovien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_khoa = new SelectList(db.STU_Khoa, "ID_khoa", "Ma_khoa", plan_giaovien.ID_khoa);
            return View(plan_giaovien);
        }

        //
        // GET: /Admin/GiaoVien/Delete/5

        [Authorize(Roles="GiaoVien.Delete")]
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
        [Authorize(Roles="GiaoVien.DeleteConfirmed")]
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