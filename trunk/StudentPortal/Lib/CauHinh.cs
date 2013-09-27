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
                    _dic = db.CauHinh.ToDictionary(t => t.Ten, t => t);
                }
                return _dic;
            }
        }
        public static object get(string name)
        {
            if (Dic.ContainsKey(name))
            {
                switch (Dic[name].Kieu)
                {
                    case "int":
                        return Convert.ToInt32(Dic[name].Gia_tri);
                    case "double":
                        return Convert.ToDouble(Dic[name].Gia_tri);
                    default:
                        return Dic[name].Gia_tri;
                }
            }
            return null;
        }

    }
}