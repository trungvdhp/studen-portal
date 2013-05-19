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
    public class ChucDanhController : Controller
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/ChucDanh/

        //[Authorize(Roles="ChucDanh.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/ChucDanh//Read

        //[Authorize(Roles="ChucDanh.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.PLAN_ChucDanh.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/ChucDanh/Details/5

        //[Authorize(Roles="ChucDanh.Details")]
        public ActionResult Details(int id = 0)
        {
            PLAN_ChucDanh plan_chucdanh = db.PLAN_ChucDanh.Find(id);
            if (plan_chucdanh == null)
            {
                return HttpNotFound();
            }
            return View(plan_chucdanh);
        }

        //
        // GET: /Admin/ChucDanh/Create

        //[Authorize(Roles="ChucDanh.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/ChucDanh/Create

        [HttpPost]
        //[Authorize(Roles="ChucDanh.Create")]
        public ActionResult Create(PLAN_ChucDanh plan_chucdanh)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_ChucDanh.Add(plan_chucdanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plan_chucdanh);
        }

        //
        // GET: /Admin/ChucDanh/Edit/5
        //[Authorize(Roles="ChucDanh.Edit")]
        public ActionResult Edit(int id = 0)
        {
            PLAN_ChucDanh plan_chucdanh = db.PLAN_ChucDanh.Find(id);
            if (plan_chucdanh == null)
            {
                return HttpNotFound();
            }
            return View(plan_chucdanh);
        }

        //
        // POST: /Admin/ChucDanh/Edit/5

        [HttpPost]
        //[Authorize(Roles="ChucDanh.Edit")]
        public ActionResult Edit(PLAN_ChucDanh plan_chucdanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_chucdanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan_chucdanh);
        }

        //
        // GET: /Admin/ChucDanh/Delete/5

        //[Authorize(Roles="ChucDanh.Delete")]
        public ActionResult Delete(int id = 0)
        {
            PLAN_ChucDanh plan_chucdanh = db.PLAN_ChucDanh.Find(id);
            if (plan_chucdanh == null)
            {
                return HttpNotFound();
            }
            return View(plan_chucdanh);
        }

        //
        // POST: /Admin/ChucDanh/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="ChucDanh.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAN_ChucDanh plan_chucdanh = db.PLAN_ChucDanh.Find(id);
            db.PLAN_ChucDanh.Remove(plan_chucdanh);
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