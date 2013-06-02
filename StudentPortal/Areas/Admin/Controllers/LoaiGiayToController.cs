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
    public class LoaiGiayToController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/LoaiGiayTo/

        //[Authorize(Roles="LoaiGiayTo.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/LoaiGiayTo//Read

        //[Authorize(Roles="LoaiGiayTo.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_LoaiGiayTo.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/LoaiGiayTo/Details/5

        //[Authorize(Roles="LoaiGiayTo.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_LoaiGiayTo stu_loaigiayto = db.STU_LoaiGiayTo.Find(id);
            if (stu_loaigiayto == null)
            {
                return HttpNotFound();
            }
            return View(stu_loaigiayto);
        }

        //
        // GET: /Admin/LoaiGiayTo/Create

        //[Authorize(Roles="LoaiGiayTo.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/LoaiGiayTo/Create

        [HttpPost]
        //[Authorize(Roles="LoaiGiayTo.Create")]
        public ActionResult Create(STU_LoaiGiayTo stu_loaigiayto)
        {
            if (ModelState.IsValid)
            {
                db.STU_LoaiGiayTo.Add(stu_loaigiayto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_loaigiayto);
        }

        //
        // GET: /Admin/LoaiGiayTo/Edit/5
        //[Authorize(Roles="LoaiGiayTo.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_LoaiGiayTo stu_loaigiayto = db.STU_LoaiGiayTo.Find(id);
            if (stu_loaigiayto == null)
            {
                return HttpNotFound();
            }
            return View(stu_loaigiayto);
        }

        //
        // POST: /Admin/LoaiGiayTo/Edit/5

        [HttpPost]
        //[Authorize(Roles="LoaiGiayTo.Edit")]
        public ActionResult Edit(STU_LoaiGiayTo stu_loaigiayto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_loaigiayto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_loaigiayto);
        }

        //
        // GET: /Admin/LoaiGiayTo/Delete/5

        //[Authorize(Roles="LoaiGiayTo.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_LoaiGiayTo stu_loaigiayto = db.STU_LoaiGiayTo.Find(id);
            if (stu_loaigiayto == null)
            {
                return HttpNotFound();
            }
            return View(stu_loaigiayto);
        }

        //
        // POST: /Admin/LoaiGiayTo/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="LoaiGiayTo.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_LoaiGiayTo stu_loaigiayto = db.STU_LoaiGiayTo.Find(id);
            db.STU_LoaiGiayTo.Remove(stu_loaigiayto);
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