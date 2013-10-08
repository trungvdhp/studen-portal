using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.Lib;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using StudentPortal.Filters;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using StudentPortal.ViewModels;
using StudentPortal;
using NodaTime;

namespace StudentPortal.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class DangKyHocPhanController : BaseController
    {
        

        public DangKyHocPhanController()
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

        
        public ActionResult getMonHoc(KieuDangKy KieuDK, int ID_dt)
        {
            JsonResult result = new JsonResult();
            DHHHContext db = new DHHHContext();
            var monDK = this.getMonDangKy(KieuDK,ID_dt).Select(t=>new {
                ID_mon = t.ID_mon,
                Ten_mon = t.Ten_mon,
            });
            result.Data = new SelectList(monDK, "ID_mon", "Ten_mon");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult getLopTC([DataSourceRequest]DataSourceRequest request, int? ID_mon, int? ID_dt)
        {
            DHHHContext db = new DHHHContext();
            if (ID_dt == null) return null;
            var lopTinChis = DangKyHocPhan.getLopTinChi(ID_mon, this.HocKyDangKy.Ky_dang_ky);
            var ID_sv = sinhVien[(int)ID_dt].ID_sv;
            var idLopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv).Select(t => t.ID_lop_tc).ToList();

            for (var i = 0; i < lopTinChis.Count; i++)
            {
                lopTinChis[i].Chua_dang_ky = !idLopDKs.Contains(lopTinChis[i].ID_lop_tc);
                if (!lopTinChis[i].Chua_dang_ky)
                {
                    var tmp = new List<LopTinChiViewModel>();
                    tmp.Add(lopTinChis[i]);
                    return Json(tmp.ToDataSourceResult(request));
                }
            }
            return Json(lopTinChis.ToDataSourceResult(request));
        }

        public ActionResult getChuyenNganh()
        {
            JsonResult result = new JsonResult();
            result.Data = new SelectList(this.ChuyenNganh, "ID_dt", "Chuyen_nganh");
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
        public ActionResult getThoiKhoaBieu([DataSourceRequest] DataSourceRequest request, int? ID_giai_doan,int? ID_dt)
        {
            DHHHContext db = new DHHHContext();
            if (ID_dt == null) return null;
            var ID_sv = sinhVien[(int)ID_dt].ID_sv;
            var idLopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv).Select(t => t.ID_lop_tc).ToList();
            var suKienTinChis = new List<PLAN_SukiensTinChi_TC>();
            var dicLopTinChiColor = new Dictionary<int, string>();
            Random rand = new Random();
            foreach (var idLopDK in idLopDKs)
            {
                var lopDK_SKTCs = db.PLAN_SukiensTinChi_TC.Where(t => t.ID_lop_tc == idLopDK).ToList();
                var loptc = lopDK_SKTCs.First().PLAN_LopTinChi_TC;
                var id_lop_tc = loptc.ID_mon_tc;
                var stt = loptc.STT_lop;
                int r,g,b;
                g = (idLopDK %16)*16;
                b= (id_lop_tc%16)*16;
                r = (stt % 16) * 16;
                dicLopTinChiColor[idLopDK] = String.Format("rgb({0},{1},{2})", r,g,b);
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
                End = Monday.AddDays(t.Thu).AddHours(t.Tiet + t.So_tiet+1),
                Id = t.ID,
                Title = dicLopTC[t.ID_lop_tc].Ten_lop_tc,
                Color = dicLopTinChiColor[t.ID_lop_tc],
            }).ToDataSourceResult(request));
        }

        public List<PLAN_SukiensTinChi_TC> getSuKienTinChiDK(int ID_dt)
        {
            var lopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == this.ID_sv && t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky == HocKyDangKy.Ky_dang_ky).Select(t => t.PLAN_LopTinChi_TC).ToList();
            var idLopDKs = lopDKs.Select(t => t.ID_lop_tc).ToList();
            var suKienTinChis = new List<PLAN_SukiensTinChi_TC>();
            foreach (var idLopDK in idLopDKs)
            {
                var lopDK_SKTCs = db.PLAN_SukiensTinChi_TC.Where(t => t.ID_lop_tc == idLopDK).ToList();
                foreach (var lopDK_SKTC in lopDK_SKTCs)
                    suKienTinChis.Add(lopDK_SKTC);
            }
            return suKienTinChis;
        }

        public ActionResult DangKy(int ID_lop_tc, int ID_dt)
        {
            
            JsonResult result = new JsonResult();
            if (HetHanDK)
            {
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Data = { },
                    Message = "Đã hết hạn đăng ký trực tuyến!",
                };
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
            }
            
            var suKienTinChiDaDKs = this.getSuKienTinChiDK(ID_dt);

            var skLopTCs = db.PLAN_SukiensTinChi_TC.Where(t => t.ID_lop_tc == ID_lop_tc).ToList();
                        
            // Kiem tra trung lich hoc

            LopTinChiViewModel loptrung = new LopTinChiViewModel();
            foreach (var sktcNew in skLopTCs)
            {
                foreach (var sktc in suKienTinChiDaDKs)
                {
                    var TuNgayNew = new LocalDate(sktcNew.Tu_ngay.Year, sktcNew.Tu_ngay.Month, sktcNew.Tu_ngay.Day);
                    var DenNgayNew = new LocalDate(sktcNew.Den_ngay.Year, sktcNew.Den_ngay.Month, sktcNew.Den_ngay.Day);
                    var TuNgay = new LocalDate(sktc.Tu_ngay.Year, sktc.Tu_ngay.Month, sktc.Tu_ngay.Day);
                    var DenNgay = new LocalDate(sktc.Den_ngay.Year, sktc.Den_ngay.Month, sktc.Den_ngay.Day);
                    if (
                        ((TuNgayNew.WeekOfWeekYear >= TuNgay.WeekOfWeekYear && TuNgayNew.WeekOfWeekYear <= DenNgay.WeekOfWeekYear) || // Neu tuan bat dau cua lop tc moi nam trong giai doan cua lop tc da dk
                        (DenNgayNew.WeekOfWeekYear >= TuNgay.WeekOfWeekYear && DenNgayNew.WeekOfWeekYear <= DenNgay.WeekOfWeekYear)) && // hoac tuan ket thuc cua lop tc da dk
                        sktc.Thu == sktcNew.Thu && //thi xet trung thu - tiet
                        ((sktc.Tiet >= sktcNew.Tiet && sktc.Tiet <= sktcNew.Tiet + sktcNew.So_tiet) ||
                        (sktc.Tiet + sktc.So_tiet >= sktcNew.Tiet && sktc.Tiet + sktc.So_tiet <= sktcNew.Tiet + sktcNew.So_tiet))
                       )
                    {
                        loptrung = LopTinChi.getDetails(sktc.ID_lop_tc);
                        result.Data = new AjaxResult
                        {
                            Status = AjaxStatus.ERROR,
                            Title = "Thông báo",
                            Data = { },
                            Message = String.Format("Lớp bạn đăng ký đã bị trùng lịch với {0}!", loptrung.Ten_lop_tc),
                        };
                        result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                        return result;
                    }
                }
            }
            try
            {
                DangKyHocPhan.DangKy(ref db, ID_sv, ID_lop_tc, ID_dt, HocKyDangKy.Ky_dang_ky);
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
            
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        public ActionResult HuyDangKy(int ID_lop_tc, int ID_dt)
        {
            var result = new JsonResult();
            var lopTCs = db.STU_DanhSachLopTinChi.Where(t => t.ID_lop_tc == ID_lop_tc && t.ID_sv == this.ID_sv);
            if (lopTCs.Count() > 0)
            {
                var lopTC = lopTCs.First();
                db.STU_DanhSachLopTinChi.Remove(lopTC);
                db.SaveChanges();
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Data = { },
                    Message = String.Format("Hủy đăng ký lớp học phần {0} thành công!", LopTinChi.getDetails(lopTC.ID_lop_tc).Ten_lop_tc),
                };
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
            }
            else
            {
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Data = { },
                    Message = String.Format("Không thể thực hiện hành động này!"),
                };
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
            }
        }

        public ActionResult getChiTietHocPhan([DataSourceRequest]DataSourceRequest request ,int ID_dt)
        {
            var lop = sinhVien[ID_dt].STU_Lop;
            var idLopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv).Select(t => t.ID_lop_tc).ToList();
            var suKienTinChis = new List<PLAN_SukiensTinChi_TC>();
            foreach (var idLopDK in idLopDKs)
            {
                var lopDK_SKTCs = db.PLAN_SukiensTinChi_TC.Where(t => t.ID_lop_tc == idLopDK).ToList();
                foreach (var lopDK_SKTC in lopDK_SKTCs)
                    suKienTinChis.Add(lopDK_SKTC);
            }
            var lopTCs = LopTinChi.getListDetails(suKienTinChis).Values.ToList();
            try
            {
                var muchocphi = HocPhi.getMucHocPhi(db,HocKyDangKy.Ky_dang_ky,lop.ID_he,lop.ID_chuyen_nganh,lop.Khoa_hoc);

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
