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
    public class DanhSachNganh2Controller : BasicController
    {
        private DHHH db = new DHHH();

        //
        // GET: /Admin/DanhSachNganh2/

        //[Authorize(Roles="DanhSachNganh2.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DanhSachNganh2//Read

        //[Authorize(Roles="DanhSachNganh2.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_danhsachnganh2 = db.STU_DanhSachNganh2.Include(s => s.STU_DoiTuong);
            return Json(stu_danhsachnganh2.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DanhSachNganh2/Details/5

        //[Authorize(Roles="DanhSachNganh2.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DanhSachNganh2 stu_danhsachnganh2 = db.STU_DanhSachNganh2.Find(id);
            if (stu_danhsachnganh2 == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachnganh2);
        }

        //
        // GET: /Admin/DanhSachNganh2/Create

        //[Authorize(Roles="DanhSachNganh2.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_dt = new SelectList(db.STU_DoiTuong, "ID_dt", "Ma_dt");
            return View();
        }

        //
        // POST: /Admin/DanhSachNganh2/Create

        [HttpPost]
        //[Authorize(Roles="DanhSachNganh2.Create")]
        public ActionResult Create(STU_DanhSachNganh2 stu_danhsachnganh2)
        {
            if (ModelState.IsValid)
            {
                db.STU_DanhSachNganh2.Add(stu_danhsachnganh2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_dt = new SelectList(db.STU_DoiTuong, "ID_dt", "Ma_dt", stu_danhsachnganh2.ID_dt);
            return View(stu_danhsachnganh2);
        }

        //
        // GET: /Admin/DanhSachNganh2/Edit/5
        //[Authorize(Roles="DanhSachNganh2.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DanhSachNganh2 stu_danhsachnganh2 = db.STU_DanhSachNganh2.Find(id);
            if (stu_danhsachnganh2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_dt = new SelectList(db.STU_DoiTuong, "ID_dt", "Ma_dt", stu_danhsachnganh2.ID_dt);
            return View(stu_danhsachnganh2);
        }

        //
        // POST: /Admin/DanhSachNganh2/Edit/5

        [HttpPost]
        //[Authorize(Roles="DanhSachNganh2.Edit")]
        public ActionResult Edit(STU_DanhSachNganh2 stu_danhsachnganh2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_danhsachnganh2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_dt = new SelectList(db.STU_DoiTuong, "ID_dt", "Ma_dt", stu_danhsachnganh2.ID_dt);
            return View(stu_danhsachnganh2);
        }

        //
        // GET: /Admin/DanhSachNganh2/Delete/5

        //[Authorize(Roles="DanhSachNganh2.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DanhSachNganh2 stu_danhsachnganh2 = db.STU_DanhSachNganh2.Find(id);
            if (stu_danhsachnganh2 == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachnganh2);
        }

        //
        // POST: /Admin/DanhSachNganh2/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DanhSachNganh2.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DanhSachNganh2 stu_danhsachnganh2 = db.STU_DanhSachNganh2.Find(id);
            db.STU_DanhSachNganh2.Remove(stu_danhsachnganh2);
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