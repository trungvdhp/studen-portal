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
    
    public partial class MARK_QuyetDinhThoiHocChiTiet
    {
        [Key]
        public int ID_qd { get; set; }
        public int ID_sv { get; set; }
        public int ID_lop_cu { get; set; }
        public int ID_lop_moi { get; set; }
    }
}
