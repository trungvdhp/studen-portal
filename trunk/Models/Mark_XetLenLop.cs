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
    [Table("Mark_XetLenLop")]
    public partial class Mark_XetLenLop
    {
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID_sv")]
        public int ID_sv { get; set; }
		
		[Display(Name = "Lần cảnh báo")]
        public int Lan_canh_bao { get; set; }
		
		[Display(Name = "Lý do")]
        public string Ly_do { get; set; }
		
		[Display(Name = "Số TCTL")]
        public Nullable<double> So_TCTL { get; set; }
		
		[Display(Name = "TBCTL")]
        public Nullable<double> TBCTL { get; set; }
		
		[Display(Name = "Số TCHT")]
        public Nullable<double> So_TCHT { get; set; }
		
		[Display(Name = "TBCHT Kỳ")]
        public Nullable<double> TBCHT_Ky { get; set; }
		
		[Display(Name = "Duyệt")]
        public Nullable<bool> Duyet { get; set; }
    }
}
