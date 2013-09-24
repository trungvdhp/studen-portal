using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using StudentPortal.Lib;
using StudentPortal.ViewModels;


namespace StudentPortal.Areas.Admin.Controllers
{
    public class LopTinChiController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/LopTinChi/

        //[Authorize(Roles="LopTinChi.Index")]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/LopTinChi//Read

        //[Authorize(Roles="LopTinChi.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Include(p => p.PLAN_MonTinChi_TC).Include(p => p.PLAN_PhongHoc).Include(p => p.PLAN_GiaoVien);
            return Json(plan_loptinchi_tc.ToDataSourceResult(request));
        }

        public ActionResult getHeDaoTao()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.STU_He.ToList(), "ID_he", "Ten_he");
            return result;
        }

        public ActionResult getChuyenNganh(int ID_he)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.PLAN_ChuongTrinhDaoTao.Where(t => t.ID_he == ID_he).Select(t => new
            {
                ID_chuyen_nganh = t.ID_chuyen_nganh,
                Chuyen_nganh = t.STU_ChuyenNganh.Chuyen_nganh,
            }).Distinct().OrderBy(t => t.Chuyen_nganh).ToList(), "ID_chuyen_nganh", "Chuyen_nganh");
            return result;
        }
        /*
        public ActionResult getChuongTrinhDaoTao(int ID_he,int ID_chuyen_nganh)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.PLAN_ChuongTrinhDaoTao
                .Where(t => t.ID_chuyen_nganh == ID_chuyen_nganh && t.ID_he==ID_he).ToList()
                .Select(t => new ChuongTrinhDaoTaoViewModel
                {
                    ID_dt = t.ID_dt,
                    Ten_ct_dt = t.STU_ChuyenNganh.Chuyen_nganh + " khóa " + t.Khoa_hoc,
                }).ToList(), "ID_dt", "Ten_ct_dt");
            return result;
        }*/

        public ActionResult getKyDangKy()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.PLAN_HocKyDangKy_TC.ToList().Select(t => new StudentPortal.ViewModels.KyDangKy
            {
                Ky_dang_ky = t.Ky_dang_ky,
                Ten_ky = t.Nam_hoc + "_" + t.Hoc_ky + "_" + t.Dot,
            }).OrderBy(t => t.Ky_dang_ky).ToList(), "Ky_dang_ky", "Ten_ky");
            return result;
        }




        public ActionResult getMonTC(int ID_chuyen_nganh, int Ky_dang_ky)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var idMonChuyenNganhs = db.PLAN_ChuongTrinhDaoTaoChiTiet
                .Where(t => t.PLAN_ChuongTrinhDaoTao.ID_chuyen_nganh == ID_chuyen_nganh)
                .Select(t => t.ID_mon).Distinct()
                .ToList();
            var monMos = db.PLAN_MonTinChi_TC.Where(t => t.Ky_dang_ky == Ky_dang_ky).Select(t => t.MARK_MonHoc).ToList();
            var monHeDTs = new List<MARK_MonHoc>();
            foreach (var mon in monMos)
            {
                if (idMonChuyenNganhs.Contains(mon.ID_mon))
                    monHeDTs.Add(mon);
            }
            result.Data = new SelectList(monHeDTs, "ID_mon", "Ten_mon");
            return result;
        }


        public ActionResult getLopTC(int ID_mon)
        {
            var lopTinChis = DangKyHocPhan.getLopTinChi(ID_mon);
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(lopTinChis, "ID_lop_tc", "Ten_lop_tc");
            return result;
        }

        public ActionResult getSinhVienDK([DataSourceRequest]DataSourceRequest request, int? ID_lop_tc)
        {
            if (ID_lop_tc == null)
                ID_lop_tc = -1;

            var svdks = db.STU_DanhSachLopTinChi.Where(t => t.ID_lop_tc == ID_lop_tc).Select(t => new SinhVienViewModel
            {
                ID_sv = t.ID_sv,
                Ho_ten = t.STU_HoSoSinhVien.Ho_ten,
                Ma_sv = t.STU_HoSoSinhVien.Ma_sv,
                Duyet = t.Duyet,
            }).ToList().Select(t => new SinhVienViewModel
            {
                ID_sv = t.ID_sv,
                Ho_ten = t.Ho_ten,
                Lop = SinhVien.Lop[t.ID_sv].Ten_lop,
                Ma_sv = t.Ma_sv,
                Duyet = t.Duyet,
            }).ToList();
            return Json(svdks.ToDataSourceResult(request));
        }


        public ActionResult DuyetDK(int ID_sv, int ID_lop_tc)
        {
            try
            {
                db.STU_DanhSachLopTinChi.Single(t => t.ID_sv == ID_sv && t.ID_lop_tc == ID_lop_tc).Duyet = 1;
                db.SaveChanges();
                JsonResult result = new JsonResult();
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Message = "Đã duyệt sinh viên!",
                };
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
            }
            catch (Exception)
            {
                JsonResult result = new JsonResult();
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Lỗi",
                    Message = "Đã có lỗi xảy ra trong quá trình xử lý, vui lòng thử lại sau!",
                };
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
            }

        }
        public ActionResult BoDuyetDK(int ID_sv, int ID_lop_tc)
        {
            try
            {
                db.STU_DanhSachLopTinChi.Single(t => t.ID_sv == ID_sv && t.ID_lop_tc == ID_lop_tc).Duyet = 0;
                db.SaveChanges();
                JsonResult result = new JsonResult();
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Message = "Đã bỏ duyệt sinh viên!",
                };
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
            }
            catch (Exception)
            {
                JsonResult result = new JsonResult();
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Lỗi",
                    Message = "Đã có lỗi xảy ra trong quá trình xử lý, vui lòng thử lại sau!",
                };
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
            }

        }
        public ActionResult DuyetDKs(int ID_lop_tc,string IDs)
        {

            JsonResult result = new JsonResult();
            try
            {
            
                var ids = IDs.Split(new char[] { ',' });
                foreach (var id in ids)
                {
                    int ID_sv = Convert.ToInt32(id);
                    db.STU_DanhSachLopTinChi.Single(t => t.ID_sv == ID_sv && t.ID_lop_tc == ID_lop_tc).Duyet = 1;
                }
                db.SaveChanges();
                
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Message = "Đã duyệt các sinh viên đã chọn!",
                };

            }
            catch (Exception)
            {
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Lỗi",
                    Message = "Gặp lỗi trong quá trình xử lý! Vui lòng thực hiện lại sau!",
                };
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult BoDuyetDKs(int ID_lop_tc,string IDs)
        {

            JsonResult result = new JsonResult();
            try
            {
                var ids = IDs.Split(new char[] { ',' });
                foreach (var id in ids)
                {
                    int ID_sv = Convert.ToInt32(id);
                    db.STU_DanhSachLopTinChi.Single(t => t.ID_sv == ID_sv && t.ID_lop_tc == ID_lop_tc).Duyet = 0;
                }
                db.SaveChanges();

                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Message = "Đã bỏ duyệt các sinh viên đã chọn!",
                };

            }
            catch (Exception)
            {
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Lỗi",
                    Message = "Gặp lỗi trong quá trình xử lý! Vui lòng thực hiện lại sau!",
                };
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        //
        // GET: /Admin/LopTinChi/Details/5

        //[Authorize(Roles="LopTinChi.Details")]
        public ActionResult Details(int id = 0)
        {
            PLAN_LopTinChi_TC plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Find(id);
            if (plan_loptinchi_tc == null)
            {
                return HttpNotFound();
            }
            return View(plan_loptinchi_tc);
        }

        //
        // GET: /Admin/LopTinChi/Create

        //[Authorize(Roles="LopTinChi.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc");
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong");
            ViewBag.ID_cb = new SelectList(db.PLAN_GiaoVien, "ID_cb", "Ma_cb");
            return View();
        }

        //
        // POST: /Admin/LopTinChi/Create

        [HttpPost]
        //[Authorize(Roles="LopTinChi.Create")]
        public ActionResult Create(PLAN_LopTinChi_TC plan_loptinchi_tc)
        {
            if (ModelState.IsValid)
            {
                db.PLAN_LopTinChi_TC.Add(plan_loptinchi_tc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc", plan_loptinchi_tc.ID_mon_tc);
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong", plan_loptinchi_tc.ID_phong);
            ViewBag.ID_cb = new SelectList(db.PLAN_GiaoVien, "ID_cb", "Ma_cb", plan_loptinchi_tc.ID_cb);
            return View(plan_loptinchi_tc);
        }

        //
        // GET: /Admin/LopTinChi/Edit/5
        //[Authorize(Roles="LopTinChi.Edit")]
        public ActionResult Edit(int id = 0)
        {
            PLAN_LopTinChi_TC plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Find(id);
            if (plan_loptinchi_tc == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc", plan_loptinchi_tc.ID_mon_tc);
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong", plan_loptinchi_tc.ID_phong);
            ViewBag.ID_cb = new SelectList(db.PLAN_GiaoVien, "ID_cb", "Ma_cb", plan_loptinchi_tc.ID_cb);
            return View(plan_loptinchi_tc);
        }

        //
        // POST: /Admin/LopTinChi/Edit/5

        [HttpPost]
        //[Authorize(Roles="LopTinChi.Edit")]
        public ActionResult Edit(PLAN_LopTinChi_TC plan_loptinchi_tc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_loptinchi_tc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_mon_tc = new SelectList(db.PLAN_MonTinChi_TC, "ID_mon_tc", "Ky_hieu_lop_tc", plan_loptinchi_tc.ID_mon_tc);
            ViewBag.ID_phong = new SelectList(db.PLAN_PhongHoc, "ID_phong", "So_phong", plan_loptinchi_tc.ID_phong);
            ViewBag.ID_cb = new SelectList(db.PLAN_GiaoVien, "ID_cb", "Ma_cb", plan_loptinchi_tc.ID_cb);
            return View(plan_loptinchi_tc);
        }

        //
        // GET: /Admin/LopTinChi/Delete/5

        //[Authorize(Roles="LopTinChi.Delete")]
        public ActionResult Delete(int id = 0)
        {
            PLAN_LopTinChi_TC plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Find(id);
            if (plan_loptinchi_tc == null)
            {
                return HttpNotFound();
            }
            return View(plan_loptinchi_tc);
        }

        //
        // POST: /Admin/LopTinChi/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="LopTinChi.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAN_LopTinChi_TC plan_loptinchi_tc = db.PLAN_LopTinChi_TC.Find(id);
            db.PLAN_LopTinChi_TC.Remove(plan_loptinchi_tc);
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