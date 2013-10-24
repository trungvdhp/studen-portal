using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using StudentPortal.ViewModels;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class CauHinhController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest]DataSourceRequest request, int? Ky_dang_ky)
        {
            return Json(db.CauHinh.Where(t=>t.Ky_dang_ky==Ky_dang_ky).Select(t => new CauHinhViewModel { 
                Id = t.Id,
                Ten = t.Ten,
                Gia_tri = t.Gia_tri,
                Mo_ta = t.Mo_ta,
                Ky_dang_ky = (int)t.Ky_dang_ky
            }).ToDataSourceResult(request));
        }
        public ActionResult getHocKy()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.CauHinh.Where(t=>t.Ky_dang_ky!=0).Select(t=>new {
                Ky_dang_ky = t.Ky_dang_ky,
                Nam_hoc = t.PLAN_HocKyDangKy_TC.Nam_hoc,
                Hoc_ky = t.PLAN_HocKyDangKy_TC.Hoc_ky,
            }).Distinct().ToList().Select(t=>new{
                Ky_dang_ky = t.Ky_dang_ky,
                Nam_hoc = t.Nam_hoc + "_"+t.Hoc_ky,
            }), "Ky_dang_ky", "Nam_hoc");

            //Select(t => new { 
            //    Ky_dang_ky = t.Ky_dang_ky, 
            //    Nam_hoc = t.PLAN_HocKyDangKy_TC.Nam_hoc, 
            //    Hoc_ky = t.PLAN_HocKyDangKy_TC.Hoc_ky
            //})
            //.ToList().Select(t=>new{
            //    Ky_dang_ky = t.Ky_dang_ky,
            //    Nam_hoc = t.Nam_hoc+"_"+t.Hoc_ky
            //})
            return result;
        }

        public ActionResult Update(int Id, string Gia_tri)
        {
            var result = new JsonResult() { JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            try
            {
                var cauhinh = db.CauHinh.Single(t=>t.Id==Id);
                switch (cauhinh.Kieu)
                {
                    case "int":
                        cauhinh.Gia_tri = Convert.ToInt32(Gia_tri).ToString();
                        break;
                    default:
                        cauhinh.Gia_tri = Gia_tri;
                        break;
                }
                db.SaveChanges();
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.SUCCESS,
                    Message = "Lưu thành công!",
                };
            }
            catch (Exception e)
            {
                result.Data = new AjaxResult
                   {
                       Status = AjaxStatus.ERROR,
                       Message = e.Message,
                   };
            }
            return result;
        }

    //    public ActionResult Destroy(int Id)
    //    {
    //        var result = new JsonResult() { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    //        try
    //        {
    //            db.CauHinh.Remove(db.CauHinh.Single(t => t.Id == Id));
    //            db.SaveChanges();
    //            result.Data = new AjaxResult
    //            {
    //                Status = AjaxStatus.SUCCESS,
    //                Message = "Đã xóa!",
    //            };
    //        }
    //        catch (Exception e)
    //        {
    //            result.Data = new AjaxResult
    //            {
    //                Status = AjaxStatus.ERROR,
    //                Message = e.Message,
    //            };
    //        }
    //        return result;
    //    }
    }
}
