using StudentPortalLib.Lib;
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
    public class LogController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.ActionList = new SelectList(Log.LogDic,"Key","Value");
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request,int Thao_tac)
        {
            var data = Log.Read(db,0,(LogAct)Thao_tac).Select(t => new LogViewModel { 
                UserId = t.User_id,
                Ip = t.User_ip,
                Thao_tac = Log.LogDic[(LogAct)t.Thao_tac],
                Tham_so = t.Tham_so,
                Thoi_gian = t.Thoi_gian,
                Id = t.Id,
                Username = StudentPortal.Lib.User.getUserFullName(t.UserProfile.UserName)
            });
            return Json(data.ToDataSourceResult(request));
        }
    }
}
