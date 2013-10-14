using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{

    public partial class ViewLopTinChi
    {
        [Key]
        public int ID_lop_tc { get; set; }
        public int ID_mon { get; set; }
        public string Ten_mon { get; set; }
        public string Ky_hieu_lop_tc { get; set; }
        public int ID_cb { get; set; }
        public int Ky_dang_ky { get; set; }
        public int Dot { get; set; }
        public int Hoc_ky { get; set; }
        public string Nam_hoc { get; set; }
        public string Ten_lop_tc { get; set; }
        public System.DateTime Tu_ngay { get; set; }
        public System.DateTime Den_ngay { get; set; }
        public int Ca_hoc { get; set; }
        public int So_tiet_tuan { get; set; }
        public int So_sv_max { get; set; }
        public string Ky_hieu { get; set; }
    }

}