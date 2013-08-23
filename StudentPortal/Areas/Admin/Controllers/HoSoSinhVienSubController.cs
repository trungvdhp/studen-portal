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
    public class HoSoSinhVienSubController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HoSoSinhVienSub/

        //[Authorize(Roles="HoSoSinhVienSub.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HoSoSinhVienSub//Read

        //[Authorize(Roles="HoSoSinhVienSub.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_HoSoSinhVienSub.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HoSoSinhVienSub/Details/5

        //[Authorize(Roles="HoSoSinhVienSub.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_HoSoSinhVienSub stu_hososinhviensub = db.STU_HoSoSinhVienSub.Find(id);
            if (stu_hososinhviensub == null)
            {
                return HttpNotFound();
            }
            return View(stu_hososinhviensub);
        }

        //
        // GET: /Admin/HoSoSinhVienSub/Create

        //[Authorize(Roles="HoSoSinhVienSub.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/HoSoSinhVienSub/Create

        [HttpPost]
        //[Authorize(Roles="HoSoSinhVienSub.Create")]
        public ActionResult Create(STU_HoSoSinhVienSub stu_hososinhviensub)
        {
            if (ModelState.IsValid)
            {
                db.STU_HoSoSinhVienSub.Add(stu_hososinhviensub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_hososinhviensub);
        }

        //
        // GET: /Admin/HoSoSinhVienSub/Edit/5
        //[Authorize(Roles="HoSoSinhVienSub.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_HoSoSinhVienSub stu_hososinhviensub = db.STU_HoSoSinhVienSub.Find(id);
            if (stu_hososinhviensub == null)
            {
                return HttpNotFound();
            }
            return View(stu_hososinhviensub);
        }

        //
        // POST: /Admin/HoSoSinhVienSub/Edit/5

        [HttpPost]
        //[Authorize(Roles="HoSoSinhVienSub.Edit")]
        public ActionResult Edit(STU_HoSoSinhVienSub stu_hososinhviensub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_hososinhviensub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_hososinhviensub);
        }

        //
        // GET: /Admin/HoSoSinhVienSub/Delete/5

        //[Authorize(Roles="HoSoSinhVienSub.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_HoSoSinhVienSub stu_hososinhviensub = db.STU_HoSoSinhVienSub.Find(id);
            if (stu_hososinhviensub == null)
            {
                return HttpNotFound();
            }
            return View(stu_hososinhviensub);
        }

        //
        // POST: /Admin/HoSoSinhVienSub/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HoSoSinhVienSub.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_HoSoSinhVienSub stu_hososinhviensub = db.STU_HoSoSinhVienSub.Find(id);
            db.STU_HoSoSinhVienSub.Remove(stu_hososinhviensub);
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