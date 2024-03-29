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
    [Table("STU_He")]
    public partial class STU_He
    {
        public STU_He()
        {
            this.PLAN_ChuongTrinhDaoTao = new HashSet<PLAN_ChuongTrinhDaoTao>();
        }
    
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_he { get; set; }
		
		[Display(Name = "Mã hệ")]
        public string Ma_he { get; set; }
		
		[Display(Name = "Tên hệ")]
        public string Ten_he { get; set; }
		
		[Display(Name = "Quy chế")]
        public int Quy_che { get; set; }
		
		[Display(Name = "Tên hệ EN")]
        public string Ten_he_en { get; set; }
		
		[Display(Name = "Tên bậc học")]
        public string Ten_bac_hoc { get; set; }
		
		[Display(Name = "Loại đào tạo")]
        public string Loai_dao_tao { get; set; }
		
		[Display(Name = "Loại đào tạo EN")]
        public string Loai_dao_tao_en { get; set; }
    
        public virtual ICollection<PLAN_ChuongTrinhDaoTao> PLAN_ChuongTrinhDaoTao { get; set; }
    }
}
