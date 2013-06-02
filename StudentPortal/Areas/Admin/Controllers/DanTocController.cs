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
    public class DanTocController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/DanToc/

        //[Authorize(Roles="DanToc.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DanToc//Read

        //[Authorize(Roles="DanToc.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_DanToc.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DanToc/Details/5

        //[Authorize(Roles="DanToc.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DanToc stu_dantoc = db.STU_DanToc.Find(id);
            if (stu_dantoc == null)
            {
                return HttpNotFound();
            }
            return View(stu_dantoc);
        }

        //
        // GET: /Admin/DanToc/Create

        //[Authorize(Roles="DanToc.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/DanToc/Create

        [HttpPost]
        //[Authorize(Roles="DanToc.Create")]
        public ActionResult Create(STU_DanToc stu_dantoc)
        {
            if (ModelState.IsValid)
            {
                db.STU_DanToc.Add(stu_dantoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_dantoc);
        }

        //
        // GET: /Admin/DanToc/Edit/5
        //[Authorize(Roles="DanToc.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DanToc stu_dantoc = db.STU_DanToc.Find(id);
            if (stu_dantoc == null)
            {
                return HttpNotFound();
            }
            return View(stu_dantoc);
        }

        //
        // POST: /Admin/DanToc/Edit/5

        [HttpPost]
        //[Authorize(Roles="DanToc.Edit")]
        public ActionResult Edit(STU_DanToc stu_dantoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_dantoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_dantoc);
        }

        //
        // GET: /Admin/DanToc/Delete/5

        //[Authorize(Roles="DanToc.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DanToc stu_dantoc = db.STU_DanToc.Find(id);
            if (stu_dantoc == null)
            {
                return HttpNotFound();
            }
            return View(stu_dantoc);
        }

        //
        // POST: /Admin/DanToc/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DanToc.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DanToc stu_dantoc = db.STU_DanToc.Find(id);
            db.STU_DanToc.Remove(stu_dantoc);
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