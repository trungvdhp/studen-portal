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
    [Table("STU_HanhVi")]
    public partial class STU_HanhVi
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_hanh_vi { get; set; }
		
		[Display(Name = "Mã hành vi")]
        public string Ma_hanh_vi { get; set; }
		
		[Display(Name = "Hành vi")]
        public string Hanh_vi { get; set; }
    }
}
