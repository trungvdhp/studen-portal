using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.ViewModels
{
    public class QuyDinhDKViewModel
    {
        public int Id { get; set; }

        public int ID_chuyen_nganh { get; set; }

        [UIHint("Chuyên ngành")]
        [DisplayName("Chuyên ngành")]
        public ChuyenNganh ChuyenNganh { get; set; }

        [UIHint("Kỳ đăng ký")]
        [DisplayName("Kỳ đăng ký")]
        public KyDangKy KyDangKy { get; set; }

        [DisplayName("Năm học")]
        public string Nam_hoc { get; set; }

        [DisplayName("Học kỳ")]
        public int Hoc_ky { get; set; }

        [DisplayName("Từ ngày")]
        [DataType(DataType.Date)]
        public DateTime Tu_ngay { get; set; }

        [DisplayName("Đến ngày")]
        [DataType(DataType.Date)]
        public DateTime Den_ngay { get; set; }

        [DisplayName("Chọn đăng ký")]
        public bool Chon_dang_ky { get; set; }

        [DisplayName("Khóa học")]
        public int Khoa_hoc { get; set; }
    }
}
