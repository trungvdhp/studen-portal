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
    
    public partial class MARK_ThamSoQuyChe
    {
        [Key]
        public int ID_tham_so_qc { get; set; }
        public int Quy_che { get; set; }
        public string Ma_tham_so { get; set; }
        public string Nhom_quy_che { get; set; }
        public string Ten_tham_so { get; set; }
        public float Gia_tri { get; set; }
    }
}
