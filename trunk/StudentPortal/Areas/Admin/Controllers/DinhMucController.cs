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
    public class DinhMucController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/DinhMuc/

        //[Authorize(Roles="DinhMuc.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DinhMuc//Read

        //[Authorize(Roles="DinhMuc.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_dinhmuc = db.STU_DinhMuc.Include(s => s.STU_ChucDanh);
            return Json(stu_dinhmuc.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DinhMuc/Details/5

        //[Authorize(Roles="DinhMuc.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DinhMuc stu_dinhmuc = db.STU_DinhMuc.Find(id);
            if (stu_dinhmuc == null)
            {
                return HttpNotFound();
            }
            return View(stu_dinhmuc);
        }

        //
        // GET: /Admin/DinhMuc/Create

        //[Authorize(Roles="DinhMuc.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_chuc_danh = new SelectList(db.STU_ChucDanh, "ID_chuc_danh", "Chuc_danh");
            return View();
        }

        //
        // POST: /Admin/DinhMuc/Create

        [HttpPost]
        //[Authorize(Roles="DinhMuc.Create")]
        public ActionResult Create(STU_DinhMuc stu_dinhmuc)
        {
            if (ModelState.IsValid)
            {
                db.STU_DinhMuc.Add(stu_dinhmuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_chuc_danh = new SelectList(db.STU_ChucDanh, "ID_chuc_danh", "Chuc_danh", stu_dinhmuc.ID_chuc_danh);
            return View(stu_dinhmuc);
        }

        //
        // GET: /Admin/DinhMuc/Edit/5
        //[Authorize(Roles="DinhMuc.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DinhMuc stu_dinhmuc = db.STU_DinhMuc.Find(id);
            if (stu_dinhmuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_chuc_danh = new SelectList(db.STU_ChucDanh, "ID_chuc_danh", "Chuc_danh", stu_dinhmuc.ID_chuc_danh);
            return View(stu_dinhmuc);
        }

        //
        // POST: /Admin/DinhMuc/Edit/5

        [HttpPost]
        //[Authorize(Roles="DinhMuc.Edit")]
        public ActionResult Edit(STU_DinhMuc stu_dinhmuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_dinhmuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_chuc_danh = new SelectList(db.STU_ChucDanh, "ID_chuc_danh", "Chuc_danh", stu_dinhmuc.ID_chuc_danh);
            return View(stu_dinhmuc);
        }

        //
        // GET: /Admin/DinhMuc/Delete/5

        //[Authorize(Roles="DinhMuc.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DinhMuc stu_dinhmuc = db.STU_DinhMuc.Find(id);
            if (stu_dinhmuc == null)
            {
                return HttpNotFound();
            }
            return View(stu_dinhmuc);
        }

        //
        // POST: /Admin/DinhMuc/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DinhMuc.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DinhMuc stu_dinhmuc = db.STU_DinhMuc.Find(id);
            db.STU_DinhMuc.Remove(stu_dinhmuc);
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