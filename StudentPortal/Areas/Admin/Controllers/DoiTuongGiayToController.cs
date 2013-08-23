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
    public class DoiTuongGiayToController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/DoiTuongGiayTo/

        //[Authorize(Roles="DoiTuongGiayTo.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DoiTuongGiayTo//Read

        //[Authorize(Roles="DoiTuongGiayTo.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_doituonggiayto = db.STU_DoiTuongGiayto.Include(s => s.STU_LoaiGiayTo);
            return Json(stu_doituonggiayto.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DoiTuongGiayTo/Details/5

        //[Authorize(Roles="DoiTuongGiayTo.Details")]
        public ActionResult Details(string id = null)
        {
            STU_DoiTuongGiayto stu_doituonggiayto = db.STU_DoiTuongGiayto.Find(id);
            if (stu_doituonggiayto == null)
            {
                return HttpNotFound();
            }
            return View(stu_doituonggiayto);
        }

        //
        // GET: /Admin/DoiTuongGiayTo/Create

        //[Authorize(Roles="DoiTuongGiayTo.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to");
            return View();
        }

        //
        // POST: /Admin/DoiTuongGiayTo/Create

        [HttpPost]
        //[Authorize(Roles="DoiTuongGiayTo.Create")]
        public ActionResult Create(STU_DoiTuongGiayto stu_doituonggiayto)
        {
            if (ModelState.IsValid)
            {
                db.STU_DoiTuongGiayto.Add(stu_doituonggiayto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to", stu_doituonggiayto.ID_giay_to);
            return View(stu_doituonggiayto);
        }

        //
        // GET: /Admin/DoiTuongGiayTo/Edit/5
        //[Authorize(Roles="DoiTuongGiayTo.Edit")]
        public ActionResult Edit(string id = null)
        {
            STU_DoiTuongGiayto stu_doituonggiayto = db.STU_DoiTuongGiayto.Find(id);
            if (stu_doituonggiayto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to", stu_doituonggiayto.ID_giay_to);
            return View(stu_doituonggiayto);
        }

        //
        // POST: /Admin/DoiTuongGiayTo/Edit/5

        [HttpPost]
        //[Authorize(Roles="DoiTuongGiayTo.Edit")]
        public ActionResult Edit(STU_DoiTuongGiayto stu_doituonggiayto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_doituonggiayto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to", stu_doituonggiayto.ID_giay_to);
            return View(stu_doituonggiayto);
        }

        //
        // GET: /Admin/DoiTuongGiayTo/Delete/5

        //[Authorize(Roles="DoiTuongGiayTo.Delete")]
        public ActionResult Delete(string id = null)
        {
            STU_DoiTuongGiayto stu_doituonggiayto = db.STU_DoiTuongGiayto.Find(id);
            if (stu_doituonggiayto == null)
            {
                return HttpNotFound();
            }
            return View(stu_doituonggiayto);
        }

        //
        // POST: /Admin/DoiTuongGiayTo/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DoiTuongGiayTo.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(string id)
        {
            STU_DoiTuongGiayto stu_doituonggiayto = db.STU_DoiTuongGiayto.Find(id);
            db.STU_DoiTuongGiayto.Remove(stu_doituonggiayto);
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