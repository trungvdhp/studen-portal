using StudentPortal.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class SinhVienController : BaseController
    {
        //public ActionResult ThongTin(int ID_sv,int ID_dt)
        //{

        //}
        public ActionResult TrangThaiCanhCao(int ID_danh_sach)
        {
            var sinhvien = db.STU_DanhSach.Single(t => t.ID_danh_sach == ID_danh_sach);
            var hockytruoc = SinhVien.GetHocKyTruoc(sinhvien.ID_sv, sinhvien.STU_Lop.ID_dt);
            var xetLenLop = db.Mark_XetLenLop.Where(t => t.ID_sv == ID_sv && t.Hoc_ky == hockytruoc.Hoc_ky && t.Nam_hoc == hockytruoc.Nam_hoc);
            if (xetLenLop.Count() > 0)
            {
                var dkLenLop = xetLenLop.First();
                return Json(new AjaxResult
                {
                    Status = AjaxStatus.SUCCESS,
                    Data = new
                    {
                        ID_danh_sach = ID_danh_sach,
                        Lan_canh_bao = dkLenLop.Lan_canh_bao,
                    }
                });
            }
            return Json(new AjaxResult
            {
                Status = AjaxStatus.ERROR,
                Message = "Không tìm thấy dữ liệu cảnh cáo của sinh viên này!",
                Data = new {
                    ID_danh_sach= ID_danh_sach
                }
            });
        }
        public ActionResult getIDSV(string TuKhoa)
        {
            var ID_sv = SinhVien.GetIdSv(TuKhoa);

            return Json(new AjaxResult { 
                Status = AjaxStatus.SUCCESS,
                Data = ID_sv
            },JsonRequestBehavior.AllowGet);
        }
    }
}
