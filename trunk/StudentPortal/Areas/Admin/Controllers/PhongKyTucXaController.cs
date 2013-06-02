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
    public class PhongKyTucXaController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/PhongKyTucXa/

        //[Authorize(Roles="PhongKyTucXa.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/PhongKyTucXa//Read

        //[Authorize(Roles="PhongKyTucXa.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_phongkytucxa = db.STU_PhongKyTucXa.Include(s => s.STU_ToaNhaKyTucXa).Include(s => s.PLAN_TANG).Include(s => s.PLAN_COSODAOTAO);
            return Json(stu_phongkytucxa.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/PhongKyTucXa/Details/5

        //[Authorize(Roles="PhongKyTucXa.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_PhongKyTucXa stu_phongkytucxa = db.STU_PhongKyTucXa.Find(id);
            if (stu_phongkytucxa == null)
            {
                return HttpNotFound();
            }
            return View(stu_phongkytucxa);
        }

        //
        // GET: /Admin/PhongKyTucXa/Create

        //[Authorize(Roles="PhongKyTucXa.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_nha_KTX = new SelectList(db.STU_ToaNhaKyTucXa, "ID_nha_ktx", "Ma_nha");
            ViewBag.ID_tang = new SelectList(db.PLAN_TANG, "ID_TANG", "Ma_tang");
            ViewBag.ID_co_so = new SelectList(db.PLAN_COSODAOTAO, "ID_co_so", "Ma_co_so");
            return View();
        }

        //
        // POST: /Admin/PhongKyTucXa/Create

        [HttpPost]
        //[Authorize(Roles="PhongKyTucXa.Create")]
        public ActionResult Create(STU_PhongKyTucXa stu_phongkytucxa)
        {
            if (ModelState.IsValid)
            {
                db.STU_PhongKyTucXa.Add(stu_phongkytucxa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_nha_KTX = new SelectList(db.STU_ToaNhaKyTucXa, "ID_nha_ktx", "Ma_nha", stu_phongkytucxa.ID_nha_KTX);
            ViewBag.ID_tang = new SelectList(db.PLAN_TANG, "ID_TANG", "Ma_tang", stu_phongkytucxa.ID_tang);
            ViewBag.ID_co_so = new SelectList(db.PLAN_COSODAOTAO, "ID_co_so", "Ma_co_so", stu_phongkytucxa.ID_co_so);
            return View(stu_phongkytucxa);
        }

        //
        // GET: /Admin/PhongKyTucXa/Edit/5
        //[Authorize(Roles="PhongKyTucXa.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_PhongKyTucXa stu_phongkytucxa = db.STU_PhongKyTucXa.Find(id);
            if (stu_phongkytucxa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_nha_KTX = new SelectList(db.STU_ToaNhaKyTucXa, "ID_nha_ktx", "Ma_nha", stu_phongkytucxa.ID_nha_KTX);
            ViewBag.ID_tang = new SelectList(db.PLAN_TANG, "ID_TANG", "Ma_tang", stu_phongkytucxa.ID_tang);
            ViewBag.ID_co_so = new SelectList(db.PLAN_COSODAOTAO, "ID_co_so", "Ma_co_so", stu_phongkytucxa.ID_co_so);
            return View(stu_phongkytucxa);
        }

        //
        // POST: /Admin/PhongKyTucXa/Edit/5

        [HttpPost]
        //[Authorize(Roles="PhongKyTucXa.Edit")]
        public ActionResult Edit(STU_PhongKyTucXa stu_phongkytucxa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_phongkytucxa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_nha_KTX = new SelectList(db.STU_ToaNhaKyTucXa, "ID_nha_ktx", "Ma_nha", stu_phongkytucxa.ID_nha_KTX);
            ViewBag.ID_tang = new SelectList(db.PLAN_TANG, "ID_TANG", "Ma_tang", stu_phongkytucxa.ID_tang);
            ViewBag.ID_co_so = new SelectList(db.PLAN_COSODAOTAO, "ID_co_so", "Ma_co_so", stu_phongkytucxa.ID_co_so);
            return View(stu_phongkytucxa);
        }

        //
        // GET: /Admin/PhongKyTucXa/Delete/5

        //[Authorize(Roles="PhongKyTucXa.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_PhongKyTucXa stu_phongkytucxa = db.STU_PhongKyTucXa.Find(id);
            if (stu_phongkytucxa == null)
            {
                return HttpNotFound();
            }
            return View(stu_phongkytucxa);
        }

        //
        // POST: /Admin/PhongKyTucXa/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="PhongKyTucXa.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_PhongKyTucXa stu_phongkytucxa = db.STU_PhongKyTucXa.Find(id);
            db.STU_PhongKyTucXa.Remove(stu_phongkytucxa);
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