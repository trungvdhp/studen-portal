using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentPortal.Lib
{
	public class ChuongTrinhDaoTao
	{
		public static List<int> getMonHoc(int ID_he, int ID_khoa, int Ky_thu)
		{
			DHHHContext db= new DHHHContext();
			var mon = db.PLAN_ChuongTrinhDaoTaoChiTiet.ToList();
			if (ID_he >0) mon = mon.Where(t => t.PLAN_ChuongTrinhDaoTao.ID_he == ID_he).ToList();
			if (ID_khoa > 0) mon = mon.Where(t => t.PLAN_ChuongTrinhDaoTao.ID_khoa == ID_khoa).ToList();
			if (Ky_thu > 0) mon = mon.Where(t => t.Ky_thu == Ky_thu).ToList();

			var temp = mon.Select(t => t.ID_mon).ToList();
			var result = new List<int>();
			foreach (int i in temp) if (!result.Contains(i)) result.Add(i);
			return result;
		}
	}
}