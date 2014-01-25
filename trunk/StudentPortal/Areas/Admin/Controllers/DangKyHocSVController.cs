using StudentPortal.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using StudentPortal.Lib;
using StudentPortal.ViewModels;
using StudentPortalLib.Lib;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class DangKyHocSVController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getHocKy(int ID_sv, int ID_dt)
        {
            var hocky = SinhVien.getHocKyDangKy(ID_sv, ID_dt, db)
                .Select(t => new KyDangKy
                {
                    Ky_dang_ky = t.Ky_dang_ky,
                    Ten_ky = "Năm học " + t.Nam_hoc + ", học kỳ " + t.Hoc_ky + ", đợt " + t.Dot
                }).ToList();
            var result = new SelectList(hocky, "Ky_dang_ky", "Ten_ky");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getChuyenNganh(int ID_sv)
        {
            JsonResult result = new JsonResult();
            result.Data = new SelectList(SinhVien.getChuyenNganh(ID_sv), "ID_dt", "Chuyen_nganh");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        //public ActionResult getMonDaDK([DataSourceRequest]DataSourceRequest request, string TuKhoa, int ID_dt, int? Ky_dang_ky)
        //{
        //    if (Ky_dang_ky == null)
        //    {
        //        return Json(new List<MARK_MonHoc>());
        //    }
        //    int ID_sv = SinhVien.GetIdSv(TuKhoa);
        //    var idMonCCDT = ChuongTrinhDaoTao.getChuongTrinhKhung(ID_dt);
        //    var monDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv && t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky == Ky_dang_ky).Select(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC).Distinct().ToList();
        //    //SinhVien.GetMonDaDK(int ID_sv,int ID_dt,int Ky_dang_ky, DHHHContext db);
        //    return Json(monDKs.ToDataSourceResult(request));
        //}
        public ActionResult getLopTCDaDK([DataSourceRequest]DataSourceRequest request, int ID_sv, int Ky_dang_ky)
        {
            var lopDKs = db.STU_DanhSachLopTinChi
                .Where(t => t.ID_sv == ID_sv && t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky == Ky_dang_ky)
                //.Select(t => t.ID_lop_tc)
                .ToList()
                .Select(t => LopTinChi.getDetails(t.ID_lop_tc, t.Rut_bot_hoc_phan == null ? false : t.Rut_bot_hoc_phan.Value, t.Huy_dang_ky)).ToList();
            return Json(lopDKs.ToDataSourceResult(request));
        }
        public ActionResult getMonDK([DataSourceRequest]DataSourceRequest request, int ID_sv, int ID_dt, int Ky_dang_ky)
        {
            if (Ky_dang_ky == null)
            {
                return Json(new List<MARK_MonHoc>());
            }
            var sinhvien = db.STU_DanhSach.Single(t => t.ID_sv == ID_sv && t.STU_Lop.ID_dt == ID_dt);
            List<PLAN_MonTinChi_TC> monDKs = DangKyHocPhan.getMonDangKy(sinhvien, KieuDangKy.TATCA, ID_dt, Ky_dang_ky);
            return Json(monDKs.ToDataSourceResult(request));
        }
        public ActionResult getLopDK([DataSourceRequest]DataSourceRequest request, int ID_mon_tc, int ID_sv, int ID_dt, int Ky_dang_ky)
        {
            var lopTCDaDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv && t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky == Ky_dang_ky).Select(t => t.ID_lop_tc).ToList();
            var lopDKs = db.PLAN_LopTinChi_TC.Where(t => t.ID_mon_tc == ID_mon_tc).Select(t => t.ID_lop_tc).ToList().Where(t => !lopTCDaDKs.Contains(t)).Select(t => LopTinChi.getDetails(t)).ToList();
            return Json(lopDKs.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult DangKy(int ID_sv, int ID_lop_tc, int ID_dt, int Ky_dang_ky)
        {
            var result = new JsonResult();
            //try
            //{
                var lopTC = db.PLAN_LopTinChi_TC.Single(t => t.ID_lop_tc == ID_lop_tc);

                if (lopTC.ID_lop_lt == 0 && db.PLAN_LopTinChi_TC.Count(t => t.ID_lop_lt == ID_lop_tc) > 0)
                {
                    throw new Exception("Bạn phải đăng ký cả lớp thực hành của lớp lý thuyết này");
                }

                //KiemTraTrungLich(ID_lop_tc, ID_dt);
                if (lopTC.ID_lop_lt > 0)
                {
                    //KiemTraTrungLich(lopTC.ID_lop_lt, ID_dt);
                    DangKyHocPhan.KiemTraDieuKienDangKy(ref db, ID_sv, lopTC.ID_lop_lt, ID_dt, Ky_dang_ky);
                }
                DangKyHocPhan.KiemTraDieuKienDangKy(ref db, ID_sv, ID_lop_tc, ID_dt, Ky_dang_ky);

                db.STU_DanhSachLopTinChi.Add(new STU_DanhSachLopTinChi
                {
                    ID_lop_tc = ID_lop_tc,
                    ID_sv = ID_sv,
                    Duyet = 0,
                });
                if (lopTC.ID_lop_lt > 0)
                {
                    db.STU_DanhSachLopTinChi.Add(new STU_DanhSachLopTinChi
                    {
                        ID_lop_tc = lopTC.ID_lop_lt,
                        ID_sv = ID_sv,
                        Duyet = 0,
                    });
                }

                try
                {
                    DangKyHocPhan.KiemTraSoMonDK(ID_sv, ID_dt, HocKyDangKy, db);
                    db.STU_DanhSach.Single(t => t.ID_sv == ID_sv).Trang_thai_dk = null;
                }
                catch (Exception e1)
                {
                    db.STU_DanhSach.Single(t => t.ID_sv == ID_sv).Trang_thai_dk = e1.Message;
                }


                db.SaveChanges();

                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Message = "Đã đăng ký thành công!"
                };
                var sv = SinhVien.GetSinhVien(db,ID_sv);
                var lop = LopTinChi.getDetails(ID_lop_tc);
                Log.Write(this.userProfile.UserId, "", LogAct.DANGKY, String.Format("{0}, mã sv: {1}, vào lớp {2}", sv.STU_HoSoSinhVien.Ho_ten, sv.STU_HoSoSinhVien.Ma_sv, lop.Ten_lop_tc));
            //}
            //catch (Exception e)
            //{
            //    result.Data = new AjaxResult
            //    {
            //        Status = AjaxStatus.ERROR,
            //        Title = "Thông báo",
            //        Message = e.Message,
            //    };
            //}

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult Huy(int ID_sv, int ID_lop_tc)
        {
            var result = new JsonResult();
            try
            {
                var lopTHs = db.STU_DanhSachLopTinChi.Where(t => t.PLAN_LopTinChi_TC.ID_lop_lt == ID_lop_tc && t.ID_sv == this.ID_sv);
                foreach (var lopTH in lopTHs)
                    db.STU_DanhSachLopTinChi.Remove(lopTH);
                var lopTC = db.STU_DanhSachLopTinChi.Single(t => t.ID_lop_tc == ID_lop_tc && t.ID_sv == this.ID_sv);

                if (lopTC.PLAN_LopTinChi_TC.ID_lop_lt != 0)
                {
                    var lopLT = db.STU_DanhSachLopTinChi.Single(t => t.ID_lop_tc == lopTC.PLAN_LopTinChi_TC.ID_lop_lt && t.ID_sv == this.ID_sv);
                    db.STU_DanhSachLopTinChi.Remove(lopLT);
                }
                db.STU_DanhSachLopTinChi.Remove(lopTC);

                db.SaveChanges();
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Data = { },
                    Message = String.Format("Hủy đăng ký lớp học phần {0} thành công!", LopTinChi.getDetails(lopTC.ID_lop_tc).Ten_lop_tc),
                };
                var sv = SinhVien.GetSinhVien(db, ID_sv);
                var lop = LopTinChi.getDetails(ID_lop_tc);
                Log.Write(this.userProfile.UserId, "", LogAct.HUYHP, String.Format("{0}, mã sv: {1}, vào lớp {2}", sv.STU_HoSoSinhVien.Ho_ten, sv.STU_HoSoSinhVien.Ma_sv, lop.Ten_lop_tc));
            }
            catch (Exception e)
            {
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Data = { },
                    Message = e.Message,
                };
            }

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult Rut(int ID_sv, int ID_lop_tc)
        {
            var result = new JsonResult();
            try
            {
                // Neu lop rut la lop ly thuyet, lay tat ca cac lop thuc hanh
                var lopTHs = db.STU_DanhSachLopTinChi.Where(t => t.PLAN_LopTinChi_TC.ID_lop_lt == ID_lop_tc && t.ID_sv == this.ID_sv);

                // Rut lop thuc tat ca lop thuc hanh
                foreach (var lopTH in lopTHs)
                    db.STU_DanhSachLopTinChi.Single(t => t.ID_lop_tc == lopTH.ID_lop_tc).Rut_bot_hoc_phan = true;

                var lopTC = db.STU_DanhSachLopTinChi.Single(t => t.ID_lop_tc == ID_lop_tc && t.ID_sv == this.ID_sv);
                //var tenhocphan = lopTC.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.MARK_MonHoc.Ten_mon;
                // Neu lop la lop thuc hanh
                if (lopTC.PLAN_LopTinChi_TC.ID_lop_lt != 0)
                {
                    // Tim lop ly thuyet va rut
                    var lopLT = db.STU_DanhSachLopTinChi.Single(t => t.ID_lop_tc == lopTC.PLAN_LopTinChi_TC.ID_lop_lt && t.ID_sv == this.ID_sv);
                    lopLT.Rut_bot_hoc_phan = true;
                }

                lopTC.Rut_bot_hoc_phan = true;

                db.SaveChanges();
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Data = { },
                    Message = String.Format("Rút đăng ký học phần {0} thành công!", lopTC.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.MARK_MonHoc.Ten_mon),
                };
                var sv = SinhVien.GetSinhVien(db, ID_sv);
                var lop = LopTinChi.getDetails(ID_lop_tc);
                Log.Write(this.userProfile.UserId, "", LogAct.RUTHP, String.Format("{0}, mã sv: {1}, vào lớp {2}", sv.STU_HoSoSinhVien.Ho_ten, sv.STU_HoSoSinhVien.Ma_sv, lop.Ten_lop_tc));
            }
            catch (Exception e)
            {
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Data = { },
                    Message = e.Message,
                };
            }

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult HuyRut(int ID_sv, int ID_lop_tc)
        {
            return View();
        }
    }
}
