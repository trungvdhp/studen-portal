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
    public class QuyHocBongController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/QuyHocBong/

        //[Authorize(Roles="QuyHocBong.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/QuyHocBong//Read

        //[Authorize(Roles="QuyHocBong.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_quyhocbong = db.STU_QuyHocBong.Include(s => s.STU_He);
            return Json(stu_quyhocbong.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/QuyHocBong/Details/5

        //[Authorize(Roles="QuyHocBong.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_QuyHocBong stu_quyhocbong = db.STU_QuyHocBong.Find(id);
            if (stu_quyhocbong == null)
            {
                return HttpNotFound();
            }
            return View(stu_quyhocbong);
        }

        //
        // GET: /Admin/QuyHocBong/Create

        //[Authorize(Roles="QuyHocBong.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he");
            return View();
        }

        //
        // POST: /Admin/QuyHocBong/Create

        [HttpPost]
        //[Authorize(Roles="QuyHocBong.Create")]
        public ActionResult Create(STU_QuyHocBong stu_quyhocbong)
        {
            if (ModelState.IsValid)
            {
                db.STU_QuyHocBong.Add(stu_quyhocbong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", stu_quyhocbong.ID_he);
            return View(stu_quyhocbong);
        }

        //
        // GET: /Admin/QuyHocBong/Edit/5
        //[Authorize(Roles="QuyHocBong.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_QuyHocBong stu_quyhocbong = db.STU_QuyHocBong.Find(id);
            if (stu_quyhocbong == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", stu_quyhocbong.ID_he);
            return View(stu_quyhocbong);
        }

        //
        // POST: /Admin/QuyHocBong/Edit/5

        [HttpPost]
        //[Authorize(Roles="QuyHocBong.Edit")]
        public ActionResult Edit(STU_QuyHocBong stu_quyhocbong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_quyhocbong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", stu_quyhocbong.ID_he);
            return View(stu_quyhocbong);
        }

        //
        // GET: /Admin/QuyHocBong/Delete/5

        //[Authorize(Roles="QuyHocBong.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_QuyHocBong stu_quyhocbong = db.STU_QuyHocBong.Find(id);
            if (stu_quyhocbong == null)
            {
                return HttpNotFound();
            }
            return View(stu_quyhocbong);
        }

        //
        // POST: /Admin/QuyHocBong/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="QuyHocBong.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_QuyHocBong stu_quyhocbong = db.STU_QuyHocBong.Find(id);
            db.STU_QuyHocBong.Remove(stu_quyhocbong);
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