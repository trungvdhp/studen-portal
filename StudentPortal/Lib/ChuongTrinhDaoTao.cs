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

        public static List<STU_Khoa> getKhoa(int ID_he)
        {
            DHHHContext db = new DHHHContext();
            var chuongTrinhDaoTao = db.PLAN_ChuongTrinhDaoTao.ToList();
            if (ID_he != 0)
            {
                chuongTrinhDaoTao = db.PLAN_ChuongTrinhDaoTao.Where(t => t.ID_he == ID_he).ToList();
            }
            return chuongTrinhDaoTao.Select(t => t.STU_Khoa).Distinct().ToList();
        }

        public static List<int> getKhoaHoc(int ID_he, int ID_khoa)
        {
            DHHHContext db = new DHHHContext();
            var chuongTrinhDaoTao = db.PLAN_ChuongTrinhDaoTao.ToList();
            if (ID_he != 0)
                chuongTrinhDaoTao = chuongTrinhDaoTao.Where(t => t.ID_he == ID_he).ToList();
            if (ID_khoa != 0)
                chuongTrinhDaoTao = chuongTrinhDaoTao.Where(t => t.ID_khoa == ID_khoa).ToList();
            return chuongTrinhDaoTao.Select(t => t.Khoa_hoc).Distinct().ToList();
        }

        public static List<PLAN_ChuongTrinhDaoTao> getNganh(int ID_he, int ID_khoa, int Khoa_hoc)
        {
            DHHHContext db = new DHHHContext();
            var chuongTrinhDaoTao = db.PLAN_ChuongTrinhDaoTao.ToList();
            if (ID_he != 0)
                chuongTrinhDaoTao = chuongTrinhDaoTao.Where(t => t.ID_he == ID_he).ToList();
            if (ID_khoa != 0)
                chuongTrinhDaoTao = chuongTrinhDaoTao.Where(t => t.ID_khoa == ID_khoa).ToList();
            if (Khoa_hoc != 0)
                chuongTrinhDaoTao = chuongTrinhDaoTao.Where(t => t.Khoa_hoc == Khoa_hoc).ToList();
            return chuongTrinhDaoTao.ToList();
        }

        public static List<MARK_MonHoc> getMonHoc(int ID_dt)
        {
            DHHHContext db = new DHHHContext();
            var monHoc = db.PLAN_ChuongTrinhDaoTaoChiTiet.Where(t => t.ID_dt == ID_dt).Select(t => t.MARK_MonHoc).ToList();
            return monHoc;
        }

        private static List<int> _khoaDangHoc;
        public static List<int> getKhoaDangHoc()
        {
            if (_khoaDangHoc == null)
            {
                DHHHContext db = new DHHHContext();
                _khoaDangHoc = db.STU_Lop.Where(t => t.Ra_truong == false && t.ID_dt != 0).Select(t => t.Khoa_hoc).ToList();
            }
            return _khoaDangHoc;
        }
	}
}