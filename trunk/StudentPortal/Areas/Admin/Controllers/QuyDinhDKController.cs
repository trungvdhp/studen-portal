using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class QuyDinhDKController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Get([DataSourceRequest] DataSourceRequest request)
        //{
            
        //}


        public ActionResult getHocKy()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.PLAN_QUYDINH_DANGKY.Where(t => t.Ky_dang_ky != 0).Select(t => new
            {
                Ky_dang_ky = t.Ky_dang_ky,
                Nam_hoc = t.PLAN_HocKyDangKy_TC.Nam_hoc,
                Hoc_ky = t.PLAN_HocKyDangKy_TC.Hoc_ky,
            }).Distinct().ToList().Select(t => new
            {
                Ky_dang_ky = t.Ky_dang_ky,
                Nam_hoc = t.Nam_hoc + "_" + t.Hoc_ky,
            }), "Ky_dang_ky", "Nam_hoc");

            return result;
        }
    }
}
