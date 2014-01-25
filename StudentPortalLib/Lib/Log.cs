using StudentPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalLib.Lib
{
    public enum LogAct
    {
        NA = 0,
        DANGKY = 1,
        RUTHP = 2,
        HUYHP = 3,
    }

    public class Log
    {
        public static Dictionary<LogAct, string> LogDic = new Dictionary<LogAct, string>()
        {
            {LogAct.DANGKY,"Đăng ký lớp học phần"},
            {LogAct.RUTHP,"Rút học phần"},
            {LogAct.HUYHP, "Hủy học phần"},
        };

        public static void Write(int user_id, string user_ip, LogAct action, string param = "")
        {
            var db = new DHHHContext();
            db.Log.Add(new StudentPortal.Models.Log
            {
                Thao_tac = (int)action,
                User_id = user_id,
                User_ip = user_ip,
                Thoi_gian = DateTime.Now,
                Tham_so = param,
            });
            db.SaveChanges();
        }

        public static List<StudentPortal.Models.Log> Read(DHHHContext db, int user_id = 0, LogAct action = LogAct.NA, string user_ip = null)
        {
            var query = db.Log.Where(t=>true);
            if (user_id != 0)
                query = query.Where(t => t.User_id == user_id);
            if (action != LogAct.NA)
            {
                var thao_tac = (int)action;
                query = query.Where(t => t.Thao_tac == thao_tac);
            }

            if (user_ip != null)
            {
                query = query.Where(t => t.User_ip == user_ip);
            }
            //if (from.Ticks != 0)
            //{
                //query.Where(t => t.Thoi_gian >= from && t.Thoi_gian <= to);
            //}
            return query.ToList();
        }
    }
}
