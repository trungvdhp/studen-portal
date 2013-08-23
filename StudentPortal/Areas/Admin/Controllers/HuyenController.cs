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
    public class HuyenController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/Huyen/

        //[Authorize(Roles="Huyen.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/Huyen//Read

        //[Authorize(Roles="Huyen.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_huyen = db.STU_Huyen.Include(s => s.STU_Tinh);
            return Json(stu_huyen.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/Huyen/Details/5

        //[Authorize(Roles="Huyen.Details")]
        public ActionResult Details(string id = null)
        {
            STU_Huyen stu_huyen = db.STU_Huyen.Find(id);
            if (stu_huyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_huyen);
        }

        //
        // GET: /Admin/Huyen/Create

        //[Authorize(Roles="Huyen.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_tinh = new SelectList(db.STU_Tinh, "ID_tinh", "Ten_tinh");
            return View();
        }

        //
        // POST: /Admin/Huyen/Create

        [HttpPost]
        //[Authorize(Roles="Huyen.Create")]
        public ActionResult Create(STU_Huyen stu_huyen)
        {
            if (ModelState.IsValid)
            {
                db.STU_Huyen.Add(stu_huyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_tinh = new SelectList(db.STU_Tinh, "ID_tinh", "Ten_tinh", stu_huyen.ID_tinh);
            return View(stu_huyen);
        }

        //
        // GET: /Admin/Huyen/Edit/5
        //[Authorize(Roles="Huyen.Edit")]
        public ActionResult Edit(string id = null)
        {
            STU_Huyen stu_huyen = db.STU_Huyen.Find(id);
            if (stu_huyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_tinh = new SelectList(db.STU_Tinh, "ID_tinh", "Ten_tinh", stu_huyen.ID_tinh);
            return View(stu_huyen);
        }

        //
        // POST: /Admin/Huyen/Edit/5

        [HttpPost]
        //[Authorize(Roles="Huyen.Edit")]
        public ActionResult Edit(STU_Huyen stu_huyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_huyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_tinh = new SelectList(db.STU_Tinh, "ID_tinh", "Ten_tinh", stu_huyen.ID_tinh);
            return View(stu_huyen);
        }

        //
        // GET: /Admin/Huyen/Delete/5

        //[Authorize(Roles="Huyen.Delete")]
        public ActionResult Delete(string id = null)
        {
            STU_Huyen stu_huyen = db.STU_Huyen.Find(id);
            if (stu_huyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_huyen);
        }

        //
        // POST: /Admin/Huyen/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="Huyen.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(string id)
        {
            STU_Huyen stu_huyen = db.STU_Huyen.Find(id);
            db.STU_Huyen.Remove(stu_huyen);
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