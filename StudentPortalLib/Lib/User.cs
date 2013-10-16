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
        private static Dictionary<string, string> _dicFullname = new Dictionary<string, string>();
        public static string getUserFullName(string UserName){
            if (!_dicFullname.ContainsKey(UserName))
            {
                DHHHContext db = new DHHHContext();
                if (db.STU_HoSoSinhVien.Count(t => t.Ma_sv == UserName) > 0)
                    _dicFullname[UserName]= db.STU_HoSoSinhVien.Single(t => t.Ma_sv == UserName).Ho_ten;
                else if (db.PLAN_GiaoVien.Count(t => t.Ma_cb == UserName) > 0)
                    _dicFullname[UserName] = db.PLAN_GiaoVien.Single(t => t.Ma_cb == UserName).Ho_ten;
                else _dicFullname[UserName] = UserName;
            }
            return _dicFullname[UserName];
        }
	}
}