using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using StudentPortal.Models;
using WebMatrix.WebData;

namespace StudentPortal.Areas.Admin.Controllers
{
    [Authorize(Roles="User")]
    public class UserController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/User/

        //[Authorize(Roles="User.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/User//Read

        //[Authorize(Roles="User.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var userprofiles = db.UserProfiles.Include(u => u.webpages_Group);
            return Json(userprofiles.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/User/Details/5

        //[Authorize(Roles="User.Details")]
        public ActionResult Details(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /Admin/User/Create

        //[Authorize(Roles="User.Create")]
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.webpages_Group, "GroupId", "GroupName");
            return View();
        }

        //
        // POST: /Admin/User/Create

        [HttpPost]
        //[Authorize(Roles="User.Create")]
        public ActionResult Create(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userprofile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.webpages_Group, "GroupId", "GroupName", userprofile.GroupId);
            return View(userprofile);
        }

        //
        // GET: /Admin/User/Edit/5
        //[Authorize(Roles="User.Edit")]
        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.webpages_Group, "GroupId", "GroupName", userprofile.GroupId);
            return View(userprofile);
        }

        //
        // POST: /Admin/User/Edit/5

        [HttpPost]
        //[Authorize(Roles="User.Edit")]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.webpages_Group, "GroupId", "GroupName", userprofile.GroupId);
            return View(userprofile);
        }

        //
        // GET: /Admin/User/Delete/5

        //[Authorize(Roles="User.Delete")]
        public ActionResult Delete(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /Admin/User/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="User.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(userprofile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Reset(int UserId)
        {
            var profile = Lib.User.getUserProfile(UserId);
            var token = WebSecurity.GeneratePasswordResetToken(profile.UserName);
            var sv = Lib.SinhVien.GetSinhVien(profile);
            WebSecurity.ResetPassword(token, sv[0].STU_HoSoSinhVien.Ma_sv);
            db.UserProfiles.Single(t => t.UserId == UserId).ResetCount++;
            db.SaveChanges();
            return Json(new AjaxResult
            {
                Status = AjaxStatus.SUCCESS,
                Message = "Đã reset mật khẩu!"
            });
        }
    }
}