using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentPortal.Lib
{
    public class Utilities
    {
        /// <summary>
        /// Chuyển mảng dạng chuỗi từ request thành list int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<int> string2list(string str)
        {
            var buf = str.Split(',');
            var intList = new List<int>();
            foreach (var s in buf)
            {
                try
                {
                    intList.Add(Convert.ToInt32(s));
                }
                catch (Exception) { }
            }
            return intList;
        }
    }
}