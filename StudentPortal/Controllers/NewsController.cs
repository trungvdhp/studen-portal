using StudentPortal.ViewModels;
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
            var news = db.News.Single(t => t.Id == Id);
            ViewBag.News = new NewsViewModel {
                Title = news.Title,
                Contents = news.Contents,
                Description = news.Contents,
                PostDate = news.PostDate,
                User = news.User.UserName,
                
            };
            return View();
        }

    }
}
