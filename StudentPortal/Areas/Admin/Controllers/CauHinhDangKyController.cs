using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class CauHinhDangKyController : BaseController
    {

        public ActionResult Index()
        {
            ViewBag.KyDangKy = new SelectList(this.db.PLAN_HocKyDangKy_TC.ToList().Select(t => new ViewModels.KyDangKy
            {
                Ky_dang_ky = t.Ky_dang_ky,
                Ten_ky = t.Nam_hoc + "_" + t.Hoc_ky + "_" + t.Dot
            }), "Ky_dang_ky", "Ten_ky");
            if (db.PLAN_HocKyDangKy_TC.Count(t => t.Chon_dang_ky == true) > 0)
            {
                ViewBag.KyDangKyHienTai = db.PLAN_HocKyDangKy_TC.Single(t => t.Chon_dang_ky == true).Ky_dang_ky;
            }
            var chuyenNganhs = new List<ViewModels.ChuyenNganh>(){
                new ViewModels.ChuyenNganh{
                    Id_chuyen_nganh= 0,
                    Chuyen_nganh="Tất cả"
                }
            };
            chuyenNganhs.AddRange(db.STU_ChuyenNganh.Select(t => new ViewModels.ChuyenNganh
            {
                Id_chuyen_nganh = t.ID_chuyen_nganh,
                Chuyen_nganh = t.Chuyen_nganh
            }).ToList());
            var kydangkys = new List<StudentPortal.ViewModels.KyDangKy>();
            kydangkys.AddRange(db.PLAN_HocKyDangKy_TC.ToList().Select(t => new StudentPortal.ViewModels.KyDangKy
            {
                Ky_dang_ky = t.Ky_dang_ky,
                Ten_ky = t.Nam_hoc + "_" + t.Hoc_ky + "_" + t.Dot
            }).ToList());
            ViewData["chuyenNganhs"] = chuyenNganhs;
            ViewData["kydangkys"] = kydangkys;
            ViewData["defaultKyDangKy"] = kydangkys.First();
            ViewData["defaultChuyenNganh"] = chuyenNganhs.First();
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int Ky_dang_ky)
        {
            return Json(db.PLAN_QUYDINH_DANGKY.Where(t => t.Ky_dang_ky == Ky_dang_ky).ToList().Select(t => new ViewModels.QuyDinhDKViewModel
            {
                Id = t.ID,
                Den_ngay = (DateTime)t.Den_ngay,
                Tu_ngay = (DateTime)t.Tu_ngay,
                Nam_hoc = String.Format("{0}_{1}_{2}", t.PLAN_HocKyDangKy_TC.Nam_hoc, t.PLAN_HocKyDangKy_TC.Hoc_ky, t.PLAN_HocKyDangKy_TC.Dot),
                Khoa_hoc = (int)t.Khoa_hoc,
                //Chuyen_nganh = t.ID_Chuyen_nganh == 0 ? "Tất cả" : t.STU_ChuyenNganh.Chuyen_nganh
                ChuyenNganh = new ViewModels.ChuyenNganh
                {
                    Id_chuyen_nganh = (int)t.ID_Chuyen_nganh,
                    Chuyen_nganh = t.ID_Chuyen_nganh == 0 ? "Tất cả" : t.STU_ChuyenNganh.Chuyen_nganh,
                },
                KyDangKy = new ViewModels.KyDangKy
                {
                    Ky_dang_ky = t.Ky_dang_ky,
                    Ten_ky = String.Format("{0}_{1}_{2}", t.PLAN_HocKyDangKy_TC.Nam_hoc, t.PLAN_HocKyDangKy_TC.Hoc_ky, t.PLAN_HocKyDangKy_TC.Dot)
                }
            }).ToDataSourceResult(request));
        }
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, ViewModels.QuyDinhDKViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                db.PLAN_QUYDINH_DANGKY.Add(new PLAN_QUYDINH_DANGKY
                {
                    Ky_dang_ky = model.KyDangKy.Ky_dang_ky,
                    ID_Chuyen_nganh = model.ChuyenNganh.Id_chuyen_nganh,
                    Khoa_hoc = model.Khoa_hoc,
                    Tu_ngay = model.Tu_ngay,
                    Den_ngay = model.Den_ngay,
                });
                db.SaveChanges();
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}
