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
            result.Data = new SelectList(db.PLAN_HocKyDangKy_TC.ToList().Select(t => new StudentPortal.ViewModels.KyDangKy
            {
                Ky_dang_ky = t.Ky_dang_ky,
                Ten_ky = t.Nam_hoc + "_" + t.Hoc_ky + "_" + t.Dot,
            }).OrderBy(t => t.Ky_dang_ky).ToList(), "Ky_dang_ky", "Ten_ky");
            return result;
        }

        public ActionResult ChuyenLop(int ID_lop_tc, string IDs,int ID_lop_tc_cu)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var ID_svs = Utilities.string2list(IDs);
            try
            {
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

        public ActionResult getLopTCKhac(int ID_mon,int ID_lop_tc)
        {
            var lopTinChis = DangKyHocPhan.getLopTinChi(ID_mon);
            lopTinChis.Remove(lopTinChis.Single(t => t.ID_lop_tc == ID_lop_tc));
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(lopTinChis, "ID_lop_tc", "Ten_lop_tc");
            return result;
        }

        public ActionResult getLopTC([DataSourceRequest] DataSourceRequest request, int ID_mon)
        {
            var lopTinChis = DangKyHocPhan.getLopTinChi(ID_mon);
            return Json(lopTinChis.ToDataSourceResult(request));
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
