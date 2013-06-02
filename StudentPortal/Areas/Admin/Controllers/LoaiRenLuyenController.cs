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
    public class LoaiRenLuyenController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/LoaiRenLuyen/

        //[Authorize(Roles="LoaiRenLuyen.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/LoaiRenLuyen//Read

        //[Authorize(Roles="LoaiRenLuyen.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_loairenluyen = db.STU_LoaiRenLuyen.Include(s => s.STU_CapRenLuyen);
            return Json(stu_loairenluyen.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/LoaiRenLuyen/Details/5

        //[Authorize(Roles="LoaiRenLuyen.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_LoaiRenLuyen stu_loairenluyen = db.STU_LoaiRenLuyen.Find(id);
            if (stu_loairenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_loairenluyen);
        }

        //
        // GET: /Admin/LoaiRenLuyen/Create

        //[Authorize(Roles="LoaiRenLuyen.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_cap_rl = new SelectList(db.STU_CapRenLuyen, "ID_cap_rl", "Ky_hieu");
            return View();
        }

        //
        // POST: /Admin/LoaiRenLuyen/Create

        [HttpPost]
        //[Authorize(Roles="LoaiRenLuyen.Create")]
        public ActionResult Create(STU_LoaiRenLuyen stu_loairenluyen)
        {
            if (ModelState.IsValid)
            {
                db.STU_LoaiRenLuyen.Add(stu_loairenluyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_cap_rl = new SelectList(db.STU_CapRenLuyen, "ID_cap_rl", "Ky_hieu", stu_loairenluyen.ID_cap_rl);
            return View(stu_loairenluyen);
        }

        //
        // GET: /Admin/LoaiRenLuyen/Edit/5
        //[Authorize(Roles="LoaiRenLuyen.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_LoaiRenLuyen stu_loairenluyen = db.STU_LoaiRenLuyen.Find(id);
            if (stu_loairenluyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_cap_rl = new SelectList(db.STU_CapRenLuyen, "ID_cap_rl", "Ky_hieu", stu_loairenluyen.ID_cap_rl);
            return View(stu_loairenluyen);
        }

        //
        // POST: /Admin/LoaiRenLuyen/Edit/5

        [HttpPost]
        //[Authorize(Roles="LoaiRenLuyen.Edit")]
        public ActionResult Edit(STU_LoaiRenLuyen stu_loairenluyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_loairenluyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_cap_rl = new SelectList(db.STU_CapRenLuyen, "ID_cap_rl", "Ky_hieu", stu_loairenluyen.ID_cap_rl);
            return View(stu_loairenluyen);
        }

        //
        // GET: /Admin/LoaiRenLuyen/Delete/5

        //[Authorize(Roles="LoaiRenLuyen.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_LoaiRenLuyen stu_loairenluyen = db.STU_LoaiRenLuyen.Find(id);
            if (stu_loairenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_loairenluyen);
        }

        //
        // POST: /Admin/LoaiRenLuyen/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="LoaiRenLuyen.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_LoaiRenLuyen stu_loairenluyen = db.STU_LoaiRenLuyen.Find(id);
            db.STU_LoaiRenLuyen.Remove(stu_loairenluyen);
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