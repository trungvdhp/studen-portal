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
    public class XeploaiRenLuyenController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/XeploaiRenLuyen/

        [Authorize(Roles="XeploaiRenLuyen.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/XeploaiRenLuyen//Read

        [Authorize(Roles="XeploaiRenLuyen.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_XeploaiRenLuyen.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/XeploaiRenLuyen/Details/5

        [Authorize(Roles="XeploaiRenLuyen.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_XeploaiRenLuyen stu_xeploairenluyen = db.STU_XeploaiRenLuyen.Find(id);
            if (stu_xeploairenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_xeploairenluyen);
        }

        //
        // GET: /Admin/XeploaiRenLuyen/Create

        [Authorize(Roles="XeploaiRenLuyen.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/XeploaiRenLuyen/Create

        [HttpPost]
        [Authorize(Roles="XeploaiRenLuyen.Create")]
        public ActionResult Create(STU_XeploaiRenLuyen stu_xeploairenluyen)
        {
            if (ModelState.IsValid)
            {
                db.STU_XeploaiRenLuyen.Add(stu_xeploairenluyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_xeploairenluyen);
        }

        //
        // GET: /Admin/XeploaiRenLuyen/Edit/5
        [Authorize(Roles="XeploaiRenLuyen.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_XeploaiRenLuyen stu_xeploairenluyen = db.STU_XeploaiRenLuyen.Find(id);
            if (stu_xeploairenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_xeploairenluyen);
        }

        //
        // POST: /Admin/XeploaiRenLuyen/Edit/5

        [HttpPost]
        [Authorize(Roles="XeploaiRenLuyen.Edit")]
        public ActionResult Edit(STU_XeploaiRenLuyen stu_xeploairenluyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_xeploairenluyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_xeploairenluyen);
        }

        //
        // GET: /Admin/XeploaiRenLuyen/Delete/5

        [Authorize(Roles="XeploaiRenLuyen.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_XeploaiRenLuyen stu_xeploairenluyen = db.STU_XeploaiRenLuyen.Find(id);
            if (stu_xeploairenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_xeploairenluyen);
        }

        //
        // POST: /Admin/XeploaiRenLuyen/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles="XeploaiRenLuyen.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_XeploaiRenLuyen stu_xeploairenluyen = db.STU_XeploaiRenLuyen.Find(id);
            db.STU_XeploaiRenLuyen.Remove(stu_xeploairenluyen);
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