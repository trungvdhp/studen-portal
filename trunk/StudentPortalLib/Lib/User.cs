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
                {
                    var sv = db.STU_HoSoSinhVien.Single(t => t.Ma_sv == UserName);
                    _dicFullname[UserName] = String.Format("{0} ({1})", sv.Ho_ten, sv.Ma_sv);
                }
                else if (db.PLAN_GiaoVien.Count(t => t.Ma_cb == UserName) > 0)
                {
                    var gv = db.PLAN_GiaoVien.Single(t => t.Ma_cb == UserName);
                    _dicFullname[UserName] = String.Format("{0} ({1})", gv.Ho_ten,gv.Ma_cb);
                }
                else _dicFullname[UserName] = UserName;
            }
            return _dicFullname[UserName];
        }
	}
}