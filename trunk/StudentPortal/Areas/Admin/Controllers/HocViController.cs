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
    public class HocViController : Controller
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HocVi/

        //[Authorize(Roles="HocVi.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HocVi//Read

        //[Authorize(Roles="HocVi.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.PLAN_HocVi.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HocVi/Details/5

        //[Authorize(Roles="HocVi.Details")]
        public ActionResult Details(int id = 0)
        {
            PLAN_HocVi plan_hocvi = db.PLAN_HocVi.Find(id);
            if (plan_hocvi == null)
            {
                return HttpNotFound();
            }
            return View(plan_hocvi);
        }

        //
        // GET: /Admin/HocVi/Create

        //[Authorize(Roles="HocVi.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/HocVi/Create

        [HttpPost]
        //[Authorize(Roles="HocVi.Create")]
        public ActionResult Create(PLAN_HocVi plan_hocvi)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_HocVi.Add(plan_hocvi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plan_hocvi);
        }

        //
        // GET: /Admin/HocVi/Edit/5
        //[Authorize(Roles="HocVi.Edit")]
        public ActionResult Edit(int id = 0)
        {
            PLAN_HocVi plan_hocvi = db.PLAN_HocVi.Find(id);
            if (plan_hocvi == null)
            {
                return HttpNotFound();
            }
            return View(plan_hocvi);
        }

        //
        // POST: /Admin/HocVi/Edit/5

        [HttpPost]
        //[Authorize(Roles="HocVi.Edit")]
        public ActionResult Edit(PLAN_HocVi plan_hocvi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_hocvi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan_hocvi);
        }

        //
        // GET: /Admin/HocVi/Delete/5

        //[Authorize(Roles="HocVi.Delete")]
        public ActionResult Delete(int id = 0)
        {
            PLAN_HocVi plan_hocvi = db.PLAN_HocVi.Find(id);
            if (plan_hocvi == null)
            {
                return HttpNotFound();
            }
            return View(plan_hocvi);
        }

        //
        // POST: /Admin/HocVi/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HocVi.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAN_HocVi plan_hocvi = db.PLAN_HocVi.Find(id);
            db.PLAN_HocVi.Remove(plan_hocvi);
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