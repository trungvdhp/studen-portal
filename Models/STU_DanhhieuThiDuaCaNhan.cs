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
    
    public partial class STU_DanhhieuThiDuaCaNhan
    {
        [Key]
        public int ID_sv { get; set; }
        public int Hoc_ky { get; set; }
        public string Nam_hoc { get; set; }
        public Nullable<float> TBCHT { get; set; }
        public Nullable<float> DRL { get; set; }
        public Nullable<float> TBCMR { get; set; }
        public Nullable<int> ID_danh_hieu { get; set; }
    }
}
