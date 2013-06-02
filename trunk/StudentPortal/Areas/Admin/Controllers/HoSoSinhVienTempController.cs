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
    public class HoSoSinhVienTempController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HoSoSinhVienTemp/

        //[Authorize(Roles="HoSoSinhVienTemp.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HoSoSinhVienTemp//Read

        //[Authorize(Roles="HoSoSinhVienTemp.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_hososinhvientemp = db.STU_HoSoSinhVienTemp.Include(s => s.STU_DanToc).Include(s => s.STU_QuocTich).Include(s => s.STU_GioiTinh).Include(s => s.STU_ThanhPhanXuatThan).Include(s => s.STU_NhomDoiTuong);
            return Json(stu_hososinhvientemp.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HoSoSinhVienTemp/Details/5

        //[Authorize(Roles="HoSoSinhVienTemp.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_HoSoSinhVienTemp stu_hososinhvientemp = db.STU_HoSoSinhVienTemp.Find(id);
            if (stu_hososinhvientemp == null)
            {
                return HttpNotFound();
            }
            return View(stu_hososinhvientemp);
        }

        //
        // GET: /Admin/HoSoSinhVienTemp/Create

        //[Authorize(Roles="HoSoSinhVienTemp.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc");
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich");
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh");
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan");
            ViewBag.ID_nhom_doi_tuong = new SelectList(db.STU_NhomDoiTuong, "ID_nhom_dt", "Ma_nhom");
            return View();
        }

        //
        // POST: /Admin/HoSoSinhVienTemp/Create

        [HttpPost]
        //[Authorize(Roles="HoSoSinhVienTemp.Create")]
        public ActionResult Create(STU_HoSoSinhVienTemp stu_hososinhvientemp)
        {
            if (ModelState.IsValid)
            {
                db.STU_HoSoSinhVienTemp.Add(stu_hososinhvientemp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc", stu_hososinhvientemp.ID_dan_toc);
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich", stu_hososinhvientemp.ID_quoc_tich);
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh", stu_hososinhvientemp.ID_gioi_tinh);
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan", stu_hososinhvientemp.ID_thanh_phan_xuat_than);
            ViewBag.ID_nhom_doi_tuong = new SelectList(db.STU_NhomDoiTuong, "ID_nhom_dt", "Ma_nhom", stu_hososinhvientemp.ID_nhom_doi_tuong);
            return View(stu_hososinhvientemp);
        }

        //
        // GET: /Admin/HoSoSinhVienTemp/Edit/5
        //[Authorize(Roles="HoSoSinhVienTemp.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_HoSoSinhVienTemp stu_hososinhvientemp = db.STU_HoSoSinhVienTemp.Find(id);
            if (stu_hososinhvientemp == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc", stu_hososinhvientemp.ID_dan_toc);
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich", stu_hososinhvientemp.ID_quoc_tich);
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh", stu_hososinhvientemp.ID_gioi_tinh);
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan", stu_hososinhvientemp.ID_thanh_phan_xuat_than);
            ViewBag.ID_nhom_doi_tuong = new SelectList(db.STU_NhomDoiTuong, "ID_nhom_dt", "Ma_nhom", stu_hososinhvientemp.ID_nhom_doi_tuong);
            return View(stu_hososinhvientemp);
        }

        //
        // POST: /Admin/HoSoSinhVienTemp/Edit/5

        [HttpPost]
        //[Authorize(Roles="HoSoSinhVienTemp.Edit")]
        public ActionResult Edit(STU_HoSoSinhVienTemp stu_hososinhvientemp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_hososinhvientemp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc", stu_hososinhvientemp.ID_dan_toc);
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich", stu_hososinhvientemp.ID_quoc_tich);
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh", stu_hososinhvientemp.ID_gioi_tinh);
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan", stu_hososinhvientemp.ID_thanh_phan_xuat_than);
            ViewBag.ID_nhom_doi_tuong = new SelectList(db.STU_NhomDoiTuong, "ID_nhom_dt", "Ma_nhom", stu_hososinhvientemp.ID_nhom_doi_tuong);
            return View(stu_hososinhvientemp);
        }

        //
        // GET: /Admin/HoSoSinhVienTemp/Delete/5

        //[Authorize(Roles="HoSoSinhVienTemp.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_HoSoSinhVienTemp stu_hososinhvientemp = db.STU_HoSoSinhVienTemp.Find(id);
            if (stu_hososinhvientemp == null)
            {
                return HttpNotFound();
            }
            return View(stu_hososinhvientemp);
        }

        //
        // POST: /Admin/HoSoSinhVienTemp/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HoSoSinhVienTemp.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_HoSoSinhVienTemp stu_hososinhvientemp = db.STU_HoSoSinhVienTemp.Find(id);
            db.STU_HoSoSinhVienTemp.Remove(stu_hososinhvientemp);
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