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
    
    public partial class MOD_VaiTro
    {
        [Key]
        public int ID_vai_tro { get; set; }
        public string Ten_vai_tro { get; set; }
        public string Mo_ta { get; set; }
        public bool He_thong { get; set; }
    }
}