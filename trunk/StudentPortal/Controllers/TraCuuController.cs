using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using StudentPortal.ViewModels;
using StudentPortal.Lib;

namespace StudentPortal.Controllers
{
	public class TraCuuController : BasicController
	{
		//
		// GET: /TraCuu/
		DHHHContext db = new DHHHContext();


		#region TuKhoa
		public ActionResult TuKhoa(string TuKhoa)
		{
			DHHHContext db = new DHHHContext();
			TuKhoa = TuKhoa.Trim();
			var list = new List<AutoCompleteData>();
			try
			{
				int.Parse(TuKhoa);
				list = db.STU_HoSoSinhVien.Where(t => t.Ma_sv.StartsWith(TuKhoa)).Take(10).Select(t => new AutoCompleteData
				{
					Text = t.Ma_sv + " " + t.Ho_ten
				}).ToList();
			}
			catch
			{
				list = db.STU_HoSoSinhVien.Where(t => t.Ho_ten.Contains(TuKhoa)).Take(10).Select(t => new AutoCompleteData
				{
					Text = t.Ma_sv + " " + t.Ho_ten
				}).ToList();
			}
			JsonResult json = Json(list);
			json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return json;
		}
		#endregion

		#region Diem

		public ActionResult Diem()
		{
			return View();
		}

		public ActionResult NamHoc(string TuKhoa)
		{
			int ID_sv = SinhVien.GetIdSv(TuKhoa);
			DHHHContext db = new DHHHContext();

			var namhoc = db.MARK_Diem_TC.Where(t => t.ID_sv == ID_sv).Select(t => new
			{
				Nam_hoc = t.Nam_hoc
			}).Distinct().OrderBy(t => t.Nam_hoc).ToList();

			JsonResult result = new JsonResult();
			result.Data = new SelectList(namhoc, "Nam_hoc", "Nam_hoc");
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return result;
		}

		public ActionResult HocKy(string TuKhoa, string NamHoc)
		{
			int ID_sv = SinhVien.GetIdSv(TuKhoa);
			DHHHContext db = new DHHHContext();

			var hocky = db.MARK_Diem_TC.Where(t => t.ID_sv == ID_sv && t.Nam_hoc == NamHoc).Select(t => new
			{
				Hoc_ky = t.Hoc_ky
			}).Distinct().OrderBy(t => t.Hoc_ky).ToList();

			JsonResult result = new JsonResult();
			result.Data = new SelectList(hocky, "Hoc_ky", "Hoc_ky");
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return result;
		}

		public ActionResult DiemHocTap([DataSourceRequest] DataSourceRequest request, string TuKhoa, string NamHoc, string HocKy)
		{
			int ID_sv = SinhVien.GetIdSv(TuKhoa);
			DHHHContext db = new DHHHContext();
			int hk = HocKy == "" ? 0 : Convert.ToInt32(HocKy);

			var diem = SinhVien.GetDiemHocTap(ID_sv);
			if (NamHoc != "") diem = diem.Where(t => t.Nam_hoc == NamHoc).ToList();
			if (hk != 0) diem = diem.Where(t => t.Hoc_ky == hk).ToList();
			return Json(diem.ToDataSourceResult(request));
		}

		#endregion

		#region Thu chi

		public ActionResult ThuChi()
		{
			return View();
		}

		public ActionResult NamThu(string TuKhoa)
		{
			int ID_sv = SinhVien.GetIdSv(TuKhoa);
			DHHHContext db = new DHHHContext();
			var namhoc = db.ACC_BienLaiThu.Where(t => t.ID_sv == ID_sv).Select(t => new
			{
				Nam_hoc = t.Nam_hoc
			}).Distinct().OrderBy(t => t.Nam_hoc).ToList();

			JsonResult result = new JsonResult();
			result.Data = new SelectList(namhoc, "Nam_hoc", "Nam_hoc");
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return result;
		}

		public ActionResult KyThu(string TuKhoa, string NamHoc)
		{
			int ID_sv = SinhVien.GetIdSv(TuKhoa);
			DHHHContext db = new DHHHContext();

			var hocky = db.ACC_BienLaiThu.Where(t => t.ID_sv == ID_sv && t.Nam_hoc == NamHoc).Select(t => new
			{
				Hoc_ky = t.Hoc_ky
			}).Distinct().OrderBy(t => t.Hoc_ky).ToList();

			JsonResult result = new JsonResult();
			result.Data = new SelectList(hocky, "Hoc_ky", "Hoc_ky");
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return result;
		}
		public ActionResult DotThu(string TuKhoa, string NamHoc, string HocKy)
		{
			int ID_sv = SinhVien.GetIdSv(TuKhoa);
			DHHHContext db = new DHHHContext();
			var dothu = db.ACC_BienLaiThu.Where(t => t.ID_sv == ID_sv && t.Nam_hoc == NamHoc);
			if (HocKy != "")
			{
				int Hoc_ky = Convert.ToInt32(HocKy);
				dothu = dothu.Where(t => t.Hoc_ky == Hoc_ky);
			}
			var dotthu1 = dothu.Select(t => new
			{
				t.Dot_thu
			}).Distinct().OrderBy(t => t.Dot_thu).ToList();
			JsonResult result = new JsonResult();
			result.Data = new SelectList(dothu, "Dot_thu", "Dot_thu");
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return result;
		}

		public ActionResult LanThu(string TuKhoa, string NamHoc, String HocKy, string DotThu)
		{
			int ID_sv = SinhVien.GetIdSv(TuKhoa);
			DHHHContext db = new DHHHContext();
			var lanthu = db.ACC_BienLaiThu.Where(t => t.ID_sv == ID_sv && t.Nam_hoc == NamHoc);
			if (HocKy != "")
			{
				int Hoc_ky = Convert.ToInt32(HocKy);
				lanthu = lanthu.Where(t => t.Hoc_ky == Hoc_ky);
			}
			if (DotThu != "")
			{
				int Dot_thu = Convert.ToInt32(DotThu);
				lanthu = lanthu.Where(t => t.Dot_thu == Dot_thu);
			}
			var lanthu1 = lanthu.Select(t => new
			{
				Lan_thu = t.Lan_thu
			}).Distinct().OrderBy(t => t.Lan_thu).ToList();
			JsonResult result = new JsonResult();
			result.Data = new SelectList(lanthu1, "Lan_thu", "Lan_thu");
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return result;
		}

		public ActionResult BienLaiThu([DataSourceRequest] DataSourceRequest request, string TuKhoa, string NamHoc, String HocKy, String DotThu, string LanThu)
		{
			int ID_sv = SinhVien.GetIdSv(TuKhoa);
			var bienlai = SinhVien.GetBienLai(ID_sv);
			if (NamHoc != "") bienlai = bienlai.Where(t => t.Nam_hoc == NamHoc).ToList();
			if (HocKy != "")
			{
				int Hoc_ky = Convert.ToInt32(HocKy);
				bienlai = bienlai.Where(t => t.Hoc_ky == Hoc_ky).ToList();
			}
			if (DotThu != "")
			{
				int Dot_thu = Convert.ToInt32(DotThu);
				bienlai = bienlai.Where(t => t.Dot_thu == Dot_thu).ToList();
			}
			if (LanThu != "")
			{
				int Lan_thu = Convert.ToInt32(LanThu);
				bienlai = bienlai.Where(t => t.Lan_thu == Lan_thu).ToList();
			}


			return Json(bienlai.ToDataSourceResult(request));
		}
		#endregion

	}
}
