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
    [Table("PLAN_KeHoachKhac_TC")]
    public partial class PLAN_KeHoachKhac_TC
    {
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
		
		[Display(Name = "Học kỳ")]
        public Nullable<int> Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID Hệ")]
		[ForeignKey("STU_He")]
        public int ID_he { get; set; }
		
		[Display(Name = "ID Khoa")]
		[ForeignKey("STU_Khoa")]
        public int ID_khoa { get; set; }
		
		[Display(Name = "Khóa học")]
        public int Khoa_hoc { get; set; }
		
		[Display(Name = "ID Ngành")]
		[ForeignKey("STU_Nganh")]
        public int ID_nganh { get; set; }
		
		[Display(Name = "ID Chuyên ngành")]
		[ForeignKey("STU_ChuyenNganh")]
        public int ID_chuyen_nganh { get; set; }
		
		[Display(Name = "Từ ngày")]
        public System.DateTime Tu_ngay { get; set; }
		
		[Display(Name = "Đến ngày")]
        public System.DateTime Den_ngay { get; set; }
		
		[Display(Name = "Ký hiệu")]
        public string Ky_hieu { get; set; }
		
		[Display(Name = "Hiển thị")]
        public bool Hien_thi { get; set; }
		
		public virtual STU_He STU_He { get; set; }
		
		public virtual STU_Khoa STU_Khoa { get; set; }
		
		public virtual STU_Nganh STU_Nganh { get; set; }
		
		public virtual STU_ChuyenNganh STU_ChuyenNganh { get; set; }
    }
}
