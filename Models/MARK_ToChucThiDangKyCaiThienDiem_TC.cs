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
    [Table("MARK_ToChucThiDangKyCaiThienDiem_TC")]
    public partial class MARK_ToChucThiDangKyCaiThienDiem_TC
    {
		[Key]
        public int ID { get; set; }
		
		[Display(Name = "ID_sv")]
        public int Id_sv { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID Môn")]
        public int Id_mon { get; set; }
		
		[Display(Name = "ID_dt")]
        public int ID_dt { get; set; }
		
		[Display(Name = "Duyệt")]
        public int Duyet { get; set; }
		
		[Display(Name = "Ghi chú")]
        public string Ghi_chu { get; set; }
    }
}
