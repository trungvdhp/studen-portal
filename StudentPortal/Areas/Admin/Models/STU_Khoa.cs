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
    [Table("STU_Khoa")]
    public partial class STU_Khoa
    {
        /*public STU_Khoa()
        {
            this.PLAN_ChuongTrinhDaoTao = new HashSet<PLAN_ChuongTrinhDaoTao>();
        }*/
    
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_khoa { get; set; }
		
		[Display(Name = "Mã khoa")]
        public string Ma_khoa { get; set; }
		
		[Display(Name = "Tên khoa")]
        public string Ten_khoa { get; set; }
		
		[Display(Name = "Tên khoa EN")]
        public string Ten_khoa_en { get; set; }
    
        //public virtual ICollection<PLAN_ChuongTrinhDaoTao> PLAN_ChuongTrinhDaoTao { get; set; }
    }
}