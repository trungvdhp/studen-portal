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
    public class ChuyenNganhController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/ChuyenNganh/

        [Authorize(Roles="ChuyenNganh.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/ChuyenNganh//Read

        [Authorize(Roles="ChuyenNganh.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_chuyennganh = db.STU_ChuyenNganh.Include(s => s.STU_Nganh);
            return Json(stu_chuyennganh.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/ChuyenNganh/Details/5

        [Authorize(Roles="ChuyenNganh.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_ChuyenNganh stu_chuyennganh = db.STU_ChuyenNganh.Find(id);
            if (stu_chuyennganh == null)
            {
                return HttpNotFound();
            }
            return View(stu_chuyennganh);
        }

        //
        // GET: /Admin/ChuyenNganh/Create

        [Authorize(Roles="ChuyenNganh.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_nganh = new SelectList(db.STU_Nganh, "ID_nganh", "Ma_nganh");
            return View();
        }

        //
        // POST: /Admin/ChuyenNganh/Create

        [HttpPost]
        [Authorize(Roles="ChuyenNganh.Create")]
        public ActionResult Create(STU_ChuyenNganh stu_chuyennganh)
        {
            if (ModelState.IsValid)
            {
                db.STU_ChuyenNganh.Add(stu_chuyennganh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_nganh = new SelectList(db.STU_Nganh, "ID_nganh", "Ma_nganh", stu_chuyennganh.ID_nganh);
            return View(stu_chuyennganh);
        }

        //
        // GET: /Admin/ChuyenNganh/Edit/5
        [Authorize(Roles="ChuyenNganh.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_ChuyenNganh stu_chuyennganh = db.STU_ChuyenNganh.Find(id);
            if (stu_chuyennganh == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_nganh = new SelectList(db.STU_Nganh, "ID_nganh", "Ma_nganh", stu_chuyennganh.ID_nganh);
            return View(stu_chuyennganh);
        }

        //
        // POST: /Admin/ChuyenNganh/Edit/5

        [HttpPost]
        [Authorize(Roles="ChuyenNganh.Edit")]
        public ActionResult Edit(STU_ChuyenNganh stu_chuyennganh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_chuyennganh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_nganh = new SelectList(db.STU_Nganh, "ID_nganh", "Ma_nganh", stu_chuyennganh.ID_nganh);
            return View(stu_chuyennganh);
        }

        //
        // GET: /Admin/ChuyenNganh/Delete/5

        [Authorize(Roles="ChuyenNganh.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_ChuyenNganh stu_chuyennganh = db.STU_ChuyenNganh.Find(id);
            if (stu_chuyennganh == null)
            {
                return HttpNotFound();
            }
            return View(stu_chuyennganh);
        }

        //
        // POST: /Admin/ChuyenNganh/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles="ChuyenNganh.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_ChuyenNganh stu_chuyennganh = db.STU_ChuyenNganh.Find(id);
            db.STU_ChuyenNganh.Remove(stu_chuyennganh);
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