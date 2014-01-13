using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using StudentPortal.ViewModels;
using StudentPortal.Lib;
using System.Threading;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class LopHanhChinhController : BaseController
    {

        public ActionResult Index()
        {
            return View();
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

        public ActionResult getKhoaHoc(int ID_he, int ID_chuyen_nganh)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.STU_Lop.Where(t => t.ID_he == ID_he && t.ID_chuyen_nganh == ID_chuyen_nganh).Select(t => new
            {
                Khoa_hoc = t.Khoa_hoc
            }).Distinct().ToList(), "Khoa_hoc", "Khoa_hoc");
            return result;
        }

        public ActionResult getLopHC([DataSourceRequest] DataSourceRequest request, int ID_he, int? ID_Chuyen_nganh, int? Khoa_hoc)
        {
            var lops = db.STU_Lop.Where(t => t.ID_he == ID_he).ToList();

            if (ID_Chuyen_nganh != null) lops = lops.Where(t => t.ID_chuyen_nganh == ID_Chuyen_nganh).ToList();
            if (Khoa_hoc != null) lops = lops.Where(t => t.Khoa_hoc == Khoa_hoc).ToList();

            var result = lops.Select(t => new LopHanhChinhViewModel
            {
                ID_lop = t.ID_lop,
                Ten_lop = t.Ten_lop,
                Nien_khoa = t.Nien_khoa,
            }).ToList();

            return Json(lops.ToDataSourceResult(request));
        }

        public ActionResult getSinhVien([DataSourceRequest] DataSourceRequest request, int ID_lop)
        {
            var sinhviens = db.STU_DanhSach.Where(t => t.ID_lop == ID_lop).Select(t => new SinhVienViewModel
            {
                ID_sv = t.ID_sv,
                Ma_sv = t.STU_HoSoSinhVien.Ma_sv,
                Ho_ten = t.STU_HoSoSinhVien.Ho_ten,
                Trang_thai_dk = t.Trang_thai_dk
            }).ToList();

            return Json(sinhviens.ToDataSourceResult(request));
        }
        public ActionResult getMonTC(int ID_lop)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            var lop = db.STU_Lop.Single(t => t.ID_lop == ID_lop);

            //result.Data = ChuongTrinhDaoTao.getMonHoc(lop.ID_dt).Select(t => new
            //{
            //    Text = t.Ky_hieu + " " + t.Ten_mon
            //}).ToList();
            result.Data = DangKyHocPhan.getMonDangKy(lop.ID_dt, HocKyDangKy.Ky_dang_ky);

            return result;
        }

        public ActionResult getLopTC([DataSourceRequest]DataSourceRequest request, string Tu_khoa)
        {
            var kyhieu = Tu_khoa.Split(' ')[0];
            try
            {
                var mon = db.MARK_MonHoc.Single(t => t.Ky_hieu == kyhieu);
                return Json(DangKyHocPhan.getLopTinChi(mon.ID_mon, this.HocKyDangKy.Ky_dang_ky).ToDataSourceResult(request));
            }
            catch (Exception)
            {
                return Json(new { });
            }
        }

        public ActionResult getChiTietDK([DataSourceRequest]DataSourceRequest request, int ID_sv, int ID_lop)
        {
            try
            {
                var lop = db.STU_Lop.Single(t=>t.ID_lop==ID_lop);
                var lopTCs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv).Select(t => t.ID_lop_tc).ToList().Select(t => LopTinChi.getDetails(t)).ToList();


                var muchocphi = HocPhi.getMucHocPhi(db, HocKyDangKy.Ky_dang_ky, lop.ID_he, lop.ID_chuyen_nganh, lop.Khoa_hoc);

                for (var i = 0; i < lopTCs.Count(); i++)
                {
                    lopTCs[i].Hoc_phi = lopTCs[i].He_so * (int)muchocphi.So_tien;
                }
                return Json(lopTCs.ToDataSourceResult(request));
            }
            catch (Exception)
            {
                return Json((new List<LopTinChiViewModel>()).ToDataSourceResult(request));
            }

        }

        public ActionResult DangKy(int ID_lop_tc, int ID_sv, int ID_lop)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                var lopHC = db.STU_Lop.Single(t => t.ID_lop == ID_lop);
                DangKyHocPhan.KiemTraDieuKienDangKy(ref db, ID_sv, ID_lop_tc, lopHC.ID_dt);
                db.STU_DanhSachLopTinChi.Add(new STU_DanhSachLopTinChi
                {
                    ID_lop_tc = ID_lop_tc,
                    ID_sv = ID_sv,
                    Duyet = 0,
                });
                db.SaveChanges();
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Message = "Đã đăng ký thành công!"
                };
            }
            catch (Exception e)
            {
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Message = e.Message,
                };
            }

            return result;
        }
    }
}
