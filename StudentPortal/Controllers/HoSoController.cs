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
                hoso.Dien_thoai_NR = model.Dien_thoai_NR;
                //hoso.ID_dan_toc = model.ID_dan_toc;
                //hoso.ID_dan_toc_cha = model.ID_dan_toc_cha;
                //hoso.ID_dan_toc_me = model.ID_dan_toc_me;
                //hoso.ID_doi_tuong_TC = model.ID_doi_tuong_TC;
                //hoso.ID_doi_tuong_TS = model.ID_doi_tuong_TS;
                //hoso.ID_gioi_tinh = model.ID_gioi_tinh;
                //hoso.ID_huyen_tt = model.ID_huyen_tt;
                //hoso.ID_tinh_ns = model.ID_tinh_ns;
                //hoso.ID_tinh_tt = model.ID_tinh_tt;
                //hoso.ID_quoc_tich_cha = model.ID_quoc_tich_cha;
                //hoso.ID_quoc_tich_me = model.ID_quoc_tich_me;
                hoso.Xa_phuong_tt = model.Xa_phuong_tt;
                hoso.NoiO_hiennay = model.NoiO_hiennay;
                hoso.CMND = model.CMND;
                hoso.Ngay_cap = model.Ngay_cap;
                hoso.Ngay_sinh = model.Ngay_sinh;
                //hoso.Ngay_vao_doan = model.Ngay_vao_doan;
                ////hoso.Ngay_vao_dang = model.Ngay_vao_dang;
                //hoso.Ngay_nhap_hoc = model.Ngay_nhap_hoc;
                hoso.Ho_khau_TT_cha = model.Ho_khau_TT_cha;
                hoso.Ho_khau_TT_me = model.Ho_khau_TT_me;
                hoso.Namsinh_cha = model.Namsinh_cha;
                hoso.Namsinh_me = model.Namsinh_me;
                hoso.Ton_giao_cha = model.Ton_giao_cha;
                hoso.Ton_giao_me = model.Ton_giao_me;
                hoso.Ton_giao = model.Ton_giao;
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
