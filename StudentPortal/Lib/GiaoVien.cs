using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentPortal.Lib
{
	public class GiaoVien
	{
		public static bool Exist(string Ma_cb)
		{
			DHHHContext db = new DHHHContext();
			return db.PLAN_GiaoVien.Where(t => t.Ma_cb == Ma_cb).Count() == 1;
		}
	}
}
