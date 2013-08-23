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
    public class HeSoRenLuyenController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HeSoRenLuyen/

        //[Authorize(Roles="HeSoRenLuyen.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HeSoRenLuyen//Read

        //[Authorize(Roles="HeSoRenLuyen.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_HeSoRenLuyen.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HeSoRenLuyen/Details/5

        //[Authorize(Roles="HeSoRenLuyen.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_HeSoRenLuyen stu_hesorenluyen = db.STU_HeSoRenLuyen.Find(id);
            if (stu_hesorenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_hesorenluyen);
        }

        //
        // GET: /Admin/HeSoRenLuyen/Create

        //[Authorize(Roles="HeSoRenLuyen.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/HeSoRenLuyen/Create

        [HttpPost]
        //[Authorize(Roles="HeSoRenLuyen.Create")]
        public ActionResult Create(STU_HeSoRenLuyen stu_hesorenluyen)
        {
            if (ModelState.IsValid)
            {
                db.STU_HeSoRenLuyen.Add(stu_hesorenluyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_hesorenluyen);
        }

        //
        // GET: /Admin/HeSoRenLuyen/Edit/5
        //[Authorize(Roles="HeSoRenLuyen.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_HeSoRenLuyen stu_hesorenluyen = db.STU_HeSoRenLuyen.Find(id);
            if (stu_hesorenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_hesorenluyen);
        }

        //
        // POST: /Admin/HeSoRenLuyen/Edit/5

        [HttpPost]
        //[Authorize(Roles="HeSoRenLuyen.Edit")]
        public ActionResult Edit(STU_HeSoRenLuyen stu_hesorenluyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_hesorenluyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_hesorenluyen);
        }

        //
        // GET: /Admin/HeSoRenLuyen/Delete/5

        //[Authorize(Roles="HeSoRenLuyen.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_HeSoRenLuyen stu_hesorenluyen = db.STU_HeSoRenLuyen.Find(id);
            if (stu_hesorenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_hesorenluyen);
        }

        //
        // POST: /Admin/HeSoRenLuyen/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HeSoRenLuyen.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_HeSoRenLuyen stu_hesorenluyen = db.STU_HeSoRenLuyen.Find(id);
            db.STU_HeSoRenLuyen.Remove(stu_hesorenluyen);
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