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
    
    [Table("ACC_HeSoHocPhi")]
    public partial class ACC_HeSoHocPhi
    {
        public int ID_he { get; set; }
        public float He_so_hoc_lai { get; set; }
        public float He_so_ngoai_ngan_sach { get; set; }
        public float He_so_nganh2 { get; set; }
    }
}