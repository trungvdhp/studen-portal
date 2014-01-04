using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentPortal.ViewModels
{
    public class SinhVienViewModel
    {
        public int ID_sv { get; set; }

        [DisplayName("Họ tên")]
        public string Ho_ten { get; set; }

        [DisplayName("Lớp")]
        public string Lop { get; set; }

        [DisplayName("Mã SV")]
        public string Ma_sv { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime Ngay_sinh { get; set; }

        [DisplayName("Đã rút")]
        public bool Rut_bot_hoc_phan { get; set; }

        [DisplayName("Trạng thái đăng ký")]
        public string Trang_thai_dk { get; set; }
        
        [DisplayName("Số tín chỉ")]
        public int So_tin_chi { get; set; }

        public int? ID_danh_sach { get; set; }

        [DisplayName("Lần cảnh báo")]
        public int? Lan_canh_bao { get; set; }

        public int Duyet;

    }
}