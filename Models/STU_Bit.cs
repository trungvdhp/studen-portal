//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace StudentPortal
{
    using System;
    using System.Collections.Generic;
    [Table("STU_Bit")]
    public partial class STU_Bit
    {
		[Key]
        public int ID { get; set; }
        
		[Display(Name = "Giá trị")]
		public string Gia_tri { get; set; }
    }
}
