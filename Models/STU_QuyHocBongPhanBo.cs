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
    [Table("STU_QuyHocBongPhanBo")]
    public partial class STU_QuyHocBongPhanBo
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_phan_bo { get; set; }
		
		[Display(Name = "Tên phân bổ")]
        public string Ten_phan_bo { get; set; }
		
		[Display(Name = "ID hb")]
		[ForeignKey("STU_QuyHocBong")]
        public int ID_hb { get; set; }
		
		[Display(Name = "Số sinh viên")]
        public int So_sv { get; set; }
		
		[Display(Name = "Số tiền")]
        public long So_tien { get; set; }
		
		[Display(Name = "Phần đặc biệt")]
        public bool Phan_dac_biet { get; set; }
		
		public virtual STU_QuyHocBong STU_QuyHocBong { get; set; }
    }
}
