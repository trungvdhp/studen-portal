//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace StudentPortal
{
    using System;
    using System.Collections.Generic;
    
    public partial class PLAN_MonTinChi_TC
    {
        public PLAN_MonTinChi_TC()
        {
            this.PLAN_LopTinChi_TC = new HashSet<PLAN_LopTinChi_TC>();
            this.PLAN_PhamViDangKy_TC = new HashSet<PLAN_PhamViDangKy_TC>();
        }
    
        public int ID_mon_tc { get; set; }
        public int Ky_dang_ky { get; set; }
        public string Ky_hieu_lop_tc { get; set; }
        public int ID_mon { get; set; }
        public int So_tin_chi { get; set; }
        public int He_so { get; set; }
        public Nullable<int> So_tien { get; set; }
        public int Ly_thuyet { get; set; }
        public int Thuc_hanh { get; set; }
        public int Bai_tap { get; set; }
        public int Bai_tap_lon { get; set; }
        public bool Locked { get; set; }
    
        public virtual MARK_MonHoc MARK_MonHoc { get; set; }
        public virtual ICollection<PLAN_LopTinChi_TC> PLAN_LopTinChi_TC { get; set; }
        public virtual ICollection<PLAN_PhamViDangKy_TC> PLAN_PhamViDangKy_TC { get; set; }
    }
}