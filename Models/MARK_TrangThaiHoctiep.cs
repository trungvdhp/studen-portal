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
    [Table("MARK_TrangThaiHoctiep")]
    public partial class MARK_TrangThaiHoctiep
    {
        [Key]
        public int ID_ht { get; set; }
		
		[Display(Name = "Trạng thái")]
        public string Trang_thai { get; set; }
    }
}
