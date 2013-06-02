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
    public class NhanXetNamController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/NhanXetNam/

        //[Authorize(Roles="NhanXetNam.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/NhanXetNam//Read

        //[Authorize(Roles="NhanXetNam.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_NhanXetNam.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/NhanXetNam/Details/5

        //[Authorize(Roles="NhanXetNam.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_NhanXetNam stu_nhanxetnam = db.STU_NhanXetNam.Find(id);
            if (stu_nhanxetnam == null)
            {
                return HttpNotFound();
            }
            return View(stu_nhanxetnam);
        }

        //
        // GET: /Admin/NhanXetNam/Create

        //[Authorize(Roles="NhanXetNam.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/NhanXetNam/Create

        [HttpPost]
        //[Authorize(Roles="NhanXetNam.Create")]
        public ActionResult Create(STU_NhanXetNam stu_nhanxetnam)
        {
            if (ModelState.IsValid)
            {
                db.STU_NhanXetNam.Add(stu_nhanxetnam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_nhanxetnam);
        }

        //
        // GET: /Admin/NhanXetNam/Edit/5
        //[Authorize(Roles="NhanXetNam.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_NhanXetNam stu_nhanxetnam = db.STU_NhanXetNam.Find(id);
            if (stu_nhanxetnam == null)
            {
                return HttpNotFound();
            }
            return View(stu_nhanxetnam);
        }

        //
        // POST: /Admin/NhanXetNam/Edit/5

        [HttpPost]
        //[Authorize(Roles="NhanXetNam.Edit")]
        public ActionResult Edit(STU_NhanXetNam stu_nhanxetnam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_nhanxetnam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_nhanxetnam);
        }

        //
        // GET: /Admin/NhanXetNam/Delete/5

        //[Authorize(Roles="NhanXetNam.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_NhanXetNam stu_nhanxetnam = db.STU_NhanXetNam.Find(id);
            if (stu_nhanxetnam == null)
            {
                return HttpNotFound();
            }
            return View(stu_nhanxetnam);
        }

        //
        // POST: /Admin/NhanXetNam/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="NhanXetNam.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_NhanXetNam stu_nhanxetnam = db.STU_NhanXetNam.Find(id);
            db.STU_NhanXetNam.Remove(stu_nhanxetnam);
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