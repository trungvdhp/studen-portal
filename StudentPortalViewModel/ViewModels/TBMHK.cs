using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace StudentPortal.ViewModels
{
    public class TBMHKViewModel
    {
        [Display(Name="Học kỳ")]
        public string Hoc_ky { get; set; }
        
        [Display(Name="Điểm")]
        public float Diem { get; set; }
        
        [Display(Name="Điểm chữ")]
        public string Diem_chu { get; set; }
    }
}