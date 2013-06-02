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
    public class HeChuyenNganhController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HeChuyenNganh/

        //[Authorize(Roles="HeChuyenNganh.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HeChuyenNganh//Read

        //[Authorize(Roles="HeChuyenNganh.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_hechuyennganh = db.STU_HeChuyenNganh.Include(s => s.STU_ChuyenNganh);
            return Json(stu_hechuyennganh.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HeChuyenNganh/Details/5

        //[Authorize(Roles="HeChuyenNganh.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_HeChuyenNganh stu_hechuyennganh = db.STU_HeChuyenNganh.Find(id);
            if (stu_hechuyennganh == null)
            {
                return HttpNotFound();
            }
            return View(stu_hechuyennganh);
        }

        //
        // GET: /Admin/HeChuyenNganh/Create

        //[Authorize(Roles="HeChuyenNganh.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Ma_chuyen_nganh");
            return View();
        }

        //
        // POST: /Admin/HeChuyenNganh/Create

        [HttpPost]
        //[Authorize(Roles="HeChuyenNganh.Create")]
        public ActionResult Create(STU_HeChuyenNganh stu_hechuyennganh)
        {
            if (ModelState.IsValid)
            {
                db.STU_HeChuyenNganh.Add(stu_hechuyennganh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Ma_chuyen_nganh", stu_hechuyennganh.ID_chuyen_nganh);
            return View(stu_hechuyennganh);
        }

        //
        // GET: /Admin/HeChuyenNganh/Edit/5
        //[Authorize(Roles="HeChuyenNganh.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_HeChuyenNganh stu_hechuyennganh = db.STU_HeChuyenNganh.Find(id);
            if (stu_hechuyennganh == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Ma_chuyen_nganh", stu_hechuyennganh.ID_chuyen_nganh);
            return View(stu_hechuyennganh);
        }

        //
        // POST: /Admin/HeChuyenNganh/Edit/5

        [HttpPost]
        //[Authorize(Roles="HeChuyenNganh.Edit")]
        public ActionResult Edit(STU_HeChuyenNganh stu_hechuyennganh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_hechuyennganh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_chuyen_nganh = new SelectList(db.STU_ChuyenNganh, "ID_chuyen_nganh", "Ma_chuyen_nganh", stu_hechuyennganh.ID_chuyen_nganh);
            return View(stu_hechuyennganh);
        }

        //
        // GET: /Admin/HeChuyenNganh/Delete/5

        //[Authorize(Roles="HeChuyenNganh.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_HeChuyenNganh stu_hechuyennganh = db.STU_HeChuyenNganh.Find(id);
            if (stu_hechuyennganh == null)
            {
                return HttpNotFound();
            }
            return View(stu_hechuyennganh);
        }

        //
        // POST: /Admin/HeChuyenNganh/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HeChuyenNganh.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_HeChuyenNganh stu_hechuyennganh = db.STU_HeChuyenNganh.Find(id);
            db.STU_HeChuyenNganh.Remove(stu_hechuyennganh);
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