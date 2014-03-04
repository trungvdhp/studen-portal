using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class HoSoController : BaseController
    {

        public ActionResult Index()
        {
            ViewBag.SinhVien = this.sinhVien;
            return View();
        }

    }
}
