using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace StudentPortal.ViewModels
{
    public class QuyDinhDKViewModel
    {
        public int Id { get; set; }

        public string Chuyen_nganh { get; set; }

        public string Nam_hoc { get; set; }

        public int Hoc_ky { get; set; }

        public DateTime Tu_ngay { get; set; }

        public DateTime Den_ngay { get; set; }

        public bool Chon_dang_ky { get; set; }

        public int Khoa_hoc { get; set; }
    }
}
