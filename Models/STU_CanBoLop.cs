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
    
    public partial class STU_CanBoLop
    {
        [Key]
        public int ID_sv { get; set; }
        public int Nam_bat_dau { get; set; }
        public int ID_chuc_danh { get; set; }
        public string Chuc_danh_kiem { get; set; }
        public Nullable<int> Nam_ket_thuc { get; set; }
    }
}