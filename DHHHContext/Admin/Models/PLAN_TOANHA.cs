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
    [Table("PLAN_TOANHA")]
    public partial class PLAN_TOANHA
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_nha { get; set; }
		
		[Display(Name = "Mã nhà")]
        public string Ma_nha { get; set; }
		
		[Display(Name = "Tên nhà")]
        public string Ten_nha { get; set; }
		
		[Display(Name = "ID Cơ sở")]
		[ForeignKey("PLAN_COSODAOTAO")]
        public int ID_co_so { get; set; }
		
		public virtual PLAN_COSODAOTAO PLAN_COSODAOTAO { get; set; }
    }
}