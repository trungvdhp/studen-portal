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
    [InitializeSimpleMembership]
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

        
        public ActionResult getMonHoc(string KieuDK, int ID_dt)
        {
            JsonResult result = new JsonResult();
            DHHHContext db = new DHHHContext();
            var monDK = this.getMonDangKy(KieuDK,ID_dt).Select(t=>new {
                ID_mon = t.ID_mon,
                Ten_mon = t.MARK_MonHoc.Ten_mon,
            });
            result.Data = new SelectList(monDK, "ID_mon", "Ten_mon");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult getLopTC([DataSourceRequest]DataSourceRequest request, int? ID_mon)
        {
            DHHHContext db = new DHHHContext();
            //var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            //var sinhVien = SinhVien.GetSinhVien(userProfile);
            var lopTinChis = DangKyHocPhan.getLopTinChi(ID_mon);
            var idLopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == sinhVien.ID_sv).Select(t => t.ID_lop_tc).ToList();

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
            //var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            //var sinhVien = SinhVien.GetSinhVien(userProfile);
            JsonResult result = new JsonResult();
            result.Data = new SelectList(this.ChuyenNganh, "ID_dt", "Chuyen_nganh");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult getGiaiDoan()
        {
            DHHHContext db = new DHHHContext();
            //var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            //var sinhVien = SinhVien.GetSinhVien(userProfile);
            var idLopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == sinhVien.ID_sv).Select(t => t.ID_lop_tc).ToList();
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
        public ActionResult getThoiKhoaBieu([DataSourceRequest] DataSourceRequest request, int? ID_giai_doan)
        {
            DHHHContext db = new DHHHContext();
            //var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            //var sinhVien = SinhVien.GetSinhVien(userProfile);
            var idLopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == sinhVien.ID_sv).Select(t => t.ID_lop_tc).ToList();
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
                End = Monday.AddDays(t.Thu).AddHours(t.Tiet + t.So_tiet+1),
                Id = t.ID,
                Title = dicLopTC[t.ID_lop_tc].Ten_lop_tc,
                Color = dicLopTinChiColor[t.ID_lop_tc],
            }).ToDataSourceResult(request));
        }

        public List<PLAN_SukiensTinChi_TC> getSuKienTinChiDK()
        {
            var lopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == sinhVien.ID_sv && t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky == HocKyDangKy.Ky_dang_ky).Select(t => t.PLAN_LopTinChi_TC).ToList();
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

            var lopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == sinhVien.ID_sv && t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky==HocKyDangKy.Ky_dang_ky).Select(t=>t.PLAN_LopTinChi_TC).ToList();
            var idLopDKs = lopDKs.Select(t => t.ID_lop_tc).ToList();
            var suKienTinChiDaDKs = this.getSuKienTinChiDK();

            var skLopTCs = db.PLAN_SukiensTinChi_TC.Where(t => t.ID_lop_tc == ID_lop_tc).ToList();
            var lopTC = skLopTCs.First().PLAN_LopTinChi_TC;
            var ID_mon_tc = skLopTCs.First().PLAN_LopTinChi_TC.ID_mon_tc;
            
            // Kiem tra so tin chi 
            var hockyTruoc = this.HocKyTruoc;
            var xetLenLop = db.Mark_XetLenLop.Where(t => t.ID_sv == sinhVien.ID_sv && t.Hoc_ky == hockyTruoc.Hoc_ky && t.Nam_hoc == t.Nam_hoc);
            if (xetLenLop.Count()!=0)
            {
                var dkLenLop = xetLenLop.First();
                if (dkLenLop.Lan_canh_bao == 0)
                {
                    if (lopDKs.Sum(t => t.PLAN_MonTinChi_TC.So_tin_chi) > (int)CauHinh.get("So_TC_max"))
                    {
                        result.Data = new AjaxResult
                        {
                            Status = AjaxStatus.ERROR,
                            Title = "Thông báo",
                            Data = { },
                            Message = String.Format("Bạn không thể đăng ký quá {0} tín chỉ!", (int)CauHinh.get("So_TC_max")),
                        };
                        result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                        return result;
                    }
                }
                else
                {
                    if (lopDKs.Sum(t => t.PLAN_MonTinChi_TC.So_tin_chi) > (int)CauHinh.get("So_TC_CC_max"))
                    {
                        result.Data = new AjaxResult
                        {
                            Status = AjaxStatus.ERROR,
                            Title = "Thông báo",
                            Data = { },
                            Message = String.Format("Bạn đang bị cảnh cáo nên không thể đăng ký quá {0} tín chỉ!", (int)CauHinh.get("So_TC_CC_max")),
                        };
                        result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                        return result;
                    }
                }

            }
            
            
            LopTinChiViewModel loptrung = new LopTinChiViewModel();

            // Kiem tra mon hoc co nam trong danh sach mon duoc dang ky ko
            var ID_dts = SinhVien.getChuyenNganh(sinhVien.ID_sv).Select(t=>t.ID_dt).ToList();
            
            if (ID_dts.Contains(ID_dt))
            {
                var IdMonDKs = this.getMonDangKy("",ID_dt).Select(t => t.ID_mon).ToList();
                if (!IdMonDKs.Contains(lopTC.PLAN_MonTinChi_TC.ID_mon))
                {
                    result.Data = new AjaxResult
                    {
                        Status = AjaxStatus.ERROR,
                        Title = "Thông báo",
                        Data = { },
                        Message = String.Format("Bạn đang đăng ký môn ngoài chương trình đào tạo!"),
                    };
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    return result;
                }
            }

            
            // Kiem tra trung lich hoc
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
            
            
            // Kiem tra mon da dang ky truoc do hay chua
            var idMonDangKys = suKienTinChiDaDKs.Select(t => t.PLAN_LopTinChi_TC.ID_mon_tc).Distinct().ToList();
            if (idMonDangKys.Contains(ID_mon_tc))
            {
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Data = { },
                    Message = String.Format("Bạn đã đăng ký lớp cho môn học này. Để đăng ký lớp này, bạn phải hủy lớp đã có!"),
                };
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
            }
            
            // Kiem tra mon dang ky tuong duong
            var monTuongduongs = db.PLAN_ChuongTrinhDaoTaoMonTuongDuong.Where(t => t.ID_dt == ID_dt).Select(t => new
            {
                ID_mon = t.ID_mon,
                ID_mon_tuong_duong = t.ID_mon_tuong_duong,
            }).ToDictionary(t => t.ID_mon, t => t.ID_mon_tuong_duong);
            
            var daDkMonTuongDuong = false;
            foreach (var idMon in idMonDangKys)
            {
                
                if(monTuongduongs.ContainsKey(idMon) && monTuongduongs[idMon]==lopTC.PLAN_MonTinChi_TC.ID_mon)
                {
                    daDkMonTuongDuong = true;
                    break;
                }
            }
            if (daDkMonTuongDuong)
            {
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Data = { },
                    Message = String.Format("Bạn đã đămg ký môn tương đương với môn học này rồi!"),
                };
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
            }

            // Kiem tra mon da hoc tuong duong
            var monDaHoc = this.BangDiem.ToDictionary(t=> t.ID_mon,t=>t);
            foreach (var mon in monDaHoc.Values)
            {
                if (monTuongduongs.ContainsKey(mon.ID_mon) && SinhVien.DiemHe4[monDaHoc[mon.ID_mon].Diem_chu] >= SinhVien.DiemHe4["C+"])
                {
                    result.Data = new AjaxResult
                    {
                        Status = AjaxStatus.ERROR,
                        Title = "Thông báo",
                        Data = { },
                        Message = String.Format("Bạn đã học môn tương đương của môn học này rồi!"),
                    };
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    return result;
                }
            }
            // Kiem tra mon rang buoc
            var monRangBuoc = db.PLAN_ChuongTrinhDaoTaoRangBuoc.Where(t=>t.ID_dt==ID_dt ).ToDictionary(t => t.ID_mon, t => t);
            if (monRangBuoc.ContainsKey(lopTC.PLAN_MonTinChi_TC.ID_mon))
            {
                if ( monDaHoc.ContainsKey(monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].ID_mon_rb) && monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].Diem_rang_buoc > monDaHoc[monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].ID_mon_rb].Z)
                {
                    result.Data = new AjaxResult
                    {
                        Status = AjaxStatus.ERROR,
                        Title = "Thông báo",
                        Data = { },
                        Message = String.Format("Bạn phải học môn {0} trước và có điểm đạt tối thiểu {1:1} có thể đăng ký môn này!", monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].Mon_Rang_Buoc.Ten_mon, monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].Diem_rang_buoc),
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
                        Message = String.Format("Bạn phải học môn {0} trước mới có thể đăng ký môn này!", monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].Mon_Rang_Buoc.Ten_mon),
                    };
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    return result;
                }
            }
            

            db.STU_DanhSachLopTinChi.Add(new STU_DanhSachLopTinChi
            {
                ID_lop_tc = ID_lop_tc,
                ID_sv = sinhVien.ID_sv,
                Duyet = 0,
            });
            db.SaveChanges();

            result.Data = new AjaxResult
            {
                Status = AjaxStatus.SUCCESS,
                Title = "Thông báo",
                Data = { },
                Message = "Đã đăng ký thành công!"
            };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        public ActionResult HuyDangKy(int ID_lop_tc, int ID_dt)
        {
            var result = new JsonResult();

            var lopTCs = db.STU_DanhSachLopTinChi.Where(t => t.ID_lop_tc == ID_lop_tc && t.ID_sv == sinhVien.ID_sv);
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
    }
}
