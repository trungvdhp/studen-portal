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
    
    public partial class MARK_ThanhPhanMon
    {
        [Key]
        public int ID_thanh_phan { get; set; }
        public int ID_he { get; set; }
        public int STT { get; set; }
        public string Ky_hieu { get; set; }
        public string Ten_thanh_phan { get; set; }
        public int Ty_le { get; set; }
        public int Chon_mac_dinh { get; set; }
        public bool Chuyencan { get; set; }
    }
}
