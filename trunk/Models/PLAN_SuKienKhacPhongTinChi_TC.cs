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
    [Table("STU_SuKienKhacPhongTinChi_TC")]
    public partial class PLAN_SuKienKhacPhongTinChi_TC
    {
        public long ID { get; set; }
		
		[Display(Name = "ID Phòng")]
        public Nullable<int> ID_phong { get; set; }
		
		[Display(Name = "Thứ")]
        public Nullable<int> Thu { get; set; }
		
		[Display(Name = "Tiết")]
        public Nullable<int> Tiet { get; set; }
		
		[Display(Name = "Số tiết")]
        public Nullable<int> So_tiet { get; set; }
		
		[Display(Name = "Mô tả")]
        public string Mo_ta { get; set; }
    }
}
