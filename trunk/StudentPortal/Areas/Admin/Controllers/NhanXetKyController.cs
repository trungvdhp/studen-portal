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
    public class NhanXetKyController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/NhanXetKy/

        //[Authorize(Roles="NhanXetKy.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/NhanXetKy//Read

        //[Authorize(Roles="NhanXetKy.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_NhanXetKy.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/NhanXetKy/Details/5

        //[Authorize(Roles="NhanXetKy.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_NhanXetKy stu_nhanxetky = db.STU_NhanXetKy.Find(id);
            if (stu_nhanxetky == null)
            {
                return HttpNotFound();
            }
            return View(stu_nhanxetky);
        }

        //
        // GET: /Admin/NhanXetKy/Create

        //[Authorize(Roles="NhanXetKy.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/NhanXetKy/Create

        [HttpPost]
        //[Authorize(Roles="NhanXetKy.Create")]
        public ActionResult Create(STU_NhanXetKy stu_nhanxetky)
        {
            if (ModelState.IsValid)
            {
                db.STU_NhanXetKy.Add(stu_nhanxetky);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_nhanxetky);
        }

        //
        // GET: /Admin/NhanXetKy/Edit/5
        //[Authorize(Roles="NhanXetKy.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_NhanXetKy stu_nhanxetky = db.STU_NhanXetKy.Find(id);
            if (stu_nhanxetky == null)
            {
                return HttpNotFound();
            }
            return View(stu_nhanxetky);
        }

        //
        // POST: /Admin/NhanXetKy/Edit/5

        [HttpPost]
        //[Authorize(Roles="NhanXetKy.Edit")]
        public ActionResult Edit(STU_NhanXetKy stu_nhanxetky)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_nhanxetky).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_nhanxetky);
        }

        //
        // GET: /Admin/NhanXetKy/Delete/5

        //[Authorize(Roles="NhanXetKy.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_NhanXetKy stu_nhanxetky = db.STU_NhanXetKy.Find(id);
            if (stu_nhanxetky == null)
            {
                return HttpNotFound();
            }
            return View(stu_nhanxetky);
        }

        //
        // POST: /Admin/NhanXetKy/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="NhanXetKy.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_NhanXetKy stu_nhanxetky = db.STU_NhanXetKy.Find(id);
            db.STU_NhanXetKy.Remove(stu_nhanxetky);
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