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
    [Table("PLAN_HocVi")]
    public partial class PLAN_HocVi
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_hoc_vi { get; set; }
		
		[Display(Name = "Mã học vị")]
        public string Ma_hoc_vi { get; set; }
		
		[Display(Name = "Học vị")]
        public string Hoc_vi { get; set; }
    }
}
