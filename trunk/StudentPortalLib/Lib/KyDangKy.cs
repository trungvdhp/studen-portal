using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPortal;

namespace StudentPortal.Lib
{
    public class KyDangKy
    {
        public static List<StudentPortal.ViewModels.KyDangKy> getAll()
        {
            DHHHContext db = new DHHHContext();
            return db.PLAN_HocKyDangKy_TC.ToList().Select(t => new StudentPortal.ViewModels.KyDangKy
            {
                Ky_dang_ky = t.Ky_dang_ky,
                Ten_ky = string.Format("{0} kỳ {1} đợt {2}",t.Nam_hoc,t.Hoc_ky,t.Dot)
            }).ToList();
        }
    }
}
