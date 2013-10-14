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

        [Display(Name = "Mã môn")]
        public string Ky_hieu { get; set; }
        
        [Display(Name = "Số TC")]
        public float? So_TC { get; set; }

        [Display(Name = "Lý thuyết")]
        public int? Ly_thuyet { get; set; }

        [Display(Name = "Thực hành")]
        public int? Thuc_hanh { get; set; }

        public float? He_so { get; set; }

        [Display(Name = "Ràng buộc")]
        public string Rang_buoc { get; set; }
    }
}