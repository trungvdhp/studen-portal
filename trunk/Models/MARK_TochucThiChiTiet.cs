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
    [Table("MARK_ToChucThiChiTiet")]
    public partial class MARK_TochucThiChiTiet
    {
        [Key]
        public int ID_ds_thi { get; set; }
		
		[Display(Name = "ID Thi")]
        public int ID_thi { get; set; }
		
		[Display(Name = "ID_sv")]
        public int ID_sv { get; set; }
		
		[Display(Name = "ID Phòng thi")]
        public int ID_phong_thi { get; set; }
		
		[Display(Name = "Số báo danh")]
        public string So_bao_danh { get; set; }
		
		[Display(Name = "Số phách")]
        public int So_phach { get; set; }
		
		[Display(Name = "Túi số")]
        public int Tui_so { get; set; }
		
		[Display(Name = "Ghi chú thi")]
        public string Ghi_chu_thi { get; set; }
		
		[Display(Name = "OrderBy")]
        public string OrderBy { get; set; }
    }
}