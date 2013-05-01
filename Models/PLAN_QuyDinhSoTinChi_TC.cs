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
    [Table("PLAN_QuyDinhSoTinChi_TC")]
    public partial class PLAN_QuyDinhSoTinChi_TC
    {
        [Key]
        public int ID_he { get; set; }
		
		[Display(Name = "ID Khoa")]
        public int ID_khoa { get; set; }
		
		[Display(Name = "Khóa học")]
        public int Khoa_hoc { get; set; }
		
		[Display(Name = "Kỳ đăng ký")]
        public int Ky_dang_ky { get; set; }
		
		[Display(Name = "Số học trình Min bt")]
        public Nullable<int> So_hoc_trinh_min_bt { get; set; }
		
		[Display(Name = "Số học trình Max bt")]
        public Nullable<int> So_hoc_trinh_max_bt { get; set; }
		
		[Display(Name = "Số học trình Option bt ")]
        public Nullable<int> So_hoc_trinh_option_bt { get; set; }
		
		[Display(Name = "Check số học trình Min bt")]
        public Nullable<bool> Check_so_hoc_trinh_min_bt { get; set; }
		
		[Display(Name = "Check số học trình Max bt")]
        public Nullable<bool> Check_so_hoc_trinh_max_bt { get; set; }
		
		[Display(Name = "Số học trình Min yếu")]
        public Nullable<int> So_hoc_trinh_min_yeu { get; set; }
		
		[Display(Name = "Số học trình Max yếu")]
        public Nullable<int> So_hoc_trinh_max_yeu { get; set; }
		
		[Display(Name = "Số học trình Option yếu")]
        public Nullable<int> So_hoc_trinh_option_yeu { get; set; }
		
		[Display(Name = "Check số học trình Min yếu")]
        public Nullable<bool> Check_so_hoc_trinh_min_yeu { get; set; }
		
		[Display(Name = "Check số học trình Max yếu")]
        public Nullable<bool> Check_so_hoc_trinh_max_yeu { get; set; }
		
		[Display(Name = "Từ ngày 1")]
        public Nullable<System.DateTime> Tu_ngay1 { get; set; }
		
		[Display(Name = "Đến ngày 1")]
        public Nullable<System.DateTime> Den_ngay1 { get; set; }
		
		[Display(Name = "Từ ngày 2")]
        public Nullable<System.DateTime> Tu_ngay2 { get; set; }
		
		[Display(Name = "Đến ngày 2")]
        public Nullable<System.DateTime> Den_ngay2 { get; set; }
    }
}
