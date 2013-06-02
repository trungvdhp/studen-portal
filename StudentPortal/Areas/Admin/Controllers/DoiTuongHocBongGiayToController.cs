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
    public class DoiTuongHocBongGiayToController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/DoiTuongHocBongGiayTo/

        //[Authorize(Roles="DoiTuongHocBongGiayTo.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DoiTuongHocBongGiayTo//Read

        //[Authorize(Roles="DoiTuongHocBongGiayTo.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_doituonghocbonggiayto = db.STU_DoiTuongHocBongGiayto.Include(s => s.STU_LoaiGiayTo);
            return Json(stu_doituonghocbonggiayto.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DoiTuongHocBongGiayTo/Details/5

        //[Authorize(Roles="DoiTuongHocBongGiayTo.Details")]
        public ActionResult Details(string id = null)
        {
            STU_DoiTuongHocBongGiayto stu_doituonghocbonggiayto = db.STU_DoiTuongHocBongGiayto.Find(id);
            if (stu_doituonghocbonggiayto == null)
            {
                return HttpNotFound();
            }
            return View(stu_doituonghocbonggiayto);
        }

        //
        // GET: /Admin/DoiTuongHocBongGiayTo/Create

        //[Authorize(Roles="DoiTuongHocBongGiayTo.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to");
            return View();
        }

        //
        // POST: /Admin/DoiTuongHocBongGiayTo/Create

        [HttpPost]
        //[Authorize(Roles="DoiTuongHocBongGiayTo.Create")]
        public ActionResult Create(STU_DoiTuongHocBongGiayto stu_doituonghocbonggiayto)
        {
            if (ModelState.IsValid)
            {
                db.STU_DoiTuongHocBongGiayto.Add(stu_doituonghocbonggiayto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to", stu_doituonghocbonggiayto.ID_giay_to);
            return View(stu_doituonghocbonggiayto);
        }

        //
        // GET: /Admin/DoiTuongHocBongGiayTo/Edit/5
        //[Authorize(Roles="DoiTuongHocBongGiayTo.Edit")]
        public ActionResult Edit(string id = null)
        {
            STU_DoiTuongHocBongGiayto stu_doituonghocbonggiayto = db.STU_DoiTuongHocBongGiayto.Find(id);
            if (stu_doituonghocbonggiayto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to", stu_doituonghocbonggiayto.ID_giay_to);
            return View(stu_doituonghocbonggiayto);
        }

        //
        // POST: /Admin/DoiTuongHocBongGiayTo/Edit/5

        [HttpPost]
        //[Authorize(Roles="DoiTuongHocBongGiayTo.Edit")]
        public ActionResult Edit(STU_DoiTuongHocBongGiayto stu_doituonghocbonggiayto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_doituonghocbonggiayto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to", stu_doituonghocbonggiayto.ID_giay_to);
            return View(stu_doituonghocbonggiayto);
        }

        //
        // GET: /Admin/DoiTuongHocBongGiayTo/Delete/5

        //[Authorize(Roles="DoiTuongHocBongGiayTo.Delete")]
        public ActionResult Delete(string id = null)
        {
            STU_DoiTuongHocBongGiayto stu_doituonghocbonggiayto = db.STU_DoiTuongHocBongGiayto.Find(id);
            if (stu_doituonghocbonggiayto == null)
            {
                return HttpNotFound();
            }
            return View(stu_doituonghocbonggiayto);
        }

        //
        // POST: /Admin/DoiTuongHocBongGiayTo/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DoiTuongHocBongGiayTo.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(string id)
        {
            STU_DoiTuongHocBongGiayto stu_doituonghocbonggiayto = db.STU_DoiTuongHocBongGiayto.Find(id);
            db.STU_DoiTuongHocBongGiayto.Remove(stu_doituonghocbonggiayto);
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