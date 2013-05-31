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
    public class DanhHieuController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/DanhHieu/

        //[Authorize(Roles="DanhHieu.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DanhHieu//Read

        //[Authorize(Roles="DanhHieu.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_DanhHieu.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DanhHieu/Details/5

        //[Authorize(Roles="DanhHieu.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DanhHieu stu_danhhieu = db.STU_DanhHieu.Find(id);
            if (stu_danhhieu == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhhieu);
        }

        //
        // GET: /Admin/DanhHieu/Create

        //[Authorize(Roles="DanhHieu.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/DanhHieu/Create

        [HttpPost]
        //[Authorize(Roles="DanhHieu.Create")]
        public ActionResult Create(STU_DanhHieu stu_danhhieu)
        {
            if (ModelState.IsValid)
            {
                db.STU_DanhHieu.Add(stu_danhhieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_danhhieu);
        }

        //
        // GET: /Admin/DanhHieu/Edit/5
        //[Authorize(Roles="DanhHieu.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DanhHieu stu_danhhieu = db.STU_DanhHieu.Find(id);
            if (stu_danhhieu == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhhieu);
        }

        //
        // POST: /Admin/DanhHieu/Edit/5

        [HttpPost]
        //[Authorize(Roles="DanhHieu.Edit")]
        public ActionResult Edit(STU_DanhHieu stu_danhhieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_danhhieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_danhhieu);
        }

        //
        // GET: /Admin/DanhHieu/Delete/5

        //[Authorize(Roles="DanhHieu.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DanhHieu stu_danhhieu = db.STU_DanhHieu.Find(id);
            if (stu_danhhieu == null)
            {
                return HttpNotFound();
            }
            return View(stu_danhhieu);
        }

        //
        // POST: /Admin/DanhHieu/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DanhHieu.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DanhHieu stu_danhhieu = db.STU_DanhHieu.Find(id);
            db.STU_DanhHieu.Remove(stu_danhhieu);
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