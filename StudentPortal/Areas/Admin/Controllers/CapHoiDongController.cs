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
    public class CapHoiDongController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/CapHoiDong/

        //[Authorize(Roles="CapHoiDong.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/CapHoiDong//Read

        //[Authorize(Roles="CapHoiDong.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_CapHoiDong.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/CapHoiDong/Details/5

        //[Authorize(Roles="CapHoiDong.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_CapHoiDong stu_caphoidong = db.STU_CapHoiDong.Find(id);
            if (stu_caphoidong == null)
            {
                return HttpNotFound();
            }
            return View(stu_caphoidong);
        }

        //
        // GET: /Admin/CapHoiDong/Create

        //[Authorize(Roles="CapHoiDong.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/CapHoiDong/Create

        [HttpPost]
        //[Authorize(Roles="CapHoiDong.Create")]
        public ActionResult Create(STU_CapHoiDong stu_caphoidong)
        {
            if (ModelState.IsValid)
            {
                db.STU_CapHoiDong.Add(stu_caphoidong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_caphoidong);
        }

        //
        // GET: /Admin/CapHoiDong/Edit/5
        //[Authorize(Roles="CapHoiDong.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_CapHoiDong stu_caphoidong = db.STU_CapHoiDong.Find(id);
            if (stu_caphoidong == null)
            {
                return HttpNotFound();
            }
            return View(stu_caphoidong);
        }

        //
        // POST: /Admin/CapHoiDong/Edit/5

        [HttpPost]
        //[Authorize(Roles="CapHoiDong.Edit")]
        public ActionResult Edit(STU_CapHoiDong stu_caphoidong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_caphoidong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_caphoidong);
        }

        //
        // GET: /Admin/CapHoiDong/Delete/5

        //[Authorize(Roles="CapHoiDong.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_CapHoiDong stu_caphoidong = db.STU_CapHoiDong.Find(id);
            if (stu_caphoidong == null)
            {
                return HttpNotFound();
            }
            return View(stu_caphoidong);
        }

        //
        // POST: /Admin/CapHoiDong/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="CapHoiDong.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_CapHoiDong stu_caphoidong = db.STU_CapHoiDong.Find(id);
            db.STU_CapHoiDong.Remove(stu_caphoidong);
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