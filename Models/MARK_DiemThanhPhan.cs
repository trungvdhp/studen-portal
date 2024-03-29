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
    [Table("MARK_DiemThanhPhan")]
    public partial class MARK_DiemThanhPhan
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_diem_tp { get; set; }
		
		[Display(Name = "ID Điểm")]
		[ForeignKey("MARK_Diem_TC")]
        public int ID_diem { get; set; }
		
		[Display(Name = "Lần học")]
        public int Lan_hoc { get; set; }
		
		[Display(Name = "ID Thành phần")]
		[ForeignKey("MARK_ThanhPhanMon_TC")]
        public int ID_thanh_phan { get; set; }
		
		[Display(Name = "Điểm")]
        public float Diem { get; set; }
		
		[Display(Name = "Tỷ lệ")]
        public int Ty_le { get; set; }
		
		[Display(Name = "Lý do")]
        public string Ly_do { get; set; }
		
		[Display(Name = "Hash code")]
        public int Hash_code { get; set; }
		
		[Display(Name = "Locked_tp")]
        public int Locked_tp { get; set; }
		
		public virtual MARK_Diem_TC MARK_Diem_TC { get; set; }
		
		public virtual MARK_ThanhPhanMon_TC MARK_ThanhPhanMon_TC { get; set; }
    }
}
