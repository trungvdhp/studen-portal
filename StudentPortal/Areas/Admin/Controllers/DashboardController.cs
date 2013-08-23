using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Admin/Dashboard/
        //[Authorize(Roles="Dashboard.Index")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
