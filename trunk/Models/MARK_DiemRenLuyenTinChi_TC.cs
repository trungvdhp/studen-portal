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
    
    public partial class MARK_DiemRenLuyenTinChi_TC
    {
        [Key]
        public int ID_diem_rl { get; set; }
        public int Hoc_ky { get; set; }
        public string Nam_hoc { get; set; }
        public int ID_sv { get; set; }
        public int ID_mon_tc { get; set; }
        public int Diem { get; set; }
        public string Ten_mon { get; set; }
        public string Ten_lop_tc { get; set; }
    }
}
