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
    public class HeController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/He/

        //[Authorize(Roles="He.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/He//Read

        //[Authorize(Roles="He.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_He.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/He/Details/5

        //[Authorize(Roles="He.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_He stu_he = db.STU_He.Find(id);
            if (stu_he == null)
            {
                return HttpNotFound();
            }
            return View(stu_he);
        }

        //
        // GET: /Admin/He/Create

        //[Authorize(Roles="He.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/He/Create

        [HttpPost]
        //[Authorize(Roles="He.Create")]
        public ActionResult Create(STU_He stu_he)
        {
            if (ModelState.IsValid)
            {
                db.STU_He.Add(stu_he);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_he);
        }

        //
        // GET: /Admin/He/Edit/5
        //[Authorize(Roles="He.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_He stu_he = db.STU_He.Find(id);
            if (stu_he == null)
            {
                return HttpNotFound();
            }
            return View(stu_he);
        }

        //
        // POST: /Admin/He/Edit/5

        [HttpPost]
        //[Authorize(Roles="He.Edit")]
        public ActionResult Edit(STU_He stu_he)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_he).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_he);
        }

        //
        // GET: /Admin/He/Delete/5

        //[Authorize(Roles="He.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_He stu_he = db.STU_He.Find(id);
            if (stu_he == null)
            {
                return HttpNotFound();
            }
            return View(stu_he);
        }

        //
        // POST: /Admin/He/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="He.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_He stu_he = db.STU_He.Find(id);
            db.STU_He.Remove(stu_he);
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