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
    
    public partial class MARK_LoaiChungChiDanhSachMon
    {
        [Key]
        public int ID_chung_chi { get; set; }
        public int ID_mon { get; set; }
        public int ID_dt { get; set; }
    }
}