using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentPortal.ViewModels
{
    public class KyDangKy
    {
        [DisplayName("Kỳ đăng ký")]
        public string Ten_ky { get; set; }

        public int Ky_dang_ky { get; set; }
    }
}