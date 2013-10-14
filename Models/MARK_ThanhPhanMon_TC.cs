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
    [Table("MARK_ThanhPhanMon_TC")]
    public partial class MARK_ThanhPhanMon_TC
    {
        public MARK_ThanhPhanMon_TC()
        {
            this.MARK_DiemThanhPhan_TC = new HashSet<MARK_DiemThanhPhan_TC>();
        }
    
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_thanh_phan { get; set; }
		
		[Display(Name = "STT")]
        public int STT { get; set; }
		
		[Display(Name = "Ký hiệu")]
        public string Ky_hieu { get; set; }
		
		[Display(Name = "Tê thành phần")]
        public string Ten_thanh_phan { get; set; }
		
		[Display(Name = "Tỷ lệ")]
        public int Ty_le { get; set; }
		
		[Display(Name = "Chọn mặc định")]
        public Nullable<int> Chon_mac_dinh { get; set; }
		
		[Display(Name = "Chuyên cần")]
        public Nullable<int> Chuyen_can { get; set; }
    
        public virtual ICollection<MARK_DiemThanhPhan_TC> MARK_DiemThanhPhan_TC { get; set; }
    }
}