using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Globalization;
using System.Text.RegularExpressions;

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
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, ViewModels.QuyDinhDKViewModel model,int Ky_dang_ky, string Tu_ngay, string Den_ngay)
        {
            if (model != null && ModelState.IsValid)
            {
            //var regex = new Regex("(?<M>[0-9]+)/(?<d>[0-9]+)/(?<y>[0-9]+) (?<h>[0-9]+):(?<m>[0-9]+):(?<s>[0-9]+) (?<t>[APM]+)");
            //var match1 = regex.Match(Tu_ngay);
            //var match2 = regex.Match(Den_ngay);
            //var tungay = new DateTime(Convert.ToInt32(match1.Groups["y"].ToString()), Convert.ToInt32(match1.Groups["M"].ToString()), Convert.ToInt32(match1.Groups["d"].ToString()));
            //var denngay = new DateTime(Convert.ToInt32(match2.Groups["y"].ToString()), Convert.ToInt32(match2.Groups["M"].ToString()), Convert.ToInt32(match2.Groups["d"].ToString()));

            db.PLAN_QUYDINH_DANGKY.Add(new PLAN_QUYDINH_DANGKY
            {
                Ky_dang_ky = Ky_dang_ky,
                ID_Chuyen_nganh = model.ChuyenNganh.Id_chuyen_nganh,
                Khoa_hoc = model.Khoa_hoc,
                Tu_ngay = model.Tu_ngay,
                Den_ngay = model.Den_ngay,

            });
            //model.Tu_ngay = tungay;
            //model.Den_ngay = denngay;
            db.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ViewModels.QuyDinhDKViewModel model, string Tu_ngay, string Den_ngay)
        {
            //var regex = new Regex("(?<M>[0-9]+)/(?<d>[0-9]+)/(?<y>[0-9]+) (?<h>[0-9]+):(?<m>[0-9]+):(?<s>[0-9]+) (?<t>[APM]+)");
            //var match1 = regex.Match(Tu_ngay);
            //var match2 = regex.Match(Den_ngay);
            //var tungay = new DateTime(Convert.ToInt32(match1.Groups["y"].ToString()), Convert.ToInt32(match1.Groups["M"].ToString()), Convert.ToInt32(match1.Groups["d"].ToString()));
            //var denngay = new DateTime(Convert.ToInt32(match2.Groups["y"].ToString()), Convert.ToInt32(match2.Groups["M"].ToString()), Convert.ToInt32(match2.Groups["d"].ToString()));
            if (model != null && ModelState.IsValid)
            {
                var quydinh = db.PLAN_QUYDINH_DANGKY.Single(t => t.ID == model.Id);
                quydinh.Ky_dang_ky = model.KyDangKy.Ky_dang_ky;
                quydinh.ID_Chuyen_nganh = model.ID_chuyen_nganh;
                quydinh.Khoa_hoc = model.Khoa_hoc;
                quydinh.Tu_ngay = model.Tu_ngay;
                quydinh.Den_ngay = model.Den_ngay;

                db.SaveChanges();
            }
            //model.Tu_ngay = tungay;
            //model.Den_ngay = denngay;
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, ViewModels.QuyDinhDKViewModel model)
        {
            if (model != null)
            {
                db.PLAN_QUYDINH_DANGKY.Remove(db.PLAN_QUYDINH_DANGKY.Single(t => t.ID == model.Id));
                db.SaveChanges();
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
