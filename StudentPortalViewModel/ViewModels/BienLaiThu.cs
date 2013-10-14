using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.ViewModels
{
	public class BienLaiThu
	{

		public int Id_bien_lai { get; set; }

		[Display(Name="Học kỳ")]
		public int Hoc_ky { get; set; }

		[Display(Name="Năm học")]
		public string Nam_hoc { get; set; }

		[Display(Name="Đợt thu")]
		public int Dot_thu { get; set; }

		[Display(Name="Lần thu")]
		public string Ten_lan { get; set; }

		[Display(Name="Lần thu")]
		public int Lan_thu { get; set; }

		[Display(Name="Số tiền")]
		public int So_tien { get; set; }

		[Display(Name="Số tiền chữ")]
		public string So_tien_chu { get; set; }

		[Display(Name="Người thu")]
		public string Nguoi_thu { get; set; }

		[Display(Name="Ngày thu")]
		public DateTime? Ngay_thu {get;set;}

		[Display(Name="Số phiếu")]
		public int So_phieu { get; set; }
        
        public int ID_mon_tc { get; set; }

        public bool Chua_dong { get; set; }

		[Display(Name="Nội dung")]
		public string Noi_dung { get; set; }

		[Display(Name="Tên thu chi")]
		public string Ten_thu_chi { get; set; }

		[Display(Name="Ghi chú")]
		public string Ghi_chu { get; set; }

	}
}