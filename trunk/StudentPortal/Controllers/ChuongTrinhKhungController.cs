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
    public class ChuongTrinhKhungController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int ID_dt)
        {
            
        }
    }
}
