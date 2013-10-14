using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentPortal.Lib
{
    public class HocPhi
    {
        public static ACC_MucHocPhiTinChi getMucHocPhi(DHHHContext db, int Ky_dang_ky,int ID_he, int ID_chuyen_nganh, int Khoa_hoc)
        {
            try
            {
                var HocKyDangKy = db.PLAN_HocKyDangKy_TC.Single(t => t.Ky_dang_ky == Ky_dang_ky);

                var muchocphis = db.ACC_MucHocPhiTinChi.Where(t => t.Hoc_ky == HocKyDangKy.Hoc_ky && t.Nam_hoc == HocKyDangKy.Nam_hoc).ToList();
                muchocphis = muchocphis.Where(t => t.ID_he == ID_he || t.ID_he == 0).ToList();
                muchocphis = muchocphis.Where(t => t.ID_chuyen_nganh == ID_chuyen_nganh || t.ID_chuyen_nganh == 0).ToList();
                muchocphis = muchocphis.Where(t => t.Khoa_hoc == Khoa_hoc || t.Khoa_hoc == 0).ToList();
                return muchocphis.First();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}