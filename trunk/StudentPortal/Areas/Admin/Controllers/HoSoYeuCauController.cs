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
    public class HoSoYeuCauController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HoSoYeuCau/

        //[Authorize(Roles="HoSoYeuCau.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HoSoYeuCau//Read

        //[Authorize(Roles="HoSoYeuCau.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_hosoyeucau = db.STU_HoSoYeucau.Include(s => s.STU_He);
            return Json(stu_hosoyeucau.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HoSoYeuCau/Details/5

        //[Authorize(Roles="HoSoYeuCau.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_HoSoYeucau stu_hosoyeucau = db.STU_HoSoYeucau.Find(id);
            if (stu_hosoyeucau == null)
            {
                return HttpNotFound();
            }
            return View(stu_hosoyeucau);
        }

        //
        // GET: /Admin/HoSoYeuCau/Create

        //[Authorize(Roles="HoSoYeuCau.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he");
            return View();
        }

        //
        // POST: /Admin/HoSoYeuCau/Create

        [HttpPost]
        //[Authorize(Roles="HoSoYeuCau.Create")]
        public ActionResult Create(STU_HoSoYeucau stu_hosoyeucau)
        {
            if (ModelState.IsValid)
            {
                db.STU_HoSoYeucau.Add(stu_hosoyeucau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", stu_hosoyeucau.ID_he);
            return View(stu_hosoyeucau);
        }

        //
        // GET: /Admin/HoSoYeuCau/Edit/5
        //[Authorize(Roles="HoSoYeuCau.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_HoSoYeucau stu_hosoyeucau = db.STU_HoSoYeucau.Find(id);
            if (stu_hosoyeucau == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", stu_hosoyeucau.ID_he);
            return View(stu_hosoyeucau);
        }

        //
        // POST: /Admin/HoSoYeuCau/Edit/5

        [HttpPost]
        //[Authorize(Roles="HoSoYeuCau.Edit")]
        public ActionResult Edit(STU_HoSoYeucau stu_hosoyeucau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_hosoyeucau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_he = new SelectList(db.STU_He, "ID_he", "Ma_he", stu_hosoyeucau.ID_he);
            return View(stu_hosoyeucau);
        }

        //
        // GET: /Admin/HoSoYeuCau/Delete/5

        //[Authorize(Roles="HoSoYeuCau.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_HoSoYeucau stu_hosoyeucau = db.STU_HoSoYeucau.Find(id);
            if (stu_hosoyeucau == null)
            {
                return HttpNotFound();
            }
            return View(stu_hosoyeucau);
        }

        //
        // POST: /Admin/HoSoYeuCau/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HoSoYeuCau.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_HoSoYeucau stu_hosoyeucau = db.STU_HoSoYeucau.Find(id);
            db.STU_HoSoYeucau.Remove(stu_hosoyeucau);
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