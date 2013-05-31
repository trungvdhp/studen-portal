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
    public class CapRenLuyenController : BasicController
    {
        private DHHH db = new DHHH();

        //
        // GET: /Admin/CapRenLuyen/

        //[Authorize(Roles="CapRenLuyen.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/CapRenLuyen//Read

        //[Authorize(Roles="CapRenLuyen.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_CapRenLuyen.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/CapRenLuyen/Details/5

        //[Authorize(Roles="CapRenLuyen.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_CapRenLuyen stu_caprenluyen = db.STU_CapRenLuyen.Find(id);
            if (stu_caprenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_caprenluyen);
        }

        //
        // GET: /Admin/CapRenLuyen/Create

        //[Authorize(Roles="CapRenLuyen.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/CapRenLuyen/Create

        [HttpPost]
        //[Authorize(Roles="CapRenLuyen.Create")]
        public ActionResult Create(STU_CapRenLuyen stu_caprenluyen)
        {
            if (ModelState.IsValid)
            {
                db.STU_CapRenLuyen.Add(stu_caprenluyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_caprenluyen);
        }

        //
        // GET: /Admin/CapRenLuyen/Edit/5
        //[Authorize(Roles="CapRenLuyen.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_CapRenLuyen stu_caprenluyen = db.STU_CapRenLuyen.Find(id);
            if (stu_caprenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_caprenluyen);
        }

        //
        // POST: /Admin/CapRenLuyen/Edit/5

        [HttpPost]
        //[Authorize(Roles="CapRenLuyen.Edit")]
        public ActionResult Edit(STU_CapRenLuyen stu_caprenluyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_caprenluyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_caprenluyen);
        }

        //
        // GET: /Admin/CapRenLuyen/Delete/5

        //[Authorize(Roles="CapRenLuyen.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_CapRenLuyen stu_caprenluyen = db.STU_CapRenLuyen.Find(id);
            if (stu_caprenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_caprenluyen);
        }

        //
        // POST: /Admin/CapRenLuyen/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="CapRenLuyen.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_CapRenLuyen stu_caprenluyen = db.STU_CapRenLuyen.Find(id);
            db.STU_CapRenLuyen.Remove(stu_caprenluyen);
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