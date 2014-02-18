using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.ViewModels
{
    public class ChuyenNganh
    {
        public int ID_dt { get; set; }

        public int Id_chuyen_nganh { get; set; }

        [DisplayName("Chuyên ngành")]
        public string Chuyen_nganh { get; set; }
    }
}