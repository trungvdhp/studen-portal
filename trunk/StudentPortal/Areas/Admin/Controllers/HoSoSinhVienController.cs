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
    public class HoSoSinhVienController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HoSoSinhVien/

        //[Authorize(Roles="HoSoSinhVien.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HoSoSinhVien//Read

        //[Authorize(Roles="HoSoSinhVien.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_hososinhvien = db.STU_HoSoSinhVien.Include(s => s.STU_DanToc).Include(s => s.STU_GioiTinh).Include(s => s.STU_QuocTich).Include(s => s.STU_ThanhPhanXuatThan).Include(s => s.STU_NhomDoiTuong);
            return Json(stu_hososinhvien.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HoSoSinhVien/Details/5

        //[Authorize(Roles="HoSoSinhVien.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_HoSoSinhVien stu_hososinhvien = db.STU_HoSoSinhVien.Find(id);
            if (stu_hososinhvien == null)
            {
                return HttpNotFound();
            }
            return View(stu_hososinhvien);
        }

        //
        // GET: /Admin/HoSoSinhVien/Create

        //[Authorize(Roles="HoSoSinhVien.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc");
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh");
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich");
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan");
            ViewBag.ID_nhom_doi_tuong = new SelectList(db.STU_NhomDoiTuong, "ID_nhom_dt", "Ma_nhom");
            return View();
        }

        //
        // POST: /Admin/HoSoSinhVien/Create

        [HttpPost]
        //[Authorize(Roles="HoSoSinhVien.Create")]
        public ActionResult Create(STU_HoSoSinhVien stu_hososinhvien)
        {
            if (ModelState.IsValid)
            {
                db.STU_HoSoSinhVien.Add(stu_hososinhvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc", stu_hososinhvien.ID_dan_toc);
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh", stu_hososinhvien.ID_gioi_tinh);
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich", stu_hososinhvien.ID_quoc_tich);
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan", stu_hososinhvien.ID_thanh_phan_xuat_than);
            ViewBag.ID_nhom_doi_tuong = new SelectList(db.STU_NhomDoiTuong, "ID_nhom_dt", "Ma_nhom", stu_hososinhvien.ID_nhom_doi_tuong);
            return View(stu_hososinhvien);
        }

        //
        // GET: /Admin/HoSoSinhVien/Edit/5
        //[Authorize(Roles="HoSoSinhVien.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_HoSoSinhVien stu_hososinhvien = db.STU_HoSoSinhVien.Find(id);
            if (stu_hososinhvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc", stu_hososinhvien.ID_dan_toc);
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh", stu_hososinhvien.ID_gioi_tinh);
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich", stu_hososinhvien.ID_quoc_tich);
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan", stu_hososinhvien.ID_thanh_phan_xuat_than);
            ViewBag.ID_nhom_doi_tuong = new SelectList(db.STU_NhomDoiTuong, "ID_nhom_dt", "Ma_nhom", stu_hososinhvien.ID_nhom_doi_tuong);
            return View(stu_hososinhvien);
        }

        //
        // POST: /Admin/HoSoSinhVien/Edit/5

        [HttpPost]
        //[Authorize(Roles="HoSoSinhVien.Edit")]
        public ActionResult Edit(STU_HoSoSinhVien stu_hososinhvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_hososinhvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc", stu_hososinhvien.ID_dan_toc);
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh", stu_hososinhvien.ID_gioi_tinh);
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich", stu_hososinhvien.ID_quoc_tich);
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan", stu_hososinhvien.ID_thanh_phan_xuat_than);
            ViewBag.ID_nhom_doi_tuong = new SelectList(db.STU_NhomDoiTuong, "ID_nhom_dt", "Ma_nhom", stu_hososinhvien.ID_nhom_doi_tuong);
            return View(stu_hososinhvien);
        }

        //
        // GET: /Admin/HoSoSinhVien/Delete/5

        //[Authorize(Roles="HoSoSinhVien.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_HoSoSinhVien stu_hososinhvien = db.STU_HoSoSinhVien.Find(id);
            if (stu_hososinhvien == null)
            {
                return HttpNotFound();
            }
            return View(stu_hososinhvien);
        }

        //
        // POST: /Admin/HoSoSinhVien/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HoSoSinhVien.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_HoSoSinhVien stu_hososinhvien = db.STU_HoSoSinhVien.Find(id);
            db.STU_HoSoSinhVien.Remove(stu_hososinhvien);
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