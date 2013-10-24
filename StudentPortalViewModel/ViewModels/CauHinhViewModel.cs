using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace StudentPortal.ViewModels
{
    public class CauHinhViewModel
    {
        public int Id { get; set; }

        [Display(Name="Tên cấu hình")]
        public string Mo_ta { get; set; }

        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [Display(Name = "Giá trị")]
        public string Gia_tri { get; set; }

        [Display(Name = "Kiểu")]
        public string Kieu { get; set; }

        [Display(Name = "Kỳ đăng ký")]
        public int Ky_dang_ky { get; set; }
    }
}
