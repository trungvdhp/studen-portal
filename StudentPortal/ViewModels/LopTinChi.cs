using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentPortal.ViewModels
{
    public class LopTinChiViewModel
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

        [DisplayName("Sĩ số")]
        public int Si_so { get; set; }

        [DisplayName("Đã ĐK")]
        public int Da_dang_ky { get; set; }

        [DisplayName("Chi tiết")]
        public string Chi_tiet { get; set; }

        [DisplayName("Giảng viên")]
        public string Giang_vien { get; set; }

        public bool Chua_dang_ky { get; set; }

        public int ID_lop_lt { get; set; }

        public int ID_cb { get; set; }

        public int STT_lop { get; set; }

        public List<SuKienTinChi> SuKienTinChi { get; set; }

        public LopTinChiViewModel()
        {
            this.SuKienTinChi = new List<SuKienTinChi>();
        }
        
    }
}