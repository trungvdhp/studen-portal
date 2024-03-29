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
    [Table("PLAN_ChuongTrinhDaoTao")]
    public partial class PLAN_ChuongTrinhDaoTao
    {
        public PLAN_ChuongTrinhDaoTao()
        {
            this.MARK_Diem_TC = new HashSet<MARK_Diem_TC>();
        }
		
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_dt { get; set; }
		
		[Display(Name = "ID Hệ")]
		[ForeignKey("STU_He")]
        public int ID_he { get; set; }
		
		[Display(Name = "ID Khoa")]
		[ForeignKey("STU_Khoa")]
        public int ID_khoa { get; set; }
		
		[Display(Name = "Khóa học")]
        public int Khoa_hoc { get; set; }
		
		[Display(Name = "ID Chuyên ngành")]
		[ForeignKey("STU_ChuyenNganh")]
        public int ID_chuyen_nganh { get; set; }
		
		[Display(Name = "Số học trình")]
        public float So_hoc_trinh { get; set; }
		
		[Display(Name = "Số kỳ học")]
        public int So_ky_hoc { get; set; }
		
		[Display(Name = "Số")]
        public Nullable<int> So { get; set; }
    
        public virtual ICollection<MARK_Diem_TC> MARK_Diem_TC { get; set; }
		
        public virtual STU_He STU_He { get; set; }
		
        public virtual STU_Khoa STU_Khoa { get; set; }
		
		public virtual STU_ChuyenNganh STU_ChuyenNganh { get; set; }
    }
}
