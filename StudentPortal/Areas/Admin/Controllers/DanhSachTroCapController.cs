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
    public class DanhSachTroCapController : BasicController
    {
        private DHHH db = new DHHH();

        //
        // GET: /Admin/DanhSachTroCap/

        //[Authorize(Roles="DanhSachTroCap.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DanhSachTroCap//Read

        //[Authorize(Roles="DanhSachTroCap.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_DanhSachTroCap.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DanhSachTroCap/Details/5

        //[Authorize(Roles="DanhSachTroCap.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DanhSachTroCap stu_danhsachtrocap = db.STU_DanhSachTroCap.Find(id);
            if (stu_danhsachtrocap == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachtrocap);
        }

        //
        // GET: /Admin/DanhSachTroCap/Create

        //[Authorize(Roles="DanhSachTroCap.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/DanhSachTroCap/Create

        [HttpPost]
        //[Authorize(Roles="DanhSachTroCap.Create")]
        public ActionResult Create(STU_DanhSachTroCap stu_danhsachtrocap)
        {
            if (ModelState.IsValid)
            {
                db.STU_DanhSachTroCap.Add(stu_danhsachtrocap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_danhsachtrocap);
        }

        //
        // GET: /Admin/DanhSachTroCap/Edit/5
        //[Authorize(Roles="DanhSachTroCap.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DanhSachTroCap stu_danhsachtrocap = db.STU_DanhSachTroCap.Find(id);
            if (stu_danhsachtrocap == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachtrocap);
        }

        //
        // POST: /Admin/DanhSachTroCap/Edit/5

        [HttpPost]
        //[Authorize(Roles="DanhSachTroCap.Edit")]
        public ActionResult Edit(STU_DanhSachTroCap stu_danhsachtrocap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_danhsachtrocap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_danhsachtrocap);
        }

        //
        // GET: /Admin/DanhSachTroCap/Delete/5

        //[Authorize(Roles="DanhSachTroCap.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DanhSachTroCap stu_danhsachtrocap = db.STU_DanhSachTroCap.Find(id);
            if (stu_danhsachtrocap == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhsachtrocap);
        }

        //
        // POST: /Admin/DanhSachTroCap/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DanhSachTroCap.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DanhSachTroCap stu_danhsachtrocap = db.STU_DanhSachTroCap.Find(id);
            db.STU_DanhSachTroCap.Remove(stu_danhsachtrocap);
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