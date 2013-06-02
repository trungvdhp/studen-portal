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
    public class DoanController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/Doan/

        //[Authorize(Roles="Doan.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/Doan//Read

        //[Authorize(Roles="Doan.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_Doan.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/Doan/Details/5

        //[Authorize(Roles="Doan.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_Doan stu_doan = db.STU_Doan.Find(id);
            if (stu_doan == null)
            {
                return HttpNotFound();
            }
            return View(stu_doan);
        }

        //
        // GET: /Admin/Doan/Create

        //[Authorize(Roles="Doan.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Doan/Create

        [HttpPost]
        //[Authorize(Roles="Doan.Create")]
        public ActionResult Create(STU_Doan stu_doan)
        {
            if (ModelState.IsValid)
            {
                db.STU_Doan.Add(stu_doan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_doan);
        }

        //
        // GET: /Admin/Doan/Edit/5
        //[Authorize(Roles="Doan.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_Doan stu_doan = db.STU_Doan.Find(id);
            if (stu_doan == null)
            {
                return HttpNotFound();
            }
            return View(stu_doan);
        }

        //
        // POST: /Admin/Doan/Edit/5

        [HttpPost]
        //[Authorize(Roles="Doan.Edit")]
        public ActionResult Edit(STU_Doan stu_doan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_doan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_doan);
        }

        //
        // GET: /Admin/Doan/Delete/5

        //[Authorize(Roles="Doan.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_Doan stu_doan = db.STU_Doan.Find(id);
            if (stu_doan == null)
            {
                return HttpNotFound();
            }
            return View(stu_doan);
        }

        //
        // POST: /Admin/Doan/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="Doan.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_Doan stu_doan = db.STU_Doan.Find(id);
            db.STU_Doan.Remove(stu_doan);
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