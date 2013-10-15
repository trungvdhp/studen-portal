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

            var news = db.News.OrderByDescending(t => t.Id).Take(20).Select(t => new NewsViewModel
            {
                Id = t.Id,
                Title = t.Title,
                PostDate = t.PostDate,
                User = t.User.UserName,
                LastEditUser = t.LastEditUser.UserName,
                LastEditDate = t.LastEditDate
            }).ToList();
            ViewBag.News = news;

            return View();
        }


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
    }
}
