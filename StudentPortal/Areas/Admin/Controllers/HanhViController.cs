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
    public class HanhViController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HanhVi/

        //[Authorize(Roles="HanhVi.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HanhVi//Read

        //[Authorize(Roles="HanhVi.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_HanhVi.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HanhVi/Details/5

        //[Authorize(Roles="HanhVi.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_HanhVi stu_hanhvi = db.STU_HanhVi.Find(id);
            if (stu_hanhvi == null)
            {
                return HttpNotFound();
            }
            return View(stu_hanhvi);
        }

        //
        // GET: /Admin/HanhVi/Create

        //[Authorize(Roles="HanhVi.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/HanhVi/Create

        [HttpPost]
        //[Authorize(Roles="HanhVi.Create")]
        public ActionResult Create(STU_HanhVi stu_hanhvi)
        {
            if (ModelState.IsValid)
            {
                db.STU_HanhVi.Add(stu_hanhvi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_hanhvi);
        }

        //
        // GET: /Admin/HanhVi/Edit/5
        //[Authorize(Roles="HanhVi.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_HanhVi stu_hanhvi = db.STU_HanhVi.Find(id);
            if (stu_hanhvi == null)
            {
                return HttpNotFound();
            }
            return View(stu_hanhvi);
        }

        //
        // POST: /Admin/HanhVi/Edit/5

        [HttpPost]
        //[Authorize(Roles="HanhVi.Edit")]
        public ActionResult Edit(STU_HanhVi stu_hanhvi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_hanhvi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_hanhvi);
        }

        //
        // GET: /Admin/HanhVi/Delete/5

        //[Authorize(Roles="HanhVi.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_HanhVi stu_hanhvi = db.STU_HanhVi.Find(id);
            if (stu_hanhvi == null)
            {
                return HttpNotFound();
            }
            return View(stu_hanhvi);
        }

        //
        // POST: /Admin/HanhVi/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HanhVi.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_HanhVi stu_hanhvi = db.STU_HanhVi.Find(id);
            db.STU_HanhVi.Remove(stu_hanhvi);
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