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
    [Table("PLAN_CaHoc")]
    public partial class PLAN_CaHoc
    {
		[Key]
        public int Ca { get; set; }
		
		[Display(Name = "Tên ca")]
        public string Ten_ca { get; set; }
    }
}
