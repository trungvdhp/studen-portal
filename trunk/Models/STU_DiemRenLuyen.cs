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
    [Table("STU_DiemRenLuyen")]
    public partial class STU_DiemRenLuyen
    {
        [Key]
        public int ID_diem_rl { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID sinh viên")]
        public int ID_sv { get; set; }
		
		[Display(Name = "ID Loại RL")]
        public int ID_loai_rl { get; set; }
		
		[Display(Name = "Điểm")]
        public int Diem { get; set; }
    }
}
