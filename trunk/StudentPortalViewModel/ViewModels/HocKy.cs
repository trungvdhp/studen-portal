using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentPortal.ViewModels
{
    public class HocKy
    {
        [DisplayName("Năm học")]
        public string Nam_hoc { get; set; }

        [DisplayName("Học kỳ")]
        public int Hoc_ky { get; set; }
    }
}