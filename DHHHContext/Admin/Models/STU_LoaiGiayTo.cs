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
    [Table("STU_LoaiGiayTo")]
    public partial class STU_LoaiGiayTo
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_giay_to { get; set; }
		
		[Display(Name = "Mã giấy tờ")]
        public string Ma_giay_to { get; set; }
		
		[Display(Name = "Tên giấy tờ")]
        public string Ten_giay_to { get; set; }
		
		[Display(Name = "Số lượng")]
        public int So_luong { get; set; }
		
		[Display(Name = "Ẩn")]
        public bool An { get; set; }
    }
}
