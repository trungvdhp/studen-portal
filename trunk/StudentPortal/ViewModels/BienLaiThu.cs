using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.ViewModels
{
	public class BienLaiThu
	{

		public int Id_bien_lai { get; set; }

		[DisplayName("Học kỳ")]
		public int Hoc_ky { get; set; }

		[DisplayName("Năm học")]
		public string Nam_hoc { get; set; }

		[DisplayName("Đợt thu")]
		public int Dot_thu { get; set; }


		[DisplayName("Lần thu")]
		public int Lan_thu { get; set; }

		[DisplayName("Số tiền")]
		public int So_tien { get; set; }

		public int So_tien_ct { get; set; }

		[DisplayName("Số tiền chữ")]
		public string So_tien_chu { get; set; }

		[DisplayName("Người thu")]
		public string Nguoi_thu { get; set; }

		[DisplayName("Số phiếu")]
		public int So_phieu { get; set; }

		[DisplayName("Nội dung")]
		public string Noi_dung {get;set;}

		[DisplayName("Tên thu chi")]
		public string Ten_thu_chi { get; set; }

		[DisplayName("Ghi chú")]
		public string Ghi_chu { get; set; }

	}
}