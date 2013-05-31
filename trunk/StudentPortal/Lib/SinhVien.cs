using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentPortal.ViewModels;

namespace StudentPortal.Lib
{
	public class SinhVien
	{
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
				Ma_mon = t.MARK_Diem_TC.MARK_MonHoc.Ky_hieu,
				Ten_mon = t.MARK_Diem_TC.MARK_MonHoc.Ten_mon,
				X = t.Diem,
				Hoc_ky = t.Hoc_ky_TP,
				Nam_hoc = t.Nam_hoc_TP
			}).ToList();
			foreach (var d in diem)
			{
				var q = db.MARK_DiemThi_TC.Where(t => t.ID_diem == d.Id_diem && t.Nam_hoc_thi == d.Nam_hoc && t.Hoc_ky_thi == d.Hoc_ky);
				if (q.Count() > 0)
				{
					var dt = q.First();
					d.Y = dt.Diem_thi;
					d.Z = dt.TBCMH;
					d.Diem_chu = dt.Diem_chu;
				}
			}
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
	}
}