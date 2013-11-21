using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using StudentPortal.ViewModels;
using StudentPortal.Lib;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class DanhSachSVDKController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult getLopDK([DataSourceRequest] DataSourceRequest request,int ID_danh_sach)
        {
            return Json(SinhVien.GetLopDaDK(ID_danh_sach, HocKyDangKy.Ky_dang_ky).ToDataSourceResult(request));
        }

        public ActionResult getSVDK([DataSourceRequest]DataSourceRequest request, int ID_he = 0, int ID_chuyen_nganh = 0,int ID_lop =0,bool DK_khong_hop_le=false)
        {
            var dsLopTC = db.STU_DanhSachLopTinChi.Where(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky == HocKyDangKy.Ky_dang_ky);
            if (ID_he != 0)
                dsLopTC = dsLopTC.Where(t => t.STU_DanhSach.STU_Lop.ID_he == ID_he);
            if (ID_chuyen_nganh != 0)
                dsLopTC = dsLopTC.Where(t => t.STU_DanhSach.STU_Lop.ID_chuyen_nganh == ID_chuyen_nganh);
            if (ID_lop != 0)
                dsLopTC = dsLopTC.Where(t => t.STU_DanhSach.ID_lop == ID_lop);
            var svDK = dsLopTC.GroupBy(t => new
            {
                ID_danh_sach = t.ID_danh_sach,
                ID_sv = t.ID_sv,
                Ma_sv = t.STU_HoSoSinhVien.Ma_sv,
                Ho_ten = t.STU_HoSoSinhVien.Ho_ten,
                Lop = t.STU_DanhSach.STU_Lop.Ten_lop,
            }).Select(u => new SinhVienViewModel
            {
                ID_danh_sach = u.Key.ID_danh_sach,
                ID_sv = u.Key.ID_sv,
                Ma_sv = u.Key.Ma_sv,
                Ho_ten = u.Key.Ho_ten,
                Lop = u.Key.Lop,
                So_tin_chi = u.Sum(v => v.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.So_tin_chi),
            });

            var result = (from a in svDK
                       from b in db.ViewXetLenLop.Where(b => b.ID_sv == a.ID_sv).DefaultIfEmpty()
                       select new
                       {
                           ID_danh_sach = a.ID_danh_sach,
                           ID_sv = a.ID_sv,
                           Ma_sv = a.Ma_sv,
                           Ho_ten = a.Ho_ten,
                           Lop = a.Lop,
                           So_tin_chi = a.So_tin_chi,
                           Lan_canh_bao = b.Lan_canh_bao,
                       }
                    );
            if (DK_khong_hop_le && !HocKyDangKy.Ky_phu)
            {
                int So_TC_min = (int) CauHinh.get("So_TC_min",HocKyDangKy.Ky_dang_ky);
                int So_TC_CC_min = (int) CauHinh.get("So_TC_CC_min",HocKyDangKy.Ky_dang_ky);
                result = result.Where(t => (t.Lan_canh_bao == 0 && t.So_tin_chi < So_TC_min) || t.So_tin_chi < So_TC_CC_min);
            }
            return Json(result.ToDataSourceResult(request));
        }

    }
}
