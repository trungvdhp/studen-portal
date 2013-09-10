using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentPortal.ViewModels
{
    public class SuKienTinChi
    {
        public int ID { get; set; }

        [DisplayName("Từ ngày")]
        public DateTime Tu_ngay { get; set; }

        [DisplayName("Đến ngày")]
        public DateTime Den_ngay { get; set; }

        [DisplayName("Thứ")]
        public int Thu { get; set; }

        [DisplayName("Tiết")]
        public int Tiet { get; set; }

        [DisplayName("Ca học")]
        public int Ca_hoc { get; set; }

        [DisplayName("Số tiết/tuần")]
        public int So_tiet { get; set; }
    }
}