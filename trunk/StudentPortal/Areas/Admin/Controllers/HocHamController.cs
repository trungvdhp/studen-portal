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
    public class HocHamController : Controller
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HocHam/

        //[Authorize(Roles="HocHam.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HocHam//Read

        //[Authorize(Roles="HocHam.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.PLAN_HocHam.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HocHam/Details/5

        //[Authorize(Roles="HocHam.Details")]
        public ActionResult Details(int id = 0)
        {
            PLAN_HocHam plan_hocham = db.PLAN_HocHam.Find(id);
            if (plan_hocham == null)
            {
                return HttpNotFound();
            }
            return View(plan_hocham);
        }

        //
        // GET: /Admin/HocHam/Create

        //[Authorize(Roles="HocHam.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/HocHam/Create

        [HttpPost]
        //[Authorize(Roles="HocHam.Create")]
        public ActionResult Create(PLAN_HocHam plan_hocham)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_HocHam.Add(plan_hocham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plan_hocham);
        }

        //
        // GET: /Admin/HocHam/Edit/5
        //[Authorize(Roles="HocHam.Edit")]
        public ActionResult Edit(int id = 0)
        {
            PLAN_HocHam plan_hocham = db.PLAN_HocHam.Find(id);
            if (plan_hocham == null)
            {
                return HttpNotFound();
            }
            return View(plan_hocham);
        }

        //
        // POST: /Admin/HocHam/Edit/5

        [HttpPost]
        //[Authorize(Roles="HocHam.Edit")]
        public ActionResult Edit(PLAN_HocHam plan_hocham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_hocham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan_hocham);
        }

        //
        // GET: /Admin/HocHam/Delete/5

        //[Authorize(Roles="HocHam.Delete")]
        public ActionResult Delete(int id = 0)
        {
            PLAN_HocHam plan_hocham = db.PLAN_HocHam.Find(id);
            if (plan_hocham == null)
            {
                return HttpNotFound();
            }
            return View(plan_hocham);
        }

        //
        // POST: /Admin/HocHam/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HocHam.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAN_HocHam plan_hocham = db.PLAN_HocHam.Find(id);
            db.PLAN_HocHam.Remove(plan_hocham);
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