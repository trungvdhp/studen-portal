using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentPortal.ViewModels;
using StudentPortal.Models;
using System.Text.RegularExpressions;

namespace StudentPortal.Lib
{
	public class SinhVien
    {
        #region Const diem
        public static Dictionary<string, float> DiemHe4 = new Dictionary<string, float>() { 
			{"A",4},
			{"A+",4},
			{"B",3},
			{"B+",3.3f},
			{"C",2},
			{"C+",2.3f},
			{"D",1},
			{"D+",1.3f},
			{"F",0},
			{"",0},
		};
        #endregion
        public static int GetIdSv(String TuKhoa)
		{
			DHHHContext db = new DHHHContext();
			TuKhoa = TuKhoa.Replace("  ", " ").Trim();
			string[] buf = TuKhoa.Split(new char[] { ' ' });
			string Ma_sv = buf[0];
			var sv = db.STU_HoSoSinhVien.Where(t => t.Ma_sv == Ma_sv);
			if (sv.Count() == 0) sv = db.STU_HoSoSinhVien.Where(t => t.Ho_ten == TuKhoa);
			if (sv.Count() > 0) return (int)sv.First().ID_sv;
			return 0;

		}

        private static Dictionary<string, List<DiemHocTap>> _diemHocTap = new Dictionary<string, List<DiemHocTap>>();
        public static List<DiemHocTap> GetDiemHocTap(int ID_sv,int ID_dt)
        {
            if (!_diemHocTap.ContainsKey(ID_sv + "_" + ID_dt))
            {

                DHHHContext db = new DHHHContext();

                var diem = db.MARK_DiemThanhPhan_TC.Where(t => t.MARK_Diem_TC.ID_dt == ID_dt && t.MARK_Diem_TC.ID_sv == ID_sv && t.MARK_ThanhPhanMon_TC.Ky_hieu == "X").Select(t => new DiemHocTap
                {
                    Id_diem = t.MARK_Diem_TC.ID_diem,
                    ID_mon = t.MARK_Diem_TC.ID_mon,
                    Ma_mon = t.MARK_Diem_TC.MARK_MonHoc.Ky_hieu,
                    Ten_mon = t.MARK_Diem_TC.MARK_MonHoc.Ten_mon,
                    X = t.Diem,
                    Hoc_ky = t.Hoc_ky_TP,
                    Nam_hoc = t.Nam_hoc_TP
                }).ToList();

                //
                Dictionary<int, float> heso = new Dictionary<int, float>();
                var temp = db.PLAN_ChuongTrinhDaoTaoChiTiet.Select(t => new { He_so = t.He_so, ID_mon = t.ID_mon }).ToList();
                foreach (var t in temp)
                    if (!heso.ContainsKey(t.ID_mon))
                        heso.Add(t.ID_mon, t.He_so != null ? (float)t.He_so : 0);
                //
                Dictionary<string, float> tongdiem = new Dictionary<string, float>();
                Dictionary<string, float> tongheso = new Dictionary<string, float>();
                Dictionary<int, float> listdiem = new Dictionary<int, float>();
                Dictionary<int, float> listheso = new Dictionary<int, float>();
                foreach (var d in diem)
                {
                    string key = d.Nam_hoc + "-" + d.Hoc_ky;
                    if (d.Diem_chu == null) d.Diem_chu = "";

                    var q = db.MARK_DiemThi_TC.Where(t => t.ID_diem == d.Id_diem && t.Nam_hoc_thi == d.Nam_hoc && t.Hoc_ky_thi == d.Hoc_ky);
                    if (q.Count() > 0)
                    {
                        var dt = q.First();
                        d.Y = dt.Diem_thi;
                        d.Z = dt.TBCMH;
                        d.Diem_chu = dt.Diem_chu;
                    }

                    if (heso.ContainsKey(d.ID_mon))
                    {
                        d.He_so = heso[d.ID_mon];
                        if (!tongdiem.ContainsKey(key))
                        {
                            tongdiem.Add(key, DiemHe4[d.Diem_chu] * d.He_so);
                            tongheso.Add(key, d.He_so);
                        }
                        else
                        {
                            tongdiem[key] += DiemHe4[d.Diem_chu] * d.He_so;
                            tongheso[key] += d.He_so;
                        }

                        if (!listdiem.ContainsKey(d.ID_mon))
                        {
                            if (DiemHe4[d.Diem_chu] != 0)
                            {
                                listdiem.Add(d.ID_mon, DiemHe4[d.Diem_chu]);
                                listheso.Add(d.ID_mon, d.He_so);
                            }
                        }
                        else if (DiemHe4[d.Diem_chu] > listdiem[d.ID_mon]) listdiem[d.ID_mon] = DiemHe4[d.Diem_chu];
                    }
                }

                Regex regex = new Regex(@"(?<namhoc>.+)-(?<hocky>\d)");
                foreach (string key in tongdiem.Keys)
                {
                    Match match = regex.Match(key);
                    diem.Add(new DiemHocTap
                    {
                        Nam_hoc = match.Groups["namhoc"].ToString(),
                        Hoc_ky = Convert.ToInt32(match.Groups["hocky"].ToString()),
                        Z = tongdiem[key] / tongheso[key],
                        Ten_mon = "TBMHK"
                    });
                }
                float tongdiemtichluy = 0;
                float tonghesotichluy = 0;
                foreach (var id in listdiem.Keys)
                {
                    tongdiemtichluy += listdiem[id] * listheso[id];
                    tonghesotichluy += listheso[id];
                }
                diem.Add(new DiemHocTap
                {
                    Nam_hoc = "Cả năm",
                    Z = tongdiemtichluy / tonghesotichluy,
                    Ten_mon = "Điểm tích lũy",
                    Hoc_ky = 0
                });
                _diemHocTap[ID_sv + "_" + ID_dt] = diem;
            }
            return _diemHocTap[ID_sv + "_" + ID_dt];
        }
		public static List<BienLaiThu> GetBienLai(int ID_sv,int ID_dt)
		{
			DHHHContext db = new DHHHContext();
			var dicBienLai = db.ACC_BienLaiThuChiTiet.Where(t=>t.ACC_BienLaiThu.ID_sv==ID_sv).Select(t=> new BienLaiThu{
				Id_bien_lai = t.ID_bien_lai,
				Nam_hoc = t.ACC_BienLaiThu.Nam_hoc,
				Hoc_ky = t.ACC_BienLaiThu.Hoc_ky,
				Dot_thu = t.ACC_BienLaiThu.Dot_thu,
				Lan_thu = t.ACC_BienLaiThu.Lan_thu,
				Ten_lan = t.ACC_BienLaiThu.Noi_dung,
				Ngay_thu = t.ACC_BienLaiThu.Ngay_thu,
				Noi_dung = t.ID_mon_tc == 0 ? t.ACC_LoaiThuChi.Ten_thu_chi : t.PLAN_MonTinChi_TC.MARK_MonHoc.Ten_mon,
				Nguoi_thu = t.ACC_BienLaiThu.Nguoi_thu,
				So_tien = t.So_tien,
				So_phieu = t.ACC_BienLaiThu.So_phieu,
				Ten_thu_chi = t.ACC_LoaiThuChi.Ten_thu_chi,
				Ghi_chu = t.Ghi_chu,
                ID_mon_tc = t.ID_mon_tc
			}).ToDictionary(t=>t.ID_mon_tc,t=>t);

            var monDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv).Select(t => new
            {
                ID_mon_tc = t.PLAN_LopTinChi_TC.ID_mon_tc,
                He_so = t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.He_so,
                Ten_mon = t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.MARK_MonHoc.Ten_mon,
                Nam_hoc = t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.PLAN_HocKyDangKy_TC.Nam_hoc,
                Hoc_ky = t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.PLAN_HocKyDangKy_TC.Hoc_ky,
            }).ToList();

            foreach (var monDK in monDKs)
            {
                if (!dicBienLai.ContainsKey(monDK.ID_mon_tc))
                {
                    var lop = db.STU_DanhSach.Single(t => t.ID_sv == ID_sv && t.STU_Lop.ID_dt == ID_dt).STU_Lop;
                    var muchocphis = db.ACC_MucHocPhiTinChi.Where(t => t.Hoc_ky == monDK.Hoc_ky && t.Nam_hoc == monDK.Nam_hoc).ToList();
                    muchocphis = muchocphis.Where(t => t.ID_he == lop.ID_he || t.ID_he == 0).ToList();
                    muchocphis = muchocphis.Where(t => t.ID_chuyen_nganh == lop.ID_chuyen_nganh || t.ID_chuyen_nganh == 0).ToList();
                    muchocphis = muchocphis.Where(t => t.Khoa_hoc == lop.Khoa_hoc || t.Khoa_hoc == 0).ToList();
                    var muchocphi = muchocphis.First();

                    dicBienLai.Add(monDK.ID_mon_tc, new BienLaiThu { 
                        Chua_dong = true,
                        Nam_hoc = monDK.Nam_hoc,
                        Hoc_ky = monDK.Hoc_ky,
                        So_tien = (int)muchocphi.So_tien*monDK.He_so,
                        Noi_dung  = monDK.Ten_mon + " (chưa đóng)",
                    });
                }
            }

            var bienlai = dicBienLai.Values.ToList();
			bienlai.AddRange(db.ACC_BienLaiThu.Where(t=>t.ID_sv==ID_sv).Select(t=>new BienLaiThu{
				Nam_hoc = t.Nam_hoc,
				Hoc_ky = t.Hoc_ky,
				Dot_thu = t.Dot_thu,
				Lan_thu = t.Lan_thu,
				Noi_dung = "Tổng tiền",
				So_tien = t.So_tien,
				Ten_lan = t.Noi_dung,
				Ngay_thu = t.Ngay_thu,
			}).ToList());
			return bienlai;
		}
		public static bool Exits(string Ma_sv)
		{
			DHHHContext db = new DHHHContext();
			return db.STU_HoSoSinhVien.Where(t => t.Ma_sv == Ma_sv).Count() == 1;
		}
        public static List<STU_DanhSach> GetSinhVien(UserProfile profile)
        {
            DHHHContext db = new DHHHContext();
            var sinhVien = db.STU_DanhSach.Where(t => t.STU_HoSoSinhVien.Ma_sv == profile.UserName).ToList();
            return sinhVien;
        }
        public static List<DiemHocTap> GetBangDiem(int ID_sv, int ID_dt)
        {
            var diems = GetDiemHocTap(ID_sv,ID_dt);
            //var bangdiem = new List<DiemHocTap>();
            Dictionary<int, DiemHocTap> bangdiem = new Dictionary<int, DiemHocTap>();
            foreach (var diem in diems)
            {
                if (!bangdiem.ContainsKey(diem.ID_mon))
                    bangdiem[diem.ID_mon] = diem;
                else if (diem.Z > bangdiem[diem.ID_mon].Z)
                    bangdiem[diem.ID_mon] = diem;
            }
            return bangdiem.Values.ToList();
        }
        public static void GetHocKyHienTai(STU_DanhSach sinhVien)
        {

        }
        public static List<ChuyenNganh> getChuyenNganh(int ID_sv)
        {
            DHHHContext  db = new DHHHContext();
            return db.STU_DanhSach.Where(t => t.ID_sv == ID_sv).Select(t => new ChuyenNganh
            {
                ID_dt = t.STU_Lop.ID_dt,
                Chuyen_nganh = t.STU_Lop.STU_ChuyenNganh.Chuyen_nganh
            }).Distinct().ToList();
        }
        private static Dictionary<int, STU_Lop> _lop;
        public static Dictionary<int, STU_Lop> Lop
        {
            get
            {
                if (_lop == null)
                {
                    DHHHContext db = new DHHHContext();
                    _lop = db.STU_DanhSach.ToDictionary(t => t.ID_sv, t => t.STU_Lop);
                }
                return _lop;
            }
        }
        public static HocKy GetHocKyTruoc(int ID_sv, int ID_dt)
        {
            var hocky = SinhVien.GetDiemHocTap(ID_sv, ID_dt).Select(t => new HocKy
            {
                Hoc_ky = t.Hoc_ky,
                Nam_hoc = t.Nam_hoc,
            }).Distinct().OrderByDescending(t => t.Nam_hoc).ThenByDescending(t => t.Hoc_ky).ToList();
            return hocky.First();
        }
        //public static HocKy GetHocKyTruoc(STU_DanhSach sinhVien)
        //{
        //    var diemhoctap = GetDiemHocTap(sinhVien.ID_sv);
        //    var hocky = diemhoctap.Select(t => new HocKy
        //    {
        //        Hoc_ky = t.Hoc_ky,
        //        Nam_hoc = t.Nam_hoc,
        //    }).Distinct().OrderByDescending(t=>t.Nam_hoc).ThenByDescending(t=>t.Hoc_ky).ToList();
        //    return hocky.First();
        //}
    }
}