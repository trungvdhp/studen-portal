using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentPortal.Lib
{
    public class CauHinh
    {
        private static Dictionary<string, StudentPortal.CauHinhModel> _dic;
        private static Dictionary<string, StudentPortal.CauHinhModel> Dic
        {
            get
            {
                if (_dic == null)
                {
                    var db = new DHHHContext();
                    _dic = db.CauHinh.ToDictionary(t => t.Ten + "_" + t.Ky_dang_ky, t => t);
                }
                return _dic;
            }
        }
        public static object get(string name, int Ky_dang_ky = 0)
        {
            string key=name + "_" + Ky_dang_ky;
            CauHinhModel element = null;
            if (Dic.ContainsKey(key))
            {
                element= Dic[key];
            }
            else if (Dic.Values.Count(t => t.Ten == name) > 0)
            {
                element = Dic.Values.Where(t => t.Ten == name).OrderByDescending(t => Ky_dang_ky).First();
            }
            if (element == null) return null;
            switch (element.Kieu)
            {
                case "int":
                    return Convert.ToInt32(element.Gia_tri);
                case "double":
                    return Convert.ToDouble(element.Gia_tri);
                default:
                    return element.Gia_tri;
            }
        }

    }
}