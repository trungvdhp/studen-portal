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
    public class DanhhieuThiDuaCaNhanController : BasicController
    {
        private DHHH db = new DHHH();

        //
        // GET: /Admin/DanhhieuThiDuaCaNhan/

        //[Authorize(Roles="DanhhieuThiDuaCaNhan.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DanhhieuThiDuaCaNhan//Read

        //[Authorize(Roles="DanhhieuThiDuaCaNhan.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_danhhieuthiduacanhan = db.STU_DanhhieuThiDuaCaNhan.Include(s => s.STU_DanhHieu);
            return Json(stu_danhhieuthiduacanhan.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DanhhieuThiDuaCaNhan/Details/5

        //[Authorize(Roles="DanhhieuThiDuaCaNhan.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DanhhieuThiDuaCaNhan stu_danhhieuthiduacanhan = db.STU_DanhhieuThiDuaCaNhan.Find(id);
            if (stu_danhhieuthiduacanhan == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhhieuthiduacanhan);
        }

        //
        // GET: /Admin/DanhhieuThiDuaCaNhan/Create

        //[Authorize(Roles="DanhhieuThiDuaCaNhan.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_danh_hieu = new SelectList(db.STU_DanhHieu, "ID_danh_hieu", "Danh_hieu");
            return View();
        }

        //
        // POST: /Admin/DanhhieuThiDuaCaNhan/Create

        [HttpPost]
        //[Authorize(Roles="DanhhieuThiDuaCaNhan.Create")]
        public ActionResult Create(STU_DanhhieuThiDuaCaNhan stu_danhhieuthiduacanhan)
        {
            if (ModelState.IsValid)
            {
                db.STU_DanhhieuThiDuaCaNhan.Add(stu_danhhieuthiduacanhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_danh_hieu = new SelectList(db.STU_DanhHieu, "ID_danh_hieu", "Danh_hieu", stu_danhhieuthiduacanhan.ID_danh_hieu);
            return View(stu_danhhieuthiduacanhan);
        }

        //
        // GET: /Admin/DanhhieuThiDuaCaNhan/Edit/5
        //[Authorize(Roles="DanhhieuThiDuaCaNhan.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DanhhieuThiDuaCaNhan stu_danhhieuthiduacanhan = db.STU_DanhhieuThiDuaCaNhan.Find(id);
            if (stu_danhhieuthiduacanhan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_danh_hieu = new SelectList(db.STU_DanhHieu, "ID_danh_hieu", "Danh_hieu", stu_danhhieuthiduacanhan.ID_danh_hieu);
            return View(stu_danhhieuthiduacanhan);
        }

        //
        // POST: /Admin/DanhhieuThiDuaCaNhan/Edit/5

        [HttpPost]
        //[Authorize(Roles="DanhhieuThiDuaCaNhan.Edit")]
        public ActionResult Edit(STU_DanhhieuThiDuaCaNhan stu_danhhieuthiduacanhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_danhhieuthiduacanhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_danh_hieu = new SelectList(db.STU_DanhHieu, "ID_danh_hieu", "Danh_hieu", stu_danhhieuthiduacanhan.ID_danh_hieu);
            return View(stu_danhhieuthiduacanhan);
        }

        //
        // GET: /Admin/DanhhieuThiDuaCaNhan/Delete/5

        //[Authorize(Roles="DanhhieuThiDuaCaNhan.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DanhhieuThiDuaCaNhan stu_danhhieuthiduacanhan = db.STU_DanhhieuThiDuaCaNhan.Find(id);
            if (stu_danhhieuthiduacanhan == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhhieuthiduacanhan);
        }

        //
        // POST: /Admin/DanhhieuThiDuaCaNhan/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DanhhieuThiDuaCaNhan.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DanhhieuThiDuaCaNhan stu_danhhieuthiduacanhan = db.STU_DanhhieuThiDuaCaNhan.Find(id);
            db.STU_DanhhieuThiDuaCaNhan.Remove(stu_danhhieuthiduacanhan);
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