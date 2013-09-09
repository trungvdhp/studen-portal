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
        static Dictionary<string, float> DiemHe4 = new Dictionary<string, float>() { 
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
		public static List<DiemHocTap> GetDiemHocTap(int ID_sv)
		{
			DHHHContext db = new DHHHContext();

			var diem = db.MARK_DiemThanhPhan_TC.Where(t => t.MARK_Diem_TC.ID_sv == ID_sv && t.MARK_ThanhPhanMon_TC.Ky_hieu == "X").Select(t => new DiemHocTap
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
					heso.Add(t.ID_mon, t.He_so!=null?(float)t.He_so:0);
			//
			Dictionary<string, float> tongdiem=new Dictionary<string,float>();
			Dictionary<string, float> tongheso = new Dictionary<string, float>();
			Dictionary<int, float> listdiem = new Dictionary<int, float>();
			Dictionary<int, float> listheso = new Dictionary<int, float>();
			foreach (var d in diem)
			{
				string key = d.Nam_hoc+"-"+d.Hoc_ky;
				
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
				diem.Add(new DiemHocTap { 
					Nam_hoc = match.Groups["namhoc"].ToString(),
					Hoc_ky = Convert.ToInt32(match.Groups["hocky"].ToString()),
					Z=tongdiem[key]/tongheso[key],
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
			diem.Add(new DiemHocTap { 
				Nam_hoc= "Cả năm",
				Z = tongdiemtichluy/tonghesotichluy,
				Ten_mon = "Điểm tích lũy",
				Hoc_ky = 0
			});
			return diem;
		}
		public static List<BienLaiThu> GetBienLai(int ID_sv)
		{
			DHHHContext db = new DHHHContext();
			var bienlai = db.ACC_BienLaiThuChiTiet.Where(t=>t.ACC_BienLaiThu.ID_sv==ID_sv).Select(t=> new BienLaiThu{
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
			}).ToList();				
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
        public static STU_DanhSach GetSinhVien(UserProfile profile)
        {
            DHHHContext db = new DHHHContext();
            var sinhVien = db.STU_DanhSach.Single(t => t.STU_HoSoSinhVien.Ma_sv == profile.UserName);
            return sinhVien;
        }

        public static List<DiemHocTap> GetBangDiem(int ID_sv)
        {
            var diems = GetDiemHocTap(ID_sv);
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
    }
}