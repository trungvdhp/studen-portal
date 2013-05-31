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
    public class DanhSachKhongThiController : BasicController
    {
        private DHHH db = new DHHH();

        //
        // GET: /Admin/DanhSachKhongThi/

        //[Authorize(Roles="DanhSachKhongThi.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DanhSachKhongThi//Read

        //[Authorize(Roles="DanhSachKhongThi.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_danhsachkhongthi = db.STU_DanhSachKhongThi.Include(s => s.MARK_MonHoc);
            return Json(stu_danhsachkhongthi.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DanhSachKhongThi/Details/5

        //[Authorize(Roles="DanhSachKhongThi.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DanhSachKhongThi stu_danhsachkhongthi = db.STU_DanhSachKhongThi.Find(id);
            if (stu_danhsachkhongthi == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachkhongthi);
        }

        //
        // GET: /Admin/DanhSachKhongThi/Create

        //[Authorize(Roles="DanhSachKhongThi.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_mon = new SelectList(db.MARK_MonHoc, "ID_mon", "Ky_hieu");
            return View();
        }

        //
        // POST: /Admin/DanhSachKhongThi/Create

        [HttpPost]
        //[Authorize(Roles="DanhSachKhongThi.Create")]
        public ActionResult Create(STU_DanhSachKhongThi stu_danhsachkhongthi)
        {
            if (ModelState.IsValid)
            {
                db.STU_DanhSachKhongThi.Add(stu_danhsachkhongthi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_mon = new SelectList(db.MARK_MonHoc, "ID_mon", "Ky_hieu", stu_danhsachkhongthi.ID_mon);
            return View(stu_danhsachkhongthi);
        }

        //
        // GET: /Admin/DanhSachKhongThi/Edit/5
        //[Authorize(Roles="DanhSachKhongThi.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DanhSachKhongThi stu_danhsachkhongthi = db.STU_DanhSachKhongThi.Find(id);
            if (stu_danhsachkhongthi == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_mon = new SelectList(db.MARK_MonHoc, "ID_mon", "Ky_hieu", stu_danhsachkhongthi.ID_mon);
            return View(stu_danhsachkhongthi);
        }

        //
        // POST: /Admin/DanhSachKhongThi/Edit/5

        [HttpPost]
        //[Authorize(Roles="DanhSachKhongThi.Edit")]
        public ActionResult Edit(STU_DanhSachKhongThi stu_danhsachkhongthi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_danhsachkhongthi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_mon = new SelectList(db.MARK_MonHoc, "ID_mon", "Ky_hieu", stu_danhsachkhongthi.ID_mon);
            return View(stu_danhsachkhongthi);
        }

        //
        // GET: /Admin/DanhSachKhongThi/Delete/5

        //[Authorize(Roles="DanhSachKhongThi.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DanhSachKhongThi stu_danhsachkhongthi = db.STU_DanhSachKhongThi.Find(id);
            if (stu_danhsachkhongthi == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachkhongthi);
        }

        //
        // POST: /Admin/DanhSachKhongThi/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DanhSachKhongThi.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DanhSachKhongThi stu_danhsachkhongthi = db.STU_DanhSachKhongThi.Find(id);
            db.STU_DanhSachKhongThi.Remove(stu_danhsachkhongthi);
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