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
    
    [Table("ACC_BienLaiThuChiTietCopy")]
    public partial class ACC_BienLaiThuChiTietCopy
    {
        public int ID_bien_lai_sub { get; set; }
        public int ID_bien_lai { get; set; }
        public int ID_thu_chi { get; set; }
        public int ID_mon_tc { get; set; }
        public int So_tien { get; set; }
    }
}
