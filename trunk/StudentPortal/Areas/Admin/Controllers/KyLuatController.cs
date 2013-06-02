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
    public class KyLuatController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/KyLuat/

        //[Authorize(Roles="KyLuat.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/KyLuat//Read

        //[Authorize(Roles="KyLuat.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_kyluat = db.STU_KyLuat.Include(s => s.STU_HanhVi).Include(s => s.STU_XuLy);
            return Json(stu_kyluat.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/KyLuat/Details/5

        //[Authorize(Roles="KyLuat.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_KyLuat stu_kyluat = db.STU_KyLuat.Find(id);
            if (stu_kyluat == null)
            {
                return HttpNotFound();
            }
            return View(stu_kyluat);
        }

        //
        // GET: /Admin/KyLuat/Create

        //[Authorize(Roles="KyLuat.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_hanh_vi = new SelectList(db.STU_HanhVi, "ID_hanh_vi", "Ma_hanh_vi");
            ViewBag.ID_xu_ly = new SelectList(db.STU_XuLy, "ID_xu_ly", "Xu_ly");
            return View();
        }

        //
        // POST: /Admin/KyLuat/Create

        [HttpPost]
        //[Authorize(Roles="KyLuat.Create")]
        public ActionResult Create(STU_KyLuat stu_kyluat)
        {
            if (ModelState.IsValid)
            {
                db.STU_KyLuat.Add(stu_kyluat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_hanh_vi = new SelectList(db.STU_HanhVi, "ID_hanh_vi", "Ma_hanh_vi", stu_kyluat.ID_hanh_vi);
            ViewBag.ID_xu_ly = new SelectList(db.STU_XuLy, "ID_xu_ly", "Xu_ly", stu_kyluat.ID_xu_ly);
            return View(stu_kyluat);
        }

        //
        // GET: /Admin/KyLuat/Edit/5
        //[Authorize(Roles="KyLuat.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_KyLuat stu_kyluat = db.STU_KyLuat.Find(id);
            if (stu_kyluat == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_hanh_vi = new SelectList(db.STU_HanhVi, "ID_hanh_vi", "Ma_hanh_vi", stu_kyluat.ID_hanh_vi);
            ViewBag.ID_xu_ly = new SelectList(db.STU_XuLy, "ID_xu_ly", "Xu_ly", stu_kyluat.ID_xu_ly);
            return View(stu_kyluat);
        }

        //
        // POST: /Admin/KyLuat/Edit/5

        [HttpPost]
        //[Authorize(Roles="KyLuat.Edit")]
        public ActionResult Edit(STU_KyLuat stu_kyluat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_kyluat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_hanh_vi = new SelectList(db.STU_HanhVi, "ID_hanh_vi", "Ma_hanh_vi", stu_kyluat.ID_hanh_vi);
            ViewBag.ID_xu_ly = new SelectList(db.STU_XuLy, "ID_xu_ly", "Xu_ly", stu_kyluat.ID_xu_ly);
            return View(stu_kyluat);
        }

        //
        // GET: /Admin/KyLuat/Delete/5

        //[Authorize(Roles="KyLuat.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_KyLuat stu_kyluat = db.STU_KyLuat.Find(id);
            if (stu_kyluat == null)
            {
                return HttpNotFound();
            }
            return View(stu_kyluat);
        }

        //
        // POST: /Admin/KyLuat/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="KyLuat.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_KyLuat stu_kyluat = db.STU_KyLuat.Find(id);
            db.STU_KyLuat.Remove(stu_kyluat);
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