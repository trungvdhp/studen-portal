using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using StudentPortal.ViewModels;
using StudentPortal.Lib;
using System.Web.Script.Serialization;

namespace StudentPortal.Areas.Admin.Controllers
{
    //[Authorize(Roles="Admin.News")]
    public class NewsController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(string Title, string Contents, string Description)
        {
            db.News.Add(new NewsModel
            {
                Title = Title,
                Contents = Contents,
                Description = Description,
                PostDate = DateTime.Now,
                UserId = userProfile.UserId,
                LastEditUserId = userProfile.UserId,
                LastEditDate = DateTime.Now
            });

            db.SaveChanges();

            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            result.Data = new AjaxResult
            {
                Status = AjaxStatus.SUCCESS,
                Title = "Thông báo",
                Message = "Tạo tin mới thành công!",
                Redirect = Url.Action("Index", "News", new { Area = "Admin" }),
            };

            return result;
        }

        
        public ActionResult Update(int Id)
        {
            var news = db.News.Where(t => t.Id == Id).Select(t => new NewsViewModel {
                Id=t.Id,
                Title = t.Title,
                Description = t.Description,
                Contents = t.Contents,
            }).First();
            ViewBag.News = new HtmlString(new JavaScriptSerializer().Serialize(news));
            return View();
        }

        
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(db.News.Select(t=>new NewsViewModel{
                Id=t.Id,
                Title = t.Title,
                PostDate = t.PostDate,
                User = t.User.UserName,
                LastEditUser = t.LastEditUser.UserName,
                LastEditDate = t.LastEditDate
            }).ToDataSourceResult(request));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(int Id, string Title, string Description, string Contents)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var news = db.News.Single(t => t.Id == Id);
                news.Title=Title;
                news.Contents = Contents;
                news.Description = Description;
                news.LastEditDate = DateTime.Now;
                news.LastEditUserId = userProfile.UserId;
                db.SaveChanges();

                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Message = "Cập nhật thành công!",
                    Redirect = Url.Action("Index", "News", new { Area = "Admin" }),
                };
            }
            catch (Exception e)
            {
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Message = e.Message,
                };

            }
            return result;
        }

        public ActionResult Delete(string IDs)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var newIds = Utilities.string2list(IDs);
                foreach (var newId in newIds)
                {
                    db.News.Remove(db.News.Single(t => t.Id == newId));
                }
                db.SaveChanges();
                result.Data = new AjaxResult
                {
                    Status = AjaxStatus.SUCCESS,
                    Title = "Thông báo",
                    Message = "Đã xóa tin!",
                };
            }
            catch (Exception e)
            {
                result.Data = new AjaxResult()
                {
                    Status = AjaxStatus.ERROR,
                    Title = "Thông báo",
                    Message = "Không thể xóa tin",
                };
            }
            return result;
        }
        
    }
}
