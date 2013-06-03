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
    [Table("MARK_ToChucThiPhucKhao_TC")]
    public partial class MARK_ToChucThiPhucKhao_TC
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_phuc_khao { get; set; }
		
		[Display(Name = "ID Thi")]
		[ForeignKey("MARK_TochucThi")]
        public int ID_thi { get; set; }
		
		[Display(Name = "ID_ds_thi")]
		[ForeignKey("MARK_TochucThiChiTiet_TC")]
        public int ID_ds_thi { get; set; }
		
		[Display(Name = "Lần")]
        public int Lan { get; set; }
		
		[Display(Name = "Điểm 1")]
        public Nullable<float> Diem1 { get; set; }
		
		[Display(Name = "Điểm 2")]
        public Nullable<float> Diem2 { get; set; }
		
		[Display(Name = "Ghi chú")]
        public string Ghi_chu { get; set; }
		
		public virtual MARK_TochucThi MARK_TochucThi { get; set; }
		
		public virtual MARK_TochucThiChiTiet_TC MARK_TochucThiChiTiet_TC { get; set; }
    }
}