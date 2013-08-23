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
    public class DiemRenLuyenController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/DiemRenLuyen/

        //[Authorize(Roles="DiemRenLuyen.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/DiemRenLuyen//Read

        //[Authorize(Roles="DiemRenLuyen.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_diemrenluyen = db.STU_DiemRenLuyen.Include(s => s.STU_HoSoSinhVien).Include(s => s.STU_LoaiRenLuyen);
            return Json(stu_diemrenluyen.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/DiemRenLuyen/Details/5

        //[Authorize(Roles="DiemRenLuyen.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_DiemRenLuyen stu_diemrenluyen = db.STU_DiemRenLuyen.Find(id);
            if (stu_diemrenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_diemrenluyen);
        }

        //
        // GET: /Admin/DiemRenLuyen/Create

        //[Authorize(Roles="DiemRenLuyen.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv");
            ViewBag.ID_loai_rl = new SelectList(db.STU_LoaiRenLuyen, "ID_loai_rl", "Ky_hieu");
            return View();
        }

        //
        // POST: /Admin/DiemRenLuyen/Create

        [HttpPost]
        //[Authorize(Roles="DiemRenLuyen.Create")]
        public ActionResult Create(STU_DiemRenLuyen stu_diemrenluyen)
        {
            if (ModelState.IsValid)
            {
                db.STU_DiemRenLuyen.Add(stu_diemrenluyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_diemrenluyen.ID_sv);
            ViewBag.ID_loai_rl = new SelectList(db.STU_LoaiRenLuyen, "ID_loai_rl", "Ky_hieu", stu_diemrenluyen.ID_loai_rl);
            return View(stu_diemrenluyen);
        }

        //
        // GET: /Admin/DiemRenLuyen/Edit/5
        //[Authorize(Roles="DiemRenLuyen.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_DiemRenLuyen stu_diemrenluyen = db.STU_DiemRenLuyen.Find(id);
            if (stu_diemrenluyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_diemrenluyen.ID_sv);
            ViewBag.ID_loai_rl = new SelectList(db.STU_LoaiRenLuyen, "ID_loai_rl", "Ky_hieu", stu_diemrenluyen.ID_loai_rl);
            return View(stu_diemrenluyen);
        }

        //
        // POST: /Admin/DiemRenLuyen/Edit/5

        [HttpPost]
        //[Authorize(Roles="DiemRenLuyen.Edit")]
        public ActionResult Edit(STU_DiemRenLuyen stu_diemrenluyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_diemrenluyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_sv = new SelectList(db.STU_HoSoSinhVien, "ID_sv", "Ma_sv", stu_diemrenluyen.ID_sv);
            ViewBag.ID_loai_rl = new SelectList(db.STU_LoaiRenLuyen, "ID_loai_rl", "Ky_hieu", stu_diemrenluyen.ID_loai_rl);
            return View(stu_diemrenluyen);
        }

        //
        // GET: /Admin/DiemRenLuyen/Delete/5

        //[Authorize(Roles="DiemRenLuyen.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_DiemRenLuyen stu_diemrenluyen = db.STU_DiemRenLuyen.Find(id);
            if (stu_diemrenluyen == null)
            {
                return HttpNotFound();
            }
            return View(stu_diemrenluyen);
        }

        //
        // POST: /Admin/DiemRenLuyen/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="DiemRenLuyen.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_DiemRenLuyen stu_diemrenluyen = db.STU_DiemRenLuyen.Find(id);
            db.STU_DiemRenLuyen.Remove(stu_diemrenluyen);
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