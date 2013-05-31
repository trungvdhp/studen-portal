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
    public class CapKhenThuongKyLuatController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/CapKhenThuongKyLuat/

        //[Authorize(Roles="CapKhenThuongKyLuat.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/CapKhenThuongKyLuat//Read

        //[Authorize(Roles="CapKhenThuongKyLuat.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_CapKhenThuongKyLuat.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/CapKhenThuongKyLuat/Details/5

        //[Authorize(Roles="CapKhenThuongKyLuat.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_CapKhenThuongKyLuat stu_capkhenthuongkyluat = db.STU_CapKhenThuongKyLuat.Find(id);
            if (stu_capkhenthuongkyluat == null)
            {
                return HttpNotFound();
            }
            return View(stu_capkhenthuongkyluat);
        }

        //
        // GET: /Admin/CapKhenThuongKyLuat/Create

        //[Authorize(Roles="CapKhenThuongKyLuat.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/CapKhenThuongKyLuat/Create

        [HttpPost]
        //[Authorize(Roles="CapKhenThuongKyLuat.Create")]
        public ActionResult Create(STU_CapKhenThuongKyLuat stu_capkhenthuongkyluat)
        {
            if (ModelState.IsValid)
            {
                db.STU_CapKhenThuongKyLuat.Add(stu_capkhenthuongkyluat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_capkhenthuongkyluat);
        }

        //
        // GET: /Admin/CapKhenThuongKyLuat/Edit/5
        //[Authorize(Roles="CapKhenThuongKyLuat.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_CapKhenThuongKyLuat stu_capkhenthuongkyluat = db.STU_CapKhenThuongKyLuat.Find(id);
            if (stu_capkhenthuongkyluat == null)
            {
                return HttpNotFound();
            }
            return View(stu_capkhenthuongkyluat);
        }

        //
        // POST: /Admin/CapKhenThuongKyLuat/Edit/5

        [HttpPost]
        //[Authorize(Roles="CapKhenThuongKyLuat.Edit")]
        public ActionResult Edit(STU_CapKhenThuongKyLuat stu_capkhenthuongkyluat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_capkhenthuongkyluat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_capkhenthuongkyluat);
        }

        //
        // GET: /Admin/CapKhenThuongKyLuat/Delete/5

        //[Authorize(Roles="CapKhenThuongKyLuat.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_CapKhenThuongKyLuat stu_capkhenthuongkyluat = db.STU_CapKhenThuongKyLuat.Find(id);
            if (stu_capkhenthuongkyluat == null)
            {
                return HttpNotFound();
            }
            return View(stu_capkhenthuongkyluat);
        }

        //
        // POST: /Admin/CapKhenThuongKyLuat/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="CapKhenThuongKyLuat.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_CapKhenThuongKyLuat stu_capkhenthuongkyluat = db.STU_CapKhenThuongKyLuat.Find(id);
            db.STU_CapKhenThuongKyLuat.Remove(stu_capkhenthuongkyluat);
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