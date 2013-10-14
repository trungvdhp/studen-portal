using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using StudentPortal.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.ViewModels;
using StudentPortal.Filters;

namespace StudentPortal.Controllers
{
    [Authorize]
    public class ThoiKhoaBieuController : BaseController
    {
        public ThoiKhoaBieuController()
        {
            var cauhinhThoigian = db.SCH_CauHinhThoiGian.Single(t => t.Ky_dang_ky == HocKyDangKy.Ky_dang_ky);
            ViewBag.Ngay_thoi_gian = cauhinhThoigian.Ngay_thoi_gian;
            List<string> thoiGianBatDau = cauhinhThoigian.Thoi_gian_bat_dau.Split(new char[] { ',' }).ToList();
            ViewBag.Tong_so_tiet = thoiGianBatDau.Count - thoiGianBatDau.Count(t => t == "0000");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getChuyenNganh()
        {
            JsonResult result = new JsonResult();
            result.Data = new SelectList(this.ChuyenNganh, "ID_dt", "Chuyen_nganh");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult getHocKyDK(int ID_dt)
        {
            int ID_sv = sinhVien.Values.First().ID_sv;
            var kydangkys = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv).Select(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.PLAN_HocKyDangKy_TC)
                .Distinct().ToList().Select(t => new KyDangKy
                {
                    Ky_dang_ky = t.Ky_dang_ky,
                    Ten_ky = t.Nam_hoc + "_" + t.Hoc_ky + "_" + t.Dot,
                }).ToList();
            JsonResult result = new JsonResult();
            result.Data = new SelectList(kydangkys, "Ky_dang_ky", "Ten_ky");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult getGiaiDoan(int ID_dt)
        {
            DHHHContext db = new DHHHContext();
            var ID_sv = this.ID_sv;
            var idLopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv).Select(t => t.ID_lop_tc).ToList();
            var suKienTinChis = new List<PLAN_SukiensTinChi_TC>();
            foreach (var idLopDK in idLopDKs)
            {
                var lopDK_SKTCs = db.PLAN_SukiensTinChi_TC.Where(t => t.ID_lop_tc == idLopDK).ToList();
                foreach (var lopDK_SKTC in lopDK_SKTCs)
                    suKienTinChis.Add(lopDK_SKTC);
            }
            var giaidoans = DangKyHocPhan.getGiaiDoan(suKienTinChis.Select(t => new GiaiDoan
            {
                TuNgay = t.Tu_ngay,
                DenNgay = t.Den_ngay,
            }).ToList());
            JsonResult result = new JsonResult();
            int i = 0;
            result.Data = new SelectList(giaidoans.Select(t => new
            {
                Id_giai_doan = i++,
                Ten_giai_doan = String.Format("{0:dd/MM/yyyy} - {1:dd/MM/yyyy}", t.TuNgay, t.DenNgay),
            }).ToList(), "ID_giai_doan", "Ten_giai_doan");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult getThoiKhoaBieu([DataSourceRequest] DataSourceRequest request, int? ID_giai_doan, int? ID_dt)
        {
            DHHHContext db = new DHHHContext();
            if (ID_dt == null) return null;
            var ID_sv = sinhVien[(int)ID_dt].ID_sv;
            var idLopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv && t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky == HocKyDangKy.Ky_dang_ky).Select(t => t.ID_lop_tc).ToList();
            var suKienTinChis = new List<PLAN_SukiensTinChi_TC>();
            var dicLopTinChiColor = new Dictionary<int, string>();
            Random rand = new Random();
            foreach (var idLopDK in idLopDKs)
            {
                var lopDK_SKTCs = db.PLAN_SukiensTinChi_TC.Where(t => t.ID_lop_tc == idLopDK).ToList();
                dicLopTinChiColor[idLopDK] = String.Format("rgb({0},{1},{2})", rand.Next(104, 212), rand.Next(104, 212), rand.Next(104, 212));
                foreach (var lopDK_SKTC in lopDK_SKTCs)
                    suKienTinChis.Add(lopDK_SKTC);
            }

            var giaidoans = DangKyHocPhan.getGiaiDoan(suKienTinChis.Select(t => new GiaiDoan
            {
                TuNgay = t.Tu_ngay,
                DenNgay = t.Den_ngay,
            }).ToList());

            if (ID_giai_doan >= 0 && ID_giai_doan < giaidoans.Count)
            {
                var giaidoan = giaidoans[(int)ID_giai_doan];
                suKienTinChis = suKienTinChis.Where(t => t.Tu_ngay >= giaidoan.TuNgay && t.Den_ngay <= giaidoan.DenNgay).ToList();
            }

            int Day_of_week = (int)DateTime.Now.DayOfWeek - 1;
            if (Day_of_week < 0) Day_of_week = 6;
            DateTime Monday = DateTime.Now.Date.AddDays(-Day_of_week);
            Dictionary<int, LopTinChiViewModel> dicLopTC = new Dictionary<int, LopTinChiViewModel>();
            foreach (var sktc in suKienTinChis)
            {
                if (!dicLopTC.ContainsKey(sktc.ID_lop_tc))
                {
                    dicLopTC.Add(sktc.ID_lop_tc, LopTinChi.getDetails(sktc.ID_lop_tc));
                }
            }

            return Json(suKienTinChis.Select(t => new ThoiKhoaBieu
            {
                ID_lop_tc = t.ID_lop_tc,
                Start = Monday.AddDays(t.Thu).AddHours(t.Tiet),
                End = Monday.AddDays(t.Thu).AddHours(t.Tiet + t.So_tiet + 1),
                Id = t.ID,
                Title = dicLopTC[t.ID_lop_tc].Ten_lop_tc,
                Color = dicLopTinChiColor[t.ID_lop_tc],
            }).ToDataSourceResult(request));
        }
        public ActionResult getChiTietHocPhan([DataSourceRequest]DataSourceRequest request, int ID_dt)
        {
            var lop = sinhVien[ID_dt].STU_Lop;
            var lopTCs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv).Select(t => t.ID_lop_tc).ToList().Select(t => LopTinChi.getDetails(t)).ToList();
            try
            {
                var muchocphis = db.ACC_MucHocPhiTinChi.Where(t => t.Hoc_ky == HocKyDangKy.Hoc_ky && t.Nam_hoc == HocKyDangKy.Nam_hoc).ToList();
                muchocphis = muchocphis.Where(t => t.ID_he == lop.ID_he || t.ID_he == 0).ToList();
                muchocphis = muchocphis.Where(t => t.ID_chuyen_nganh == lop.ID_chuyen_nganh || t.ID_chuyen_nganh == 0).ToList();
                muchocphis = muchocphis.Where(t => t.Khoa_hoc == lop.Khoa_hoc || t.Khoa_hoc == 0).ToList();
                var muchocphi = muchocphis.First();

                for (var i = 0; i < lopTCs.Count(); i++)
                {
                    lopTCs[i].Hoc_phi = lopTCs[i].He_so * (int)muchocphi.So_tien;
                }

            }
            catch (Exception) { }
            return Json(lopTCs.ToDataSourceResult(request));
        }
    }
}
