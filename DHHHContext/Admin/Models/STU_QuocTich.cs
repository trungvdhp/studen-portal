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
    [Table("STU_QuocTich")]
    public partial class STU_QuocTich
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_quoc_tich { get; set; }
		
		[Display(Name = "Mã quốc tịch")]
        public string Ma_quoc_tich { get; set; }
		
		[Display(Name = "Quốc tịch")]
        public string Quoc_tich { get; set; }
    }
}
