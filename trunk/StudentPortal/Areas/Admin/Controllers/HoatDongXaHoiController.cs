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
    public class HoatDongXaHoiController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HoatDongXaHoi/

        //[Authorize(Roles="HoatDongXaHoi.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HoatDongXaHoi//Read

        //[Authorize(Roles="HoatDongXaHoi.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_hoatdongxahoi = db.STU_HoatDongXaHoi.Include(s => s.STU_HoSoSinhVien);
            return Json(stu_hoatdongxahoi.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HoatDongXaHoi/Details/5

        //[Authorize(Roles="HoatDongXaHoi.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_HoatDongXaHoi stu_hoatdongxahoi = db.STU_HoatDongXaHoi.Find(id);
            if (stu_hoatdongxahoi == null)
            {
                return HttpNotFound();
            }
            return View(stu_hoatdongxahoi);
        }

        //
        // GET: /Admin/HoatDongXaHoi/Create

        //[Authorize(Roles="HoatDongXaHoi.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv");
            return View();
        }

        //
        // POST: /Admin/HoatDongXaHoi/Create

        [HttpPost]
        //[Authorize(Roles="HoatDongXaHoi.Create")]
        public ActionResult Create(STU_HoatDongXaHoi stu_hoatdongxahoi)
        {
            if (ModelState.IsValid)
            {
                db.STU_HoatDongXaHoi.Add(stu_hoatdongxahoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_hoatdongxahoi.ID_sv);
            return View(stu_hoatdongxahoi);
        }

        //
        // GET: /Admin/HoatDongXaHoi/Edit/5
        //[Authorize(Roles="HoatDongXaHoi.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_HoatDongXaHoi stu_hoatdongxahoi = db.STU_HoatDongXaHoi.Find(id);
            if (stu_hoatdongxahoi == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_hoatdongxahoi.ID_sv);
            return View(stu_hoatdongxahoi);
        }

        //
        // POST: /Admin/HoatDongXaHoi/Edit/5

        [HttpPost]
        //[Authorize(Roles="HoatDongXaHoi.Edit")]
        public ActionResult Edit(STU_HoatDongXaHoi stu_hoatdongxahoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_hoatdongxahoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_hoatdongxahoi.ID_sv);
            return View(stu_hoatdongxahoi);
        }

        //
        // GET: /Admin/HoatDongXaHoi/Delete/5

        //[Authorize(Roles="HoatDongXaHoi.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_HoatDongXaHoi stu_hoatdongxahoi = db.STU_HoatDongXaHoi.Find(id);
            if (stu_hoatdongxahoi == null)
            {
                return HttpNotFound();
            }
            return View(stu_hoatdongxahoi);
        }

        //
        // POST: /Admin/HoatDongXaHoi/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HoatDongXaHoi.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_HoatDongXaHoi stu_hoatdongxahoi = db.STU_HoatDongXaHoi.Find(id);
            db.STU_HoatDongXaHoi.Remove(stu_hoatdongxahoi);
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