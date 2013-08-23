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
    public class PhuongController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/Phuong/

        //[Authorize(Roles="Phuong.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/Phuong//Read

        //[Authorize(Roles="Phuong.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_Phuong.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/Phuong/Details/5

        //[Authorize(Roles="Phuong.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_Phuong stu_phuong = db.STU_Phuong.Find(id);
            if (stu_phuong == null)
            {
                return HttpNotFound();
            }
            return View(stu_phuong);
        }

        //
        // GET: /Admin/Phuong/Create

        //[Authorize(Roles="Phuong.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Phuong/Create

        [HttpPost]
        //[Authorize(Roles="Phuong.Create")]
        public ActionResult Create(STU_Phuong stu_phuong)
        {
            if (ModelState.IsValid)
            {
                db.STU_Phuong.Add(stu_phuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_phuong);
        }

        //
        // GET: /Admin/Phuong/Edit/5
        //[Authorize(Roles="Phuong.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_Phuong stu_phuong = db.STU_Phuong.Find(id);
            if (stu_phuong == null)
            {
                return HttpNotFound();
            }
            return View(stu_phuong);
        }

        //
        // POST: /Admin/Phuong/Edit/5

        [HttpPost]
        //[Authorize(Roles="Phuong.Edit")]
        public ActionResult Edit(STU_Phuong stu_phuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_phuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_phuong);
        }

        //
        // GET: /Admin/Phuong/Delete/5

        //[Authorize(Roles="Phuong.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_Phuong stu_phuong = db.STU_Phuong.Find(id);
            if (stu_phuong == null)
            {
                return HttpNotFound();
            }
            return View(stu_phuong);
        }

        //
        // POST: /Admin/Phuong/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="Phuong.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_Phuong stu_phuong = db.STU_Phuong.Find(id);
            db.STU_Phuong.Remove(stu_phuong);
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