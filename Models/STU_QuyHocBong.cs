//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace StudentPortal
{
    using System;
    using System.Collections.Generic;
    [Table("STU_QuyHocBong")]
    public partial class STU_QuyHocBong
    {
        [Key]
        public int ID_hb { get; set; }
		
		[Display(Name = "ID Quỹ")]
        public int ID_quy { get; set; }
		
		[Display(Name = "ID hệ")]
        public int ID_he { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "NĂm học")]
        public string Nam_hoc { get; set; }
		
		[Display(name = ""Từ khóa)]
        public int Tu_khoa { get; set; }
		
		[Display(Name = "Đến khóa")]
        public int Den_khoa { get; set; }
		
		[Display(Name = "Số tiền ngân sách")]
        public Nullable<decimal> Sotien_ngansach { get; set; }
		
		[Display(Name = "Số tiền khác")]
        public Nullable<decimal> Sotien_khac { get; set; }
		
		[Display(Name = "Ghi chú")]
        public string Ghi_chu { get; set; }
    }
}
