using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class NewsController : BaseController
    {
        public ActionResult Details(int Id)
        {
            if (db.News.Count(t => t.Id == Id) == 0) return Redirect(Url.Action("404","Error"));
            ViewBag.News = db.News.Single(t => t.Id == Id);
            return View();
        }

    }
}
