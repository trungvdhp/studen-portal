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
    
    public partial class STU_HanhVi
    {
        [Key]
        public int ID_hanh_vi { get; set; }
        public string Ma_hanh_vi { get; set; }
        public string Hanh_vi { get; set; }
    }
}
