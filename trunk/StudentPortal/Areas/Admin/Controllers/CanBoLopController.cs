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
    public class CanBoLopController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/CanBoLop/

        //[Authorize(Roles="CanBoLop.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/CanBoLop//Read

        //[Authorize(Roles="CanBoLop.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_CanBoLop.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/CanBoLop/Details/5

        //[Authorize(Roles="CanBoLop.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_CanBoLop stu_canbolop = db.STU_CanBoLop.Find(id);
            if (stu_canbolop == null)
            {
                return HttpNotFound();
            }
            return View(stu_canbolop);
        }

        //
        // GET: /Admin/CanBoLop/Create

        //[Authorize(Roles="CanBoLop.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/CanBoLop/Create

        [HttpPost]
        //[Authorize(Roles="CanBoLop.Create")]
        public ActionResult Create(STU_CanBoLop stu_canbolop)
        {
            if (ModelState.IsValid)
            {
                db.STU_CanBoLop.Add(stu_canbolop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_canbolop);
        }

        //
        // GET: /Admin/CanBoLop/Edit/5
        //[Authorize(Roles="CanBoLop.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_CanBoLop stu_canbolop = db.STU_CanBoLop.Find(id);
            if (stu_canbolop == null)
            {
                return HttpNotFound();
            }
            return View(stu_canbolop);
        }

        //
        // POST: /Admin/CanBoLop/Edit/5

        [HttpPost]
        //[Authorize(Roles="CanBoLop.Edit")]
        public ActionResult Edit(STU_CanBoLop stu_canbolop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_canbolop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_canbolop);
        }

        //
        // GET: /Admin/CanBoLop/Delete/5

        //[Authorize(Roles="CanBoLop.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_CanBoLop stu_canbolop = db.STU_CanBoLop.Find(id);
            if (stu_canbolop == null)
            {
                return HttpNotFound();
            }
            return View(stu_canbolop);
        }

        //
        // POST: /Admin/CanBoLop/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="CanBoLop.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_CanBoLop stu_canbolop = db.STU_CanBoLop.Find(id);
            db.STU_CanBoLop.Remove(stu_canbolop);
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