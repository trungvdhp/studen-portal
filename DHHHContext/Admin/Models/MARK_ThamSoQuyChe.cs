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
    [Table("MARK_ThámoQuyChe")]
    public partial class MARK_ThamSoQuyChe
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_tham_so_qc { get; set; }
		
		[Display(Name = "Quy chế")]
        public int Quy_che { get; set; }
		
		[Display(Name = "Mã tham số")]
        public string Ma_tham_so { get; set; }
		
		[Display(Name = "Nhóm quy chế")]
        public string Nhom_quy_che { get; set; }
		
		[Display(Name = "Tên tham số")]
        public string Ten_tham_so { get; set; }
		
		[Display(Name = "Giá trị")]
        public float Gia_tri { get; set; }
    }
}