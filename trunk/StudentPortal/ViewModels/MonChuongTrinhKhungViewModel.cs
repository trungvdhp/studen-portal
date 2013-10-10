using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace StudentPortal.ViewModels
{
    public class MonChuongTrinhKhungViewModel
    {
        public int ID_mon { get; set; }
        public int ID_mon_RB { get; set; }

        [Display(Name="Tên môn")]
        public string Ten_mon { get; set; }

        [Display(Name = "Môn ràng buộc")]
        public string Ten_mon_RB { get; set; }

        [Display(Name = "Kiểu ràng buộc")]
        public string Quan_he_RB { get; set; }
    }
}