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
    public class KhuVucController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/KhuVuc/

        //[Authorize(Roles="KhuVuc.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/KhuVuc//Read

        //[Authorize(Roles="KhuVuc.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_KhuVuc.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/KhuVuc/Details/5

        //[Authorize(Roles="KhuVuc.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_KhuVuc stu_khuvuc = db.STU_KhuVuc.Find(id);
            if (stu_khuvuc == null)
            {
                return HttpNotFound();
            }
            return View(stu_khuvuc);
        }

        //
        // GET: /Admin/KhuVuc/Create

        //[Authorize(Roles="KhuVuc.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/KhuVuc/Create

        [HttpPost]
        //[Authorize(Roles="KhuVuc.Create")]
        public ActionResult Create(STU_KhuVuc stu_khuvuc)
        {
            if (ModelState.IsValid)
            {
                db.STU_KhuVuc.Add(stu_khuvuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_khuvuc);
        }

        //
        // GET: /Admin/KhuVuc/Edit/5
        //[Authorize(Roles="KhuVuc.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_KhuVuc stu_khuvuc = db.STU_KhuVuc.Find(id);
            if (stu_khuvuc == null)
            {
                return HttpNotFound();
            }
            return View(stu_khuvuc);
        }

        //
        // POST: /Admin/KhuVuc/Edit/5

        [HttpPost]
        //[Authorize(Roles="KhuVuc.Edit")]
        public ActionResult Edit(STU_KhuVuc stu_khuvuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_khuvuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_khuvuc);
        }

        //
        // GET: /Admin/KhuVuc/Delete/5

        //[Authorize(Roles="KhuVuc.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_KhuVuc stu_khuvuc = db.STU_KhuVuc.Find(id);
            if (stu_khuvuc == null)
            {
                return HttpNotFound();
            }
            return View(stu_khuvuc);
        }

        //
        // POST: /Admin/KhuVuc/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="KhuVuc.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_KhuVuc stu_khuvuc = db.STU_KhuVuc.Find(id);
            db.STU_KhuVuc.Remove(stu_khuvuc);
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