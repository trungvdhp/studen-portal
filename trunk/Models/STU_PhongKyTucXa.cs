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
    
    public partial class STU_PhongKyTucXa
    {
        [Key]
        public int ID_phong_KTX { get; set; }
        public Nullable<int> ID_nha_KTX { get; set; }
        public Nullable<int> ID_tang { get; set; }
        public string So_phong_KTX { get; set; }
        public Nullable<int> Suc_chua { get; set; }
        public string Thiet_bi { get; set; }
        public Nullable<int> So_tien_mot_nguoi { get; set; }
        public Nullable<int> ID_co_so { get; set; }
    }
}
