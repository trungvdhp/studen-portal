﻿//------------------------------------------------------------------------------
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

	[Table("ACC_BienLaiThuChiTiet")]
	public partial class ACC_BienLaiThuChiTiet
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int ID_bien_lai_sub { get; set; }

		[ForeignKey("ACC_BienLaiThu")]
		public int ID_bien_lai { get; set; }

		[ForeignKey("ACC_LoaiThuChi")]
		public int ID_thu_chi { get; set; }

		public int ID_mon_tc { get; set; }

		[Display(Name="Số tiền")]
		public int So_tien { get; set; }

		public string Ghi_chu { get; set; }

		public virtual ACC_BienLaiThu ACC_BienLaiThu { get; set; }

		public virtual ACC_LoaiThuChi ACC_LoaiThuChi { get; set; }
	}
}
