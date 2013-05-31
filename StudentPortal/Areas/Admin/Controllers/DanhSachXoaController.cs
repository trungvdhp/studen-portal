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
    public class DanhSachXoaController : BasicController
    {
        private DHHH db = new DHHH();

        //
        // GET: /Admin/DanhSachXoa/

       //[Authorize(Roles="DanhSachXoa.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DanhSachXoa//Read

       //[Authorize(Roles="DanhSachXoa.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_danhsachxoa = db.STU_DanhSachXoa.Include(s => s.STU_Lop);
            return Json(stu_danhsachxoa.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DanhSachXoa/Details/5

       //[Authorize(Roles="DanhSachXoa.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DanhSachXoa stu_danhsachxoa = db.STU_DanhSachXoa.Find(id);
            if (stu_danhsachxoa == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachxoa);
        }

        //
        // GET: /Admin/DanhSachXoa/Create

       //[Authorize(Roles="DanhSachXoa.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_lop = new SelectList(db.STU_Lop, "ID_lop", "Ten_lop");
            return View();
        }

        //
        // POST: /Admin/DanhSachXoa/Create

        [HttpPost]
       //[Authorize(Roles="DanhSachXoa.Create")]
        public ActionResult Create(STU_DanhSachXoa stu_danhsachxoa)
        {
            if (ModelState.IsValid)
            {
                db.STU_DanhSachXoa.Add(stu_danhsachxoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_lop = new SelectList(db.STU_Lop, "ID_lop", "Ten_lop", stu_danhsachxoa.ID_lop);
            return View(stu_danhsachxoa);
        }

        //
        // GET: /Admin/DanhSachXoa/Edit/5
       //[Authorize(Roles="DanhSachXoa.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DanhSachXoa stu_danhsachxoa = db.STU_DanhSachXoa.Find(id);
            if (stu_danhsachxoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_lop = new SelectList(db.STU_Lop, "ID_lop", "Ten_lop", stu_danhsachxoa.ID_lop);
            return View(stu_danhsachxoa);
        }

        //
        // POST: /Admin/DanhSachXoa/Edit/5

        [HttpPost]
       //[Authorize(Roles="DanhSachXoa.Edit")]
        public ActionResult Edit(STU_DanhSachXoa stu_danhsachxoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_danhsachxoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_lop = new SelectList(db.STU_Lop, "ID_lop", "Ten_lop", stu_danhsachxoa.ID_lop);
            return View(stu_danhsachxoa);
        }

        //
        // GET: /Admin/DanhSachXoa/Delete/5

       //[Authorize(Roles="DanhSachXoa.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DanhSachXoa stu_danhsachxoa = db.STU_DanhSachXoa.Find(id);
            if (stu_danhsachxoa == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachxoa);
        }

        //
        // POST: /Admin/DanhSachXoa/Delete/5

        [HttpPost, ActionName("Delete")]
       //[Authorize(Roles="DanhSachXoa.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DanhSachXoa stu_danhsachxoa = db.STU_DanhSachXoa.Find(id);
            db.STU_DanhSachXoa.Remove(stu_danhsachxoa);
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