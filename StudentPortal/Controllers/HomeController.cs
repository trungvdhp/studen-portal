using StudentPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var news = new List<NewsViewModel>();
            try
            {
                news = db.News.OrderByDescending(t => t.Id).Take(20).Select(t => new NewsViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    PostDate = t.PostDate,
                    User = t.User.UserName,
                    LastEditUser = t.LastEditUser.UserName,
                    LastEditDate = t.LastEditDate
                }).ToList();
            }
            catch (Exception)
            { }
            ViewBag.News = news;

            return View();
        }

        [Authorize(Roles="SinhVien")]
        public ActionResult getDiemHocKy()
        {
            var bangdiem = this.getDiemHocTap(sinhVien.Values.First().STU_Lop.ID_dt);
            var diemTBMHKs = bangdiem.Where(t => t.Ten_mon == "TBMHK").Select(t => new TBMHKViewModel
            {
                Diem = t.Z,
                Diem_chu = t.Diem_chu,
                Hoc_ky = t.Nam_hoc + "_" + t.Hoc_ky,
            }).OrderBy(t => t.Hoc_ky).ToList();
            return Json(diemTBMHKs);
        }

        public ActionResult getNewFeeds()
        {
            var feeds = db.Inbox.Where(t => t.To == userProfile.UserId && t.Type == InboxModel.INBOX && t.Status == false && t.Warning == false);
            var FeedsCount = feeds.Count();
            List<InboxViewModel> Feeds = new List<InboxViewModel>();
            List<InboxViewModel> Notifications = new List<InboxViewModel>();
            if (feeds.Count() > 0)
            {
                Feeds = feeds.ToList().Select(t => new InboxViewModel
                {
                    Postdate = t.Postdate,
                    Title = t.Title,
                    From = Lib.User.getUserFullName(t.FromUser.UserName),
                    Id = t.ID,
                    Link = Url.Action("Detail", "Message", new { Area = "", Id = t.ID })
                }).Take(10).ToList();
            }
            var notifications = db.Inbox.Where(t => t.To == userProfile.UserId && t.Type == InboxModel.INBOX && t.Status == false && t.Warning == true);
            var NotificationsCount = notifications.Count();
            if (notifications.Count() > 0)
            {
                Notifications = notifications.ToList().Select(t => new InboxViewModel
                {
                    Postdate = t.Postdate,
                    Title = t.Title,
                    From = Lib.User.getUserFullName(t.FromUser.UserName),
                    Id = t.ID,
                    Link = Url.Action("Detail", "Message", new { Area = "" ,Id = t.ID})
                }).Take(10).ToList();
            }
            return Json(new { 
                FeedsCount = FeedsCount,
                NotificationsCount = NotificationsCount,
                Feeds = Feeds,
                Notifications = Notifications,

            },JsonRequestBehavior.AllowGet);
        }
    }
}
