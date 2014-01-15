using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentPortal.ViewModels;

namespace StudentPortal.Lib
{
    public class ChuongTrinhDaoTao
    {
        private static List<int> _khoaDangHoc;
        public static List<int> getMonHoc(int ID_he, int ID_khoa, int Ky_thu)
        {
            DHHHContext db = new DHHHContext();
            var mon = db.PLAN_ChuongTrinhDaoTaoChiTiet.ToList();
            if (ID_he > 0) mon = mon.Where(t => t.PLAN_ChuongTrinhDaoTao.ID_he == ID_he).ToList();
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

        public static List<int> getKhoaDangHoc()
        {
            if (_khoaDangHoc == null)
            {
                DHHHContext db = new DHHHContext();
                _khoaDangHoc = db.STU_Lop.Where(t => t.Ra_truong == false && t.ID_dt != 0).Select(t => t.Khoa_hoc).ToList();
            }
            return _khoaDangHoc;
        }

        public static List<MonChuongTrinhKhungViewModel> getChuongTrinhKhung(int ID_dt)
        {
            var db = new DHHHContext();
            var result = db.PLAN_ChuongTrinhDaoTaoChiTiet.Where(t => t.ID_dt == ID_dt).Select(t => new MonChuongTrinhKhungViewModel
            {
                ID_mon = t.ID_mon,
                Ten_mon = t.MARK_MonHoc.Ten_mon,
                So_TC = t.So_hoc_trinh,
                Ly_thuyet = t.Ly_thuyet,
                Thuc_hanh = t.Thuc_hanh,
                He_so = t.He_so,
                Ky_hieu = t.MARK_MonHoc.Ky_hieu,
                Rang_buoc = t.Tu_chon == true ? "Tự chọn" : ""
            }).ToList();

            var dicMonRangBuocs = new Dictionary<int, List<PLAN_ChuongTrinhDaoTaoRangBuoc>>();
            //if (db.PLAN_ChuongTrinhDaoTaoRangBuoc.Count(t => t.ID_dt == ID_dt) > 0)
            //{
                var monRangBuocs = db.PLAN_ChuongTrinhDaoTaoRangBuoc.Where(t => t.ID_dt == ID_dt).ToList();
                foreach (var monRangBuoc in monRangBuocs)
                {
                    if (!dicMonRangBuocs.ContainsKey(monRangBuoc.ID_mon))
                    {
                        dicMonRangBuocs.Add(monRangBuoc.ID_mon, new List<PLAN_ChuongTrinhDaoTaoRangBuoc>());
                    }
                    if (dicMonRangBuocs[monRangBuoc.ID_mon].Count(t => t.ID_mon_rb == monRangBuoc.ID_mon_rb) == 0)
                        dicMonRangBuocs[monRangBuoc.ID_mon].Add(monRangBuoc);
                }
            //}
            for (int i = 0; i < result.Count; i++)
            {
                var ID_mon = result[i].ID_mon;
                if (dicMonRangBuocs.ContainsKey(ID_mon))
                {
                    bool first = true;
                    foreach (var monRangBuoc in dicMonRangBuocs[ID_mon])
                    {
                        if (!first) result[i].Rang_buoc += "\n";
                        first = false;
                        result[i].Rang_buoc += String.Format("{0}: {1}", monRangBuoc.PLAN_LoaiRangBuoc.Ten_rang_buoc, monRangBuoc.Mon_Rang_Buoc.Ten_mon);
                    }
                }
            }
            return result;
        }
    }
}