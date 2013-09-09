using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentPortal.Models;

namespace StudentPortal.Lib
{
	public class User
	{
		public static bool Login(string UserName,string Password)
		{
			return true;
		}
        public static UserProfile getUserProfile(int UserId)
        {
            DHHHContext db = new DHHHContext();
            return db.UserProfiles.Single(t => t.UserId == UserId);
        }
	}
}