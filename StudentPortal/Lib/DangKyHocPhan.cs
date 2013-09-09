using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebMatrix.WebData;


namespace StudentPortal.Lib
{
    public class DangKyHocPhan
    {
        public static List<PLAN_QUYDINH_DANGKY> GetQuyDinhDangKy()
        {
            DHHHContext db = new DHHHContext();
            var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            var sinhVien = SinhVien.GetSinhVien(userProfile);
            var quydinhDangkysTmp = db.PLAN_QUYDINH_DANGKY.Where(t => t.Tu_ngay <= DateTime.Now && t.Den_ngay >= DateTime.Now).ToList();
            var quydinhDangkys = new List<PLAN_QUYDINH_DANGKY>();
            foreach (var quydinhDangky in quydinhDangkysTmp)
            {
                if (quydinhDangky.Khoa_hoc != 0 && quydinhDangky.Khoa_hoc != sinhVien.STU_Lop.Khoa_hoc) continue;
                if (quydinhDangky.ID_Chuyen_nganh != 0 && quydinhDangky.ID_Chuyen_nganh != sinhVien.STU_Lop.ID_chuyen_nganh) continue;
                quydinhDangkys.Add(quydinhDangky);
            }
            return quydinhDangkys;
        }
    }
}