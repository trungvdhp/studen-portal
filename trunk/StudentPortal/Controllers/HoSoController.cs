using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class HoSoController : BaseController
    {

        public ActionResult Index()
        {
            ViewBag.SinhVien = this.sinhVien.First().Value.STU_HoSoSinhVien;
            return View();
        }


        public ActionResult Luu(ViewModels.HoSoSinhVien model) {
            try
            {
                //if(ModelState.IsValid)
                var db = new DHHHContext();
                var sinhvien = this.sinhVien.First();
                var hoso = db.STU_HoSoSinhVien.Single(t => t.ID_sv == sinhvien.Value.ID_sv);
                hoso.Ho_ten_cha = model.Ho_ten_cha;
                hoso.Ho_ten_me = model.Ho_ten_me;
                hoso.Dia_chi_bao_tin = model.Dia_chi_bao_tin;
                hoso.Email = model.Email;
                hoso.Dienthoai_canhan = model.Dienthoai_canhan;

                db.SaveChanges();
                return Json(new AjaxResult { 
                    Status = AjaxStatus.SUCCESS,
                    Message = "Đã cập nhật thông tin",
                });
            }
            catch (Exception ex) {
                return Json(new AjaxResult { 
                    Status = AjaxStatus.ERROR,
                    Message = ex.Message
                });
            }
        }
    }
}
