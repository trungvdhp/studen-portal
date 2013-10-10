using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.Lib;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace StudentPortal.Controllers
{
    public class ChuongTrinhKhungController : BaseController
    {


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getHe()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.STU_He.ToList(), "ID_he", "Ten_he");
            return result;
        }

        public ActionResult getKhoa()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.STU_Khoa.ToList(), "ID_khoa", "Ten_khoa");
            return result;
        }

        public ActionResult getKhoaHoc()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.PLAN_ChuongTrinhDaoTao.Select(t=>new {Khoa_hoc = t.Khoa_hoc}).Distinct().ToList(), "Khoa_hoc", "Khoa_hoc");
            return result;
        }

        public ActionResult getChuyenNganh(int ID_he,int ID_khoa,int Khoa_hoc)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.STU_Lop.Where(t=>t.ID_he==ID_he && t.ID_khoa==ID_khoa && t.Khoa_hoc==Khoa_hoc).ToList().Select(t=>new{
                ID_chuyen_nganh = t.ID_chuyen_nganh,
                Chuyen_nganh = t.STU_ChuyenNganh.Chuyen_nganh
            }).Distinct().ToList() , "ID_chuyen_nganh", "Chuyen_nganh");
            return result;
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int ID_he,int ID_khoa,int Khoa_hoc, int ID_chuyen_nganh)
        {
            try
            {
                var chuongtrinhdaotao = db.PLAN_ChuongTrinhDaoTao.Single(t => t.ID_he == ID_he && t.ID_khoa == ID_khoa && t.Khoa_hoc == Khoa_hoc && t.ID_chuyen_nganh == ID_chuyen_nganh);
                return Json(ChuongTrinhDaoTao.getChuongTrinhKhung(chuongtrinhdaotao.ID_dt).ToDataSourceResult(request));
            }
            catch (Exception)
            {
                return Json(new { });
            }
        }
    }
}
