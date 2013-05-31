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
    public class ChucDanhSVController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/ChucDanhSV/

        //[Authorize(Roles="ChucDanhSV.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/ChucDanhSV//Read

        //[Authorize(Roles="ChucDanhSV.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_ChucDanh.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/ChucDanhSV/Details/5

        //[Authorize(Roles="ChucDanhSV.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_ChucDanh stu_chucdanh = db.STU_ChucDanh.Find(id);
            if (stu_chucdanh == null)
            {
                return HttpNotFound();
            }
            return View(stu_chucdanh);
        }

        //
        // GET: /Admin/ChucDanhSV/Create

        //[Authorize(Roles="ChucDanhSV.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/ChucDanhSV/Create

        [HttpPost]
        //[Authorize(Roles="ChucDanhSV.Create")]
        public ActionResult Create(STU_ChucDanh stu_chucdanh)
        {
            if (ModelState.IsValid)
            {
                db.STU_ChucDanh.Add(stu_chucdanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_chucdanh);
        }

        //
        // GET: /Admin/ChucDanhSV/Edit/5
        //[Authorize(Roles="ChucDanhSV.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_ChucDanh stu_chucdanh = db.STU_ChucDanh.Find(id);
            if (stu_chucdanh == null)
            {
                return HttpNotFound();
            }
            return View(stu_chucdanh);
        }

        //
        // POST: /Admin/ChucDanhSV/Edit/5

        [HttpPost]
        //[Authorize(Roles="ChucDanhSV.Edit")]
        public ActionResult Edit(STU_ChucDanh stu_chucdanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_chucdanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_chucdanh);
        }

        //
        // GET: /Admin/ChucDanhSV/Delete/5

        //[Authorize(Roles="ChucDanhSV.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_ChucDanh stu_chucdanh = db.STU_ChucDanh.Find(id);
            if (stu_chucdanh == null)
            {
                return HttpNotFound();
            }
            return View(stu_chucdanh);
        }

        //
        // POST: /Admin/ChucDanhSV/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="ChucDanhSV.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_ChucDanh stu_chucdanh = db.STU_ChucDanh.Find(id);
            db.STU_ChucDanh.Remove(stu_chucdanh);
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