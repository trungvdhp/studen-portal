﻿//------------------------------------------------------------------------------
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

    [Table("SCH_CauHinhThoiGian")]
    public partial class SCH_CauHinhThoiGian
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_thoi_gian { get; set; }
        public string Kieu_thoi_gian { get; set; }
        public string Ngay_thoi_gian { get; set; }
        public string Thoi_gian_bat_dau { get; set; }
        public int Ky_dang_ky { get; set; }
    }
}
