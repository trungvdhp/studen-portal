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
    public class NoiNgoaiTruController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/NoiNgoaiTru/

        //[Authorize(Roles="NoiNgoaiTru.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/NoiNgoaiTru//Read

        //[Authorize(Roles="NoiNgoaiTru.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_noingoaitru = db.STU_NoiNgoaiTru.Include(s => s.STU_PhongKyTucXa).Include(s => s.STU_Phuong);
            return Json(stu_noingoaitru.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/NoiNgoaiTru/Details/5

        //[Authorize(Roles="NoiNgoaiTru.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_NoiNgoaiTru stu_noingoaitru = db.STU_NoiNgoaiTru.Find(id);
            if (stu_noingoaitru == null)
            {
                return HttpNotFound();
            }
            return View(stu_noingoaitru);
        }

        //
        // GET: /Admin/NoiNgoaiTru/Create

        //[Authorize(Roles="NoiNgoaiTru.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_phong_ktx = new SelectList(db.STU_PhongKyTucXa, "ID_phong_KTX", "So_phong_KTX");
            ViewBag.ID_phuong = new SelectList(db.STU_Phuong, "ID_phuong", "Ten_phuong");
            return View();
        }

        //
        // POST: /Admin/NoiNgoaiTru/Create

        [HttpPost]
        //[Authorize(Roles="NoiNgoaiTru.Create")]
        public ActionResult Create(STU_NoiNgoaiTru stu_noingoaitru)
        {
            if (ModelState.IsValid)
            {
                db.STU_NoiNgoaiTru.Add(stu_noingoaitru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_phong_ktx = new SelectList(db.STU_PhongKyTucXa, "ID_phong_KTX", "So_phong_KTX", stu_noingoaitru.ID_phong_ktx);
            ViewBag.ID_phuong = new SelectList(db.STU_Phuong, "ID_phuong", "Ten_phuong", stu_noingoaitru.ID_phuong);
            return View(stu_noingoaitru);
        }

        //
        // GET: /Admin/NoiNgoaiTru/Edit/5
        //[Authorize(Roles="NoiNgoaiTru.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_NoiNgoaiTru stu_noingoaitru = db.STU_NoiNgoaiTru.Find(id);
            if (stu_noingoaitru == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_phong_ktx = new SelectList(db.STU_PhongKyTucXa, "ID_phong_KTX", "So_phong_KTX", stu_noingoaitru.ID_phong_ktx);
            ViewBag.ID_phuong = new SelectList(db.STU_Phuong, "ID_phuong", "Ten_phuong", stu_noingoaitru.ID_phuong);
            return View(stu_noingoaitru);
        }

        //
        // POST: /Admin/NoiNgoaiTru/Edit/5

        [HttpPost]
        //[Authorize(Roles="NoiNgoaiTru.Edit")]
        public ActionResult Edit(STU_NoiNgoaiTru stu_noingoaitru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_noingoaitru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_phong_ktx = new SelectList(db.STU_PhongKyTucXa, "ID_phong_KTX", "So_phong_KTX", stu_noingoaitru.ID_phong_ktx);
            ViewBag.ID_phuong = new SelectList(db.STU_Phuong, "ID_phuong", "Ten_phuong", stu_noingoaitru.ID_phuong);
            return View(stu_noingoaitru);
        }

        //
        // GET: /Admin/NoiNgoaiTru/Delete/5

        //[Authorize(Roles="NoiNgoaiTru.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_NoiNgoaiTru stu_noingoaitru = db.STU_NoiNgoaiTru.Find(id);
            if (stu_noingoaitru == null)
            {
                return HttpNotFound();
            }
            return View(stu_noingoaitru);
        }

        //
        // POST: /Admin/NoiNgoaiTru/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="NoiNgoaiTru.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_NoiNgoaiTru stu_noingoaitru = db.STU_NoiNgoaiTru.Find(id);
            db.STU_NoiNgoaiTru.Remove(stu_noingoaitru);
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