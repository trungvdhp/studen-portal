using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.ViewModels
{
    public class HoSoSinhVien
    {
        [DisplayName("Mã sinh viên")]
        public int Ma_sv { get; set; }

        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }
        
        [DisplayName("Điện thoại cá nhân")]
        [Required]
        public string Dienthoai_canhan { get; set; } 

        [DisplayName("Họ tên cha")]
        public string Ho_ten_cha { get; set; }
        
        [DisplayName("Họ tên mẹ")]
        public string Ho_ten_me { get; set; }

        [DisplayName("Địa chỉ báo tin")]
        [Required]
        public string Dia_chi_bao_tin { get; set; }

        [DisplayName("Họ tên")]
        [Required]
        public string Ho_ten { get; set; }
    }
}
