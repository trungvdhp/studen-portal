//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal
{
	using System;
	using System.Collections.Generic;
	[Table("PLAN_HocKyDangKy_TC")]
	public partial class PLAN_HocKyDangKy_TC
	{
        [Key]
		[Display(Name = "Kỳ đăng ký")]
		public int Ky_dang_ky { get; set; }

		[Display(Name = "Đợt")]
		public int Dot { get; set; }

		[Display(Name = "Học kỳ")]
		public int Hoc_ky { get; set; }

		[Display(Name = "Năm học")]
		public string Nam_hoc { get; set; }

		[Display(Name = "Từ ngày")]
		public System.DateTime Tu_ngay { get; set; }

		[Display(Name = "Đến ngày")]
		public Nullable<System.DateTime> Den_ngay { get; set; }

		[Display(Name = "Chọn đăng ký")]
		public bool Chon_dang_ky { get; set; }
	}
}