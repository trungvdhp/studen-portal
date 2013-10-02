using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using StudentPortal.ViewModels;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class LopHanhChinhController : BaseController
    {
        //
        // GET: /Admin/LopHanhChinh/

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
            result.Data = new SelectList(db.STU_Lop.Where(t=>t.ID_he==ID_he && t.ID_chuyen_nganh==ID_chuyen_nganh).Select(t=> new{
                Khoa_hoc = t.Khoa_hoc
            }).Distinct().ToList(), "Khoa_hoc", "Khoa_hoc");
            return result;
        }

        public ActionResult getLopHC([DataSourceRequest] DataSourceRequest request, int ID_he, int? ID_Chuyen_nganh, int? Khoa_hoc)
        {
            var lops = db.STU_Lop.Where(t => t.ID_he == ID_he).ToList();

            if (ID_Chuyen_nganh != null) lops = lops.Where(t => t.ID_chuyen_nganh == ID_Chuyen_nganh).ToList();
            if (Khoa_hoc != null) lops = lops.Where(t => t.Khoa_hoc == Khoa_hoc).ToList();

            var result = lops.Select(t => new LopHanhChinhViewModel { 
                ID_lop = t.ID_lop,
                Ten_lop = t.Ten_lop,
                Nien_khoa = t.Nien_khoa,
            }).ToList();

            return Json(lops.ToDataSourceResult(request));
        }

        public ActionResult getSinhVien([DataSourceRequest] DataSourceRequest request, int ID_lop)
        {
            var sinhviens = db.STU_DanhSach.Where(t => t.ID_lop == ID_lop).Select(t => new SinhVienViewModel { 
                ID_sv = t.ID_sv,
                Ma_sv = t.STU_HoSoSinhVien.Ma_sv,
                Ho_ten = t.STU_HoSoSinhVien.Ho_ten
            }).ToList();

            return Json(sinhviens.ToDataSourceResult(request));
        }
    }
}
