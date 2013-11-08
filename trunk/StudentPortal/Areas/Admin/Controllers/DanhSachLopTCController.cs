using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.ViewModels;
using StudentPortal.Lib;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class DanhSachLopTCController : BaseController
    {
        //
        // GET: /Admin/DanhSachLopTC/

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

        public ActionResult getKyDangKy()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.PLAN_LopTinChi_TC.Select(t => t.PLAN_MonTinChi_TC.PLAN_HocKyDangKy_TC).Distinct().ToList().Select(t=>new {
                Ky_dang_ky = t.Ky_dang_ky,
                Ten_ky = String.Format("{0}_{1}_{2}",t.Nam_hoc,t.Hoc_ky,t.Dot)
            }).ToList(), "Ky_dang_ky", "Ten_ky");
            return result;
        }

        public ActionResult ChuyenLop(int ID_lop_tc, string IDs,int ID_lop_tc_cu)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var ID_svs = Utilities.string2list(IDs);
            try
            {
                var lopTCCu = db.PLAN_LopTinChi_TC.Single(t => t.ID_lop_tc == ID_lop_tc_cu);
                if (lopTCCu == null)
                    throw new Exception("Dữ liệu không hợp lệ!");
                var lopTCMoi = db.PLAN_LopTinChi_TC.Single(t => t.ID_lop_tc == ID_lop_tc);
                if (lopTCCu == null)
                    throw new Exception("Lớp tín chỉ bạn định chuyển không tồn tại hoặc đã bị xóa!");
                if (lopTCCu.ID_lop_lt != lopTCMoi.ID_lop_lt || lopTCMoi.ID_mon_tc != lopTCCu.ID_mon_tc)
                {
                    throw new Exception("Không thể chuyển qua lớp đã chọn!");
                }
                foreach (var ID_sv in ID_svs)
                {
                    var dangky = db.STU_DanhSachLopTinChi.Single(t => t.ID_sv == ID_sv && t.ID_lop_tc == ID_lop_tc_cu);
                    dangky.PLAN_LopTinChi_TC = db.PLAN_LopTinChi_TC.Single(t => t.ID_lop_tc == ID_lop_tc);
                }
                db.SaveChanges();
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Message = "Chuyển lớp thành công!",
                };
            }
            catch (Exception)
            {
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Message = "Đã có lỗi xảy ra!",
                };
            }
            return result;
        }

        public ActionResult HuyLopTC(int ID_lop_tc)
        {
            var result = new JsonResult() { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            try
            {
                if (db.STU_DanhSachLopTinChi.Count(t => t.ID_lop_tc == ID_lop_tc) > 0)
                    throw new Exception("Bạn không thể hủy lớp đang có sinh viên đăng ký");
                var lopTC = db.PLAN_LopTinChi_TC.Single
                    (t => t.ID_lop_tc == ID_lop_tc);
                if (lopTC == null) throw new Exception("Lớp tín chỉ không tồn tại!");
                db.PLAN_LopTinChi_TC.Remove(lopTC);
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.SUCCESS,
                    Message = "Đã hủy thành công!"
                };
            }
            catch (Exception e)
            {
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.ERROR,
                    Message = e.Message
                };
            }

            return result;
        }

        public ActionResult RutHocPhan(int ID_lop_tc, string IDs)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var ID_svs = Utilities.string2list(IDs);
            try
            {
                foreach (var ID_sv in ID_svs)
                {
                    var dangky = db.STU_DanhSachLopTinChi.Single(t => t.ID_sv == ID_sv && t.ID_lop_tc == ID_lop_tc);
                    dangky.Rut_bot_hoc_phan = true;
                }
                db.SaveChanges();
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Message = "Đã thực hiện!",
                };
            }
            catch (Exception)
            {
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Message = "Đã có lỗi xảy ra!",
                };
            }
            return result;
        }

        private List<MARK_MonHoc> listMonTC(int ID_chuyen_nganh, int Ky_dang_ky)
        {
            var idMonChuyenNganhs = db.PLAN_ChuongTrinhDaoTaoChiTiet
                .Where(t => t.PLAN_ChuongTrinhDaoTao.ID_chuyen_nganh == ID_chuyen_nganh)
                .Select(t => t.ID_mon).Distinct()
                .ToList();
            var monMos = db.PLAN_LopTinChi_TC.Where(t => t.PLAN_MonTinChi_TC.Ky_dang_ky == Ky_dang_ky).Select(t => t.PLAN_MonTinChi_TC.MARK_MonHoc).Distinct().ToList();
            var monHeDTs = new List<MARK_MonHoc>();
            foreach (var mon in monMos)
            {
                if (idMonChuyenNganhs.Contains(mon.ID_mon))
                    monHeDTs.Add(mon);
            }
            return monHeDTs.ToList();
        }

        public ActionResult getMonTC(int ID_chuyen_nganh, int Ky_dang_ky)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(listMonTC(ID_chuyen_nganh,Ky_dang_ky), "ID_mon", "Ten_mon");
            return result;
        }

        public ActionResult getLopTCKhac(int ID_lop_tc, int Ky_dang_ky)
        {
            var lopTC = db.PLAN_LopTinChi_TC.Single(t => t.ID_lop_tc == ID_lop_tc);
            var lopTinChis = DangKyHocPhan.getLopTinChi(lopTC.PLAN_MonTinChi_TC.ID_mon, Ky_dang_ky,false);
            lopTinChis.Remove(lopTinChis.Single(t => t.ID_lop_tc == ID_lop_tc));
            lopTinChis = lopTinChis.Where(t => t.ID_lop_lt == lopTC.ID_lop_lt).ToList();
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(lopTinChis, "ID_lop_tc", "Ten_lop_tc");
            return result;
        }

        public ActionResult getLopTC([DataSourceRequest] DataSourceRequest request, int ID_chuyen_nganh, int? ID_mon, int Ky_dang_ky, bool? Co_SKTC)
        {
            var lopTinChis = new List<LopTinChiViewModel>();
            if (ID_mon != null)
            {
                lopTinChis = DangKyHocPhan.getLopTinChi((int)ID_mon, Ky_dang_ky, (bool)Co_SKTC);
            }
            else if(ID_chuyen_nganh!=0 && Ky_dang_ky!=0){
                var mons = listMonTC(ID_chuyen_nganh, Ky_dang_ky);
                foreach (var mon in mons)
                {
                    lopTinChis.AddRange(DangKyHocPhan.getLopTinChi((int)mon.ID_mon, Ky_dang_ky, (bool)Co_SKTC));
                }
            }
            return Json(lopTinChis.ToDataSourceResult(request));;
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
                Rut_bot_hoc_phan = (bool)t.Rut_bot_hoc_phan,
            }).ToList().Select(t => new SinhVienViewModel
            {
                ID_sv = t.ID_sv,
                Ho_ten = t.Ho_ten,
                Lop = SinhVien.Lop[t.ID_sv].Ten_lop,
                Ma_sv = t.Ma_sv,
                Duyet = t.Duyet,
                Rut_bot_hoc_phan = (bool)t.Rut_bot_hoc_phan,
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
        public ActionResult DuyetDKs(int ID_lop_tc, string IDs)
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
        public ActionResult BoDuyetDKs(int ID_lop_tc, string IDs)
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
    }
}
