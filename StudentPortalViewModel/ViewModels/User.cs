using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentPortal.Models;

namespace StudentPortal.ViewModels
{
    public class User
    {
        public User(UserProfile profile)
        {
            this._profile = profile;
            db = new DHHHContext();
        }
        private DHHHContext db;

        private UserProfile _profile;
        private string _name;

        public int UserId
        {
            get
            {
                return this._profile.UserId;
            }
        }
        public string Name
        {
            get
            {
                if (this._name == null)
                {
                    var hssv = db.STU_HoSoSinhVien.Single(t => t.Ma_sv == _profile.UserName);
                    if (hssv != null)
                    {
                        this._name = hssv.Ho_ten;
                    }
                    else
                    {
                        this._name = _profile.UserName;
                    }
                }
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        
        public static string getName(int UserId)
        {
            DHHHContext db = new DHHHContext();
            var profile = db.UserProfiles.Single(t => t.UserId == UserId);
            if (profile != null)
            {
                var user = new User(profile);
                return user.Name;
            }
            return string.Empty;
        }
    }
}