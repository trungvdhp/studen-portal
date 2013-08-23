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
    public class BoMonController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/BoMon/

        //[Authorize((Roles="BoMon.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/BoMon//Read

        //[Authorize((Roles="BoMon.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.PLAN_BoMon.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/BoMon/Details/5

        //[Authorize((Roles="BoMon.Details")]
        public ActionResult Details(int id = 0)
        {
            PLAN_BoMon plan_bomon = db.PLAN_BoMon.Find(id);
            if (plan_bomon == null)
            {
                return HttpNotFound();
            }
            return View(plan_bomon);
        }

        //
        // GET: /Admin/BoMon/Create

        //[Authorize((Roles="BoMon.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/BoMon/Create

        [HttpPost]
        //[Authorize((Roles="BoMon.Create")]
        public ActionResult Create(PLAN_BoMon plan_bomon)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_BoMon.Add(plan_bomon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plan_bomon);
        }

        //
        // GET: /Admin/BoMon/Edit/5
        //[Authorize((Roles="BoMon.Edit")]
        public ActionResult Edit(int id = 0)
        {
            PLAN_BoMon plan_bomon = db.PLAN_BoMon.Find(id);
            if (plan_bomon == null)
            {
                return HttpNotFound();
            }
            return View(plan_bomon);
        }

        //
        // POST: /Admin/BoMon/Edit/5

        [HttpPost]
        //[Authorize((Roles="BoMon.Edit")]
        public ActionResult Edit(PLAN_BoMon plan_bomon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_bomon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan_bomon);
        }

        //
        // GET: /Admin/BoMon/Delete/5

        //[Authorize((Roles="BoMon.Delete")]
        public ActionResult Delete(int id = 0)
        {
            PLAN_BoMon plan_bomon = db.PLAN_BoMon.Find(id);
            if (plan_bomon == null)
            {
                return HttpNotFound();
            }
            return View(plan_bomon);
        }

        //
        // POST: /Admin/BoMon/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize((Roles="BoMon.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAN_BoMon plan_bomon = db.PLAN_BoMon.Find(id);
            db.PLAN_BoMon.Remove(plan_bomon);
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