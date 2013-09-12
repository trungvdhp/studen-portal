using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentPortal.Lib;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using StudentPortal.Filters;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using StudentPortal.ViewModels;

namespace StudentPortal.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class DangKyHocPhanController : Controller
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /DangKyHocPhan/

        public ActionResult Index()
        {
            return View();
        }

        #region Ko su dung

        public ActionResult getKhoa(int ID_he)
        {
            JsonResult result = new JsonResult();
            result.Data = new SelectList(ChuongTrinhDaoTao.getKhoa(ID_he), "ID_khoa", "Ten_khoa");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult getHe()
        {
            JsonResult result = new JsonResult();
            result.Data = new SelectList(db.STU_He.ToList(), "ID_he", "Ten_he");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult getKhoaHoc()
        {
            var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            var sinhVien = SinhVien.GetSinhVien(userProfile);
            JsonResult result = new JsonResult();
            result.Data = new SelectList(ChuongTrinhDaoTao.getKhoaHoc(sinhVien.STU_Lop.ID_he, sinhVien.STU_Lop.ID_khoa), "", "");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult getNganh(int Khoa_hoc)
        {
            var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            var sinhVien = SinhVien.GetSinhVien(userProfile);
            JsonResult result = new JsonResult();
            result.Data = new SelectList(ChuongTrinhDaoTao.getNganh(sinhVien.STU_Lop.ID_he, sinhVien.STU_Lop.ID_khoa, Khoa_hoc).Select(t => new
            {
                ID_dt = t.ID_dt,
                Chuyen_nganh = t.STU_ChuyenNganh.Chuyen_nganh,
            }).ToList(), "ID_dt", "Chuyen_nganh");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        #endregion



        public ActionResult getMonHoc(string KieuDK,int ID_dt)
        {
            JsonResult result = new JsonResult();
            DHHHContext db = new DHHHContext();

            var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            var sinhVien = SinhVien.GetSinhVien(userProfile);
            var chuongtrinhDaotao = db.PLAN_ChuongTrinhDaoTao.Single(t =>
                t.ID_dt == ID_dt
                //t.ID_chuyen_nganh == sinhVien.STU_Lop.ID_chuyen_nganh &&
                //t.ID_he == sinhVien.STU_Lop.ID_he &&
                //t.ID_khoa == sinhVien.STU_Lop.ID_khoa &&
                //t.Khoa_hoc == sinhVien.STU_Lop.Khoa_hoc
               );
            if (chuongtrinhDaotao != null)
            {
                var monChuongTrinhKhung = ChuongTrinhDaoTao.getMonHoc(chuongtrinhDaotao.ID_dt);
                var idMonChuongTrinhKhung = monChuongTrinhKhung.Select(t => t.ID_mon).ToList();
                var quydinhDangkys = DangKyHocPhan.GetQuyDinhDangKy();

                if (quydinhDangkys.Count > 0)
                {
                    var hockyDangky = quydinhDangkys[0];


                    var monDangMo = db.PLAN_SukiensTinChi_TC
                        .Where(t => t.Ky_dang_ky == hockyDangky.Ky_dang_ky)
                        .Select(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.MARK_MonHoc)
                        .Distinct()
                        .ToList();


                    List<MARK_MonHoc> monDuocDK = new List<MARK_MonHoc>();

                    foreach (var mon in monDangMo)
                    {
                        if (idMonChuongTrinhKhung.Contains(mon.ID_mon))
                            monDuocDK.Add(mon);
                    }
                    var monDK = new List<MARK_MonHoc>();
                    var bangdiem = SinhVien.GetBangDiem(sinhVien.ID_sv);
                    var dicBangdiem = bangdiem.ToDictionary(t => t.ID_mon, t => t.Z);
                    var monRangBuoc = db.PLAN_ChuongTrinhDaoTaoRangBuoc.Where(t => t.ID_dt == chuongtrinhDaotao.ID_dt).ToList();
                    var dicMonRangBuoc = monRangBuoc.ToDictionary(t => t.ID_mon, t => t);
                    switch (KieuDK)
                    {
                        case "tien_do":
                            foreach (var mon in monDuocDK)
                            {
                                if (!dicBangdiem.ContainsKey(mon.ID_mon) &&
                                        (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
                                            (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
                                                (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 || dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == null ||
                                                    bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
                                                )
                                            )
                                        )
                                    )
                                {
                                    monDK.Add(mon);
                                }
                            }
                            break;
                        case "cai_thien":
                            foreach (var mon in monDuocDK)
                            {
                                if (dicBangdiem.ContainsKey(mon.ID_mon) && dicBangdiem[mon.ID_mon] <= SinhVien.DiemHe4["C+"] &&
                                    (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
                                            (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
                                                (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 || dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == null ||
                                                    bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
                                                )
                                            )
                                        )
                                    )
                                    monDK.Add(mon);
                            }
                            break;
                        case "hoc_lai":
                            foreach (var mon in monDuocDK)
                            {
                                if (dicBangdiem.ContainsKey(mon.ID_mon) && dicBangdiem[mon.ID_mon] < SinhVien.DiemHe4["D"] &&
                                    (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
                                            (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
                                                (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 || dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == null ||
                                                    bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
                                                )
                                            )
                                        )
                                    )
                                    monDK.Add(mon);
                            }
                            break;
                    }

                    result.Data = new SelectList(monDK, "ID_mon", "Ten_mon");
                }
            }

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult getLopTC([DataSourceRequest]DataSourceRequest request, int ID_mon)
        {
            DHHHContext db = new DHHHContext();
            var lopTinChi = DangKyHocPhan.getLopTinChi(ID_mon);
            return Json(lopTinChi.ToDataSourceResult(request));
        }

        public ActionResult getChuyenNganh()
        {
            var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            var sinhVien = SinhVien.GetSinhVien(userProfile);
            JsonResult result = new JsonResult();
            result.Data = new SelectList(SinhVien.getChuyenNganh(sinhVien.ID_sv), "ID_dt", "Chuyen_nganh");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }
}
