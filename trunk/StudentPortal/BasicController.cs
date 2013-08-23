using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

using StudentPortal.ViewModels;

namespace StudentPortal
{
	public class BaseController : Controller
	{
		protected int items_per_page;

		public BaseController()
		{
			items_per_page = Properties.Settings.Default.items_per_page;
            
            if (WebSecurity.IsAuthenticated)
            {
            //    DHHHContext db = new DHHHContext();
            //    var profile = db.UserProfiles.Single(t => t.UserId == WebSecurity.CurrentUserId);
            //    ViewBag.User = new User(profile, db);
                ViewBag.UserId = WebSecurity.CurrentUserId;
            }
		}
	}
}