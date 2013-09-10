using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentPortal.ViewModels
{
    public class LopTinChi
    {
        public int ID_lop_tc { get; set; }

        [DisplayName("Tên môn")]
        public string Ten_mon { get; set; }

        [DisplayName("Ký hiệu lớp tín chỉ")]
        public string Ky_hieu_lop_tc { get; set; }

        [DisplayName("Tên lớp")]
        public string Ten_lop_tc { get; set; }

        [DisplayName("Đợt")]
        public int Dot { get; set; }

        [DisplayName("Học kỳ")]
        public int Hoc_ky { get; set; }

        [DisplayName("Năm học")]
        public string Nam_hoc { get; set; }

        [DisplayName("Mã môn")]
        public string Ma_mon { get; set; }

        [DisplayName("Địa điểm")]
        public string Dia_diem { get; set; }

        [DisplayName("Sĩ số")]
        public int Si_so { get; set; }

        [DisplayName("Đã đăng ký")]
        public int Da_dang_ky { get; set; }

        public int ID_lop_lt { get; set; }

        public int ID_cb { get; set; }

        public int STT_lop { get; set; }

        public List<SuKienTinChi> SuKienTinChi { get; set; }

        public LopTinChi()
        {
            this.SuKienTinChi = new List<SuKienTinChi>();
        }
        
    }
}