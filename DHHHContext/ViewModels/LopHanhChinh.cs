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
using System;
using System.Collections.Generic;

namespace StudentPortal.ViewModels
{    
    public partial class LopHanhChinhViewModel
    {
        public int ID_lop { get; set; }

        [Display(Name = "Tên lớp")]
        public string Ten_lop { get; set; }

        [Display(Name = "ID Hệ")]
        public int ID_he { get; set; }

        [Display(Name = "ID Khoa")]
        public int ID_khoa { get; set; }

        [Display(Name = "ID Chuyên ngành")]
        public int ID_chuyen_nganh { get; set; }

        [Display(Name = "Khóa học")]
        public int Khoa_hoc { get; set; }

        [Display(Name = "Niên khóa")]
        public string Nien_khoa { get; set; }

        [Display(Name = "ID Đối tượng")]
        public int ID_dt { get; set; }

        [Display(Name = "Số SV")]
        public Nullable<int> So_sv { get; set; }

        [Display(Name = "Ra trường")]
        public bool Ra_truong { get; set; }

        [Display(Name = "Ca học")]
        public int Ca_hoc { get; set; }

        [Display(Name = "ID Phòng")]
        public int ID_phong { get; set; }

        [Display(Name = "Họ tên GV")]
        public string Ho_ten_gv { get; set; }

        [Display(Name = "Điện thoại")]
        public string Dien_thoai { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tính chất")]
        public Nullable<int> Tinh_chat { get; set; }

        [Display(Name = "Lớp chuyên ngành")]
        public Nullable<int> Lop_chuyen_nganh { get; set; }

        [Display(Name = "Lớp hành chính")]
        public Nullable<int> Lop_hanh_chinh { get; set; }
    }
}
