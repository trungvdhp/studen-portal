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
    
    [Table("ACC_DanhSachHocBong")]
    public partial class ACC_DanhSachHocBong
    {
        public int ID_phan_bo { get; set; }
        public int ID_sv { get; set; }
        public int ID_xep_loai_hb { get; set; }
        public int HB_HT { get; set; }
        public int HB_CS { get; set; }
    }
}
