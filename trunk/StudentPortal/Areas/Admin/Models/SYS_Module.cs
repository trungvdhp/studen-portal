using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal
{
	using System;
	using System.Collections.Generic;

	[Table("SYS_Module")]
	public partial class SYS_Module
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Display(Name = "Tên module")]
		public string Ten_module { get; set; }

		[Display(Name = "Mô tả")]
		public string Mo_ta { get; set; }

		public string Id_cha { get; set; }

		[Display(Name = "Thứ tự")]
		public int Thu_tu { get; set; }

		public string Controller { get; set; }

		public string Method { get; set; }
	}
}