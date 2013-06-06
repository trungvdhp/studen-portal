using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.ViewModels
{
	public class DiemHocTap
	{
		public int Id_diem;

		public int ID_mon { get; set; }

		[DisplayName("Mã MH")]
		public string Ma_mon { get; set; }

		[DisplayName("Tên môn")]
		public string Ten_mon { get; set; }

		[DisplayName("Hệ số")]
		public float He_so { get; set; }

		[DisplayName("Điểm X")]
		public float X { get; set; }

		[DisplayName("Điểm Y")]
		public float Y { get; set; }

		[DisplayName("Điểm Z")]
		public float Z { get; set; }

		[DisplayName("Điểm chữ")]
		public string Diem_chu { get; set; }

		[DisplayName("Học kỳ")]
		public int Hoc_ky { get; set; }

		[DisplayName("Năm học")]
		public string Nam_hoc { get; set; }
	}
}