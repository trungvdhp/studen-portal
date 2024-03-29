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
    [Table("STU_DanhhieuThiDuaCaNhan")]
    public partial class STU_DanhhieuThiDuaCaNhan
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_sv { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "TBCHT")]
        public Nullable<float> TBCHT { get; set; }
		
		[Display(Name = "DRL")]
        public Nullable<float> DRL { get; set; }
		
		[Display(Name = "TBCMR")]
        public Nullable<float> TBCMR { get; set; }
		
		[Display(Name = "ID Danh hiệu")]
		[ForeignKey("STU_DanhHieu")]
        public Nullable<int> ID_danh_hieu { get; set; }
		
		public virtual STU_DanhHieu STU_DanhHieu { get; set; }
    }
}
