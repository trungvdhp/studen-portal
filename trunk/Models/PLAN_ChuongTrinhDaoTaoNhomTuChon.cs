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
    [Table("PLAN_ChuongTrinhDaoTaoNhomTuChon")]
    public partial class PLAN_ChuongTrinhDaoTaoNhomTuChon
    {
        [Key]
        public int ID_dt { get; set; }
		
		[Display(Name = "Nhóm tự chọn")]
        public int Nhom_tu_chon { get; set; }
		
		[Display(Name = "Số môn tự chọn")]
        public int So_mon_tu_chon { get; set; }
		
		[Display(Name = "Số môn đăng ký")]
        public int So_mon_dang_ky { get; set; }
    }
}
