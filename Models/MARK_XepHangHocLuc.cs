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
    
    public partial class MARK_XepHangHocLuc
    {
        [Key]
        public int ID_xep_hang { get; set; }
        public float Tu_diem { get; set; }
        public float Den_diem { get; set; }
        public string Xep_hang { get; set; }
    }
}
