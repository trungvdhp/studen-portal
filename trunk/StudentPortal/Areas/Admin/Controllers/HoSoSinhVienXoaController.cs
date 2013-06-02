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
    public class HoSoSinhVienXoaController : BasicController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HoSoSinhVienXoa/

        //[Authorize(Roles="HoSoSinhVienXoa.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HoSoSinhVienXoa//Read

        //[Authorize(Roles="HoSoSinhVienXoa.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_hososinhvienxoa = db.STU_HoSoSinhVienXoa.Include(s => s.STU_GioiTinh).Include(s => s.STU_DanToc).Include(s => s.STU_QuocTich).Include(s => s.STU_ThanhPhanXuatThan);
            return Json(stu_hososinhvienxoa.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HoSoSinhVienXoa/Details/5

        //[Authorize(Roles="HoSoSinhVienXoa.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_HoSoSinhVienXoa stu_hososinhvienxoa = db.STU_HoSoSinhVienXoa.Find(id);
            if (stu_hososinhvienxoa == null)
            {
                return HttpNotFound();
            }
            return View(stu_hososinhvienxoa);
        }

        //
        // GET: /Admin/HoSoSinhVienXoa/Create

        //[Authorize(Roles="HoSoSinhVienXoa.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh");
            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc");
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich");
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan");
            return View();
        }

        //
        // POST: /Admin/HoSoSinhVienXoa/Create

        [HttpPost]
        //[Authorize(Roles="HoSoSinhVienXoa.Create")]
        public ActionResult Create(STU_HoSoSinhVienXoa stu_hososinhvienxoa)
        {
            if (ModelState.IsValid)
            {
                db.STU_HoSoSinhVienXoa.Add(stu_hososinhvienxoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh", stu_hososinhvienxoa.ID_gioi_tinh);
            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc", stu_hososinhvienxoa.ID_dan_toc);
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich", stu_hososinhvienxoa.ID_quoc_tich);
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan", stu_hososinhvienxoa.ID_thanh_phan_xuat_than);
            return View(stu_hososinhvienxoa);
        }

        //
        // GET: /Admin/HoSoSinhVienXoa/Edit/5
        //[Authorize(Roles="HoSoSinhVienXoa.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_HoSoSinhVienXoa stu_hososinhvienxoa = db.STU_HoSoSinhVienXoa.Find(id);
            if (stu_hososinhvienxoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh", stu_hososinhvienxoa.ID_gioi_tinh);
            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc", stu_hososinhvienxoa.ID_dan_toc);
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich", stu_hososinhvienxoa.ID_quoc_tich);
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan", stu_hososinhvienxoa.ID_thanh_phan_xuat_than);
            return View(stu_hososinhvienxoa);
        }

        //
        // POST: /Admin/HoSoSinhVienXoa/Edit/5

        [HttpPost]
        //[Authorize(Roles="HoSoSinhVienXoa.Edit")]
        public ActionResult Edit(STU_HoSoSinhVienXoa stu_hososinhvienxoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_hososinhvienxoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_gioi_tinh = new SelectList(db.STU_GioiTinh, "ID_gioi_tinh", "Gioi_tinh", stu_hososinhvienxoa.ID_gioi_tinh);
            ViewBag.ID_dan_toc = new SelectList(db.STU_DanToc, "ID_dan_toc", "Ma_dan_toc", stu_hososinhvienxoa.ID_dan_toc);
            ViewBag.ID_quoc_tich = new SelectList(db.STU_QuocTich, "ID_quoc_tich", "Ma_quoc_tich", stu_hososinhvienxoa.ID_quoc_tich);
            ViewBag.ID_thanh_phan_xuat_than = new SelectList(db.STU_ThanhPhanXuatThan, "ID_thanh_phan_xuat_than", "Ten_thanh_phan", stu_hososinhvienxoa.ID_thanh_phan_xuat_than);
            return View(stu_hososinhvienxoa);
        }

        //
        // GET: /Admin/HoSoSinhVienXoa/Delete/5

        //[Authorize(Roles="HoSoSinhVienXoa.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_HoSoSinhVienXoa stu_hososinhvienxoa = db.STU_HoSoSinhVienXoa.Find(id);
            if (stu_hososinhvienxoa == null)
            {
                return HttpNotFound();
            }
            return View(stu_hososinhvienxoa);
        }

        //
        // POST: /Admin/HoSoSinhVienXoa/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HoSoSinhVienXoa.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_HoSoSinhVienXoa stu_hososinhvienxoa = db.STU_HoSoSinhVienXoa.Find(id);
            db.STU_HoSoSinhVienXoa.Remove(stu_hososinhvienxoa);
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