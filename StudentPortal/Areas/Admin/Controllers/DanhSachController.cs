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
    public class DanhSachController : BasicController
    {
        private DHHH db = new DHHH();

        //
        // GET: /Admin/DanhSach/

        //[Authorize(Roles="DanhSach.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DanhSach//Read

        //[Authorize(Roles="DanhSach.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_danhsach = db.STU_DanhSach.Include(s => s.STU_Lop);
            return Json(stu_danhsach.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DanhSach/Details/5

        //[Authorize(Roles="DanhSach.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DanhSach stu_danhsach = db.STU_DanhSach.Find(id);
            if (stu_danhsach == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsach);
        }

        //
        // GET: /Admin/DanhSach/Create

        //[Authorize(Roles="DanhSach.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_lop = new SelectList(db.STU_Lop, "ID_lop", "Ten_lop");
            return View();
        }

        //
        // POST: /Admin/DanhSach/Create

        [HttpPost]
        //[Authorize(Roles="DanhSach.Create")]
        public ActionResult Create(STU_DanhSach stu_danhsach)
        {
            if (ModelState.IsValid)
            {
                db.STU_DanhSach.Add(stu_danhsach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_lop = new SelectList(db.STU_Lop, "ID_lop", "Ten_lop", stu_danhsach.ID_lop);
            return View(stu_danhsach);
        }

        //
        // GET: /Admin/DanhSach/Edit/5
        //[Authorize(Roles="DanhSach.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DanhSach stu_danhsach = db.STU_DanhSach.Find(id);
            if (stu_danhsach == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_lop = new SelectList(db.STU_Lop, "ID_lop", "Ten_lop", stu_danhsach.ID_lop);
            return View(stu_danhsach);
        }

        //
        // POST: /Admin/DanhSach/Edit/5

        [HttpPost]
        //[Authorize(Roles="DanhSach.Edit")]
        public ActionResult Edit(STU_DanhSach stu_danhsach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_danhsach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_lop = new SelectList(db.STU_Lop, "ID_lop", "Ten_lop", stu_danhsach.ID_lop);
            return View(stu_danhsach);
        }

        //
        // GET: /Admin/DanhSach/Delete/5

        //[Authorize(Roles="DanhSach.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DanhSach stu_danhsach = db.STU_DanhSach.Find(id);
            if (stu_danhsach == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsach);
        }

        //
        // POST: /Admin/DanhSach/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DanhSach.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DanhSach stu_danhsach = db.STU_DanhSach.Find(id);
            db.STU_DanhSach.Remove(stu_danhsach);
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