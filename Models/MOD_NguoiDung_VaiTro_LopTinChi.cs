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
    
    public partial class MOD_NguoiDung_VaiTro_LopTinChi
    {
        public int UserID { get; set; }
        public int ID_lop_tc { get; set; }
        public string ID_vai_tro { get; set; }
        public bool Dinh_chi { get; set; }
    
        public virtual MOD_LopTinChi_TC MOD_LopTinChi_TC { get; set; }
        public virtual MOD_NguoiDung MOD_NguoiDung { get; set; }
    }
}
