using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using StudentPortal.Lib;

namespace StudentPortal.Controllers
{
    public class MessageController : BaseController
    {

        public ActionResult Index()
        {
            return Redirect(Url.Action("Inbox","Message"));
        }

        public ActionResult Inbox()
        {
            return View();
        }
        public ActionResult Outbox()
        {
            return View();
        }
        
        public ActionResult Compose()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Send(string sendto, string title, string content)
        {

            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            string[] users = sendto.Split(new char[] { ',' });

            try
            {
                foreach (var user in users)
                {
                    if (db.UserProfiles.Count(t => t.UserName == user) > 0)
                    {
                        var ToUser = db.UserProfiles.Single(t => t.UserName == user);
                        db.Inbox.Add(new InboxModel()
                        {
                            Title = title,
                            Contents = content,
                            To = ToUser.UserId,
                            From = userProfile.UserId,
                            Postdate = DateTime.Now,
                            Type = InboxModel.INBOX,
                        });
                        db.Inbox.Add(new InboxModel()
                        {
                            Title = title,
                            Contents = content,
                            To = ToUser.UserId,
                            From = userProfile.UserId,
                            Postdate = DateTime.Now,
                            Type = InboxModel.OUTBOX,
                        });
                    }else if(db.STU_Lop.Count(t=>t.Ten_lop==user)>0){
                        var ID_lop = db.STU_Lop.Single(t=>t.Ten_lop==user).ID_lop;
                        var Usernames = db.STU_DanhSach.Where(t => t.ID_lop == ID_lop).Select(t => t.STU_HoSoSinhVien.Ma_sv).ToList();
                        foreach (var username in Usernames)
                        {
                            if (db.UserProfiles.Count(t => t.UserName == username) > 0)
                            {
                                var ToUser = db.UserProfiles.Single(t => t.UserName == username);
                                db.Inbox.Add( new InboxModel()
                                {
                                    Title = title,
                                    Contents = content,
                                    To = ToUser.UserId,
                                    From = userProfile.UserId,
                                    Postdate = DateTime.Now,
                                    Type = InboxModel.INBOX,
                                });
                                db.Inbox.Add(new InboxModel()
                                {
                                    Title = title,
                                    Contents = content,
                                    To = ToUser.UserId,
                                    From = userProfile.UserId,
                                    Postdate = DateTime.Now,
                                    Type = InboxModel.OUTBOX,
                                });
                            }
                        }
                    }
                }
                db.SaveChanges();
                result.Data = new AjaxResult()
                {
                    Title = "Thông báo",
                    Message = "Đã gửi tin nhắn thành công!",
                    Status = AjaxStatus.SUCCESS,
                    Redirect = Url.Action("Index","Message",new {Area=""})
                };
            }
            catch (Exception e)
            {
                result.Data = new AjaxResult()
                {
                    Title = "Thông báo",
                    Message = e.Message,
                    Status = AjaxStatus.ERROR
                };
            }

            return result;
        }

        public ActionResult Delete(string IDs)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                var inboxIDs = Utilities.string2list(IDs);
                foreach (var id in inboxIDs)
                {
                    if (db.Inbox.Count(t => t.ID == id) > 0)
                    {
                        var inbox = db.Inbox.Single(t => t.ID == id);
                        if ((inbox.From == userProfile.UserId && inbox.Type == InboxModel.OUTBOX) || (inbox.To == userProfile.UserId && inbox.Type == InboxModel.INBOX))
                            db.Inbox.Remove(inbox);

                    }
                }
                db.SaveChanges();
                result.Data = new AjaxResult()
                {
                    Title = "Thông báo",
                    Message = "Xóa tin nhắn thành công!",
                    Status = AjaxStatus.SUCCESS
                };
            }
            catch (Exception ex)
            {
                result.Data = new AjaxResult()
                {
                    Title = "Thông báo",
                    Message = ex.Message,
                    Status = AjaxStatus.ERROR
                };
            }




            return result;
        }

        public ActionResult getInbox([DataSourceRequest] DataSourceRequest request)
        {
            //int i = 1;
            var messages = db.Inbox.Where(t => t.To == userProfile.UserId && t.Type == InboxModel.INBOX).ToList().Select(t => new MessageViewModel
            {
                ID = t.ID,
                Title = t.Title,
                From = StudentPortal.Lib.User.getUserFullName(t.FromUser.UserName),
                Postdate = t.Postdate,
                Status = t.Status,
                Warning = t.Warning,
            }).ToList();
            return Json(messages.ToDataSourceResult(request));
        }

        public ActionResult Detail(int ID)
        {
            if (db.Inbox.Count(t => t.ID == ID) > 0)
            {
                var message = db.Inbox.Single(t => t.ID == ID);
                ViewBag.Message = new InboxViewModel() { 
                    Id= message.ID,
                    From = StudentPortal.Lib.User.getUserFullName(message.FromUser.UserName),
                    Title = message.Title,
                    Contents = message.Contents,
                    Postdate = message.Postdate,
                };
                message.Status = true;
                db.SaveChanges();
            }
            return View();
        }


        public ActionResult getOutbox([DataSourceRequest] DataSourceRequest request)
        {
            var messages = db.Inbox.Where(t => t.From == userProfile.UserId && t.Type==InboxModel.OUTBOX).Select(t => new MessageViewModel
            {
                ID = t.ID,
                Title = t.Title,
                To = t.ToUser.UserName,
                Postdate = t.Postdate,
            }).ToList();
            return Json(messages.ToDataSourceResult(request));
        }
    }
}
