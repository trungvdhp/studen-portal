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
    
    public partial class PLAN_ThoiGianTinChi_TC
    {
        [Key]
        public int ID_tin_chi { get; set; }
        public Nullable<int> ID_he { get; set; }
        public Nullable<int> Khoa_hoc { get; set; }
        public Nullable<int> Hocky_toithieu { get; set; }
        public Nullable<int> Hocky_toida { get; set; }
    }
}
