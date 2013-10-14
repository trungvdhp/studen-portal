using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentPortal.Lib
{
    public class ThoiGian
    {
        private static string[] Thu = new string[]{ "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy", "Chủ Nhật" };
        public static string getThu(int thu)
        {
            if (thu >=0 && thu <=6) return Thu[thu];
            return String.Empty;
        }
    }
}