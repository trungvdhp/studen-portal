using StudentPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StudentPortal.Lib
{
    public class LopTinChi
    {
        private static Dictionary<int, LopTinChiViewModel> _cacheDicLopTC = new Dictionary<int, LopTinChiViewModel>();
        public static Dictionary<int, StudentPortal.ViewModels.LopTinChiViewModel> getListDetails(List<PLAN_SukiensTinChi_TC> sukienTinChis)
        {
            DHHHContext db = new DHHHContext();
            var dicLopTinChi = new Dictionary<int, StudentPortal.ViewModels.LopTinChiViewModel>();

            foreach (var sukienTinChi in sukienTinChis)
            {
                if (!_cacheDicLopTC.ContainsKey(sukienTinChi.ID_lop_tc))
                {
                    if (!dicLopTinChi.ContainsKey(sukienTinChi.ID_lop_tc))
                    {
                        var lopTinChi = sukienTinChi.PLAN_LopTinChi_TC;
                        var monTinChi = lopTinChi.PLAN_MonTinChi_TC;
                        string Ten_mon = monTinChi.MARK_MonHoc.Ten_mon;
                        string Ky_hieu_lop_tc = monTinChi.Ky_hieu_lop_tc;
                        int STT_lop = lopTinChi.STT_lop;
                        string Ky_hieu = monTinChi.MARK_MonHoc.Ky_hieu;
                        string Ten_lop_tc = "";
                        if (lopTinChi.ID_lop_lt == 0)
                        {
                            Ten_lop_tc = String.Format("{0}{1} (N{2:00})", Ten_mon, Ky_hieu_lop_tc.Substring(Ky_hieu.Length), STT_lop);
                        }
                        var listSuKienTinChi = new List<SuKienTinChi>();

                        string Giang_vien = "";
                        if (lopTinChi.ID_cb != 0)
                            Giang_vien = lopTinChi.PLAN_GiaoVien.Ho_ten;

                        dicLopTinChi.Add(sukienTinChi.ID_lop_tc, new StudentPortal.ViewModels.LopTinChiViewModel
                        {
                            ID_lop_lt = lopTinChi.ID_lop_lt,
                            ID_lop_tc = sukienTinChi.ID_lop_tc,
                            Ten_lop_tc = Ten_lop_tc,
                            SuKienTinChi = listSuKienTinChi,
                            STT_lop = lopTinChi.STT_lop,
                            So_sv_max = lopTinChi.So_sv_max,
                            Ma_mon = Ky_hieu,
                            Chi_tiet = "",
                            Giang_vien = Giang_vien,
                            So_tin_chi = monTinChi.So_tin_chi,
                            He_so = monTinChi.He_so,
                            Co_lop_TH = false,
                            Cho_trong = lopTinChi.Cho_trong,
                            Da_dang_ky = lopTinChi.So_sv_max - (lopTinChi.Cho_trong == null ? 0 : (int)lopTinChi.Cho_trong)
                        });
                    }
                    var Chi_tiet = "";
                    if (sukienTinChi.Tu_ngay != null && sukienTinChi.Den_ngay != null)
                    {
                        Chi_tiet = string.Format("Từ {0} đến {1}", ((DateTime)sukienTinChi.Tu_ngay).ToString("dd/MM/yyyy"), ((DateTime)sukienTinChi.Den_ngay).ToString("dd/MM/yyyy"));
                    }

                    if (sukienTinChi.Thu > -1)
                    {
                        Chi_tiet = String.Format("{0}, {1}", Chi_tiet, ThoiGian.getThu(sukienTinChi.Thu));
                    }

                    if (sukienTinChi.Tiet > -1)
                    {
                        Chi_tiet = String.Format("{0}, tiết {1} đến {2}", Chi_tiet, sukienTinChi.Tiet + 1, sukienTinChi.Tiet + 1 + sukienTinChi.So_tiet);
                    }

                    if (sukienTinChi.ID_phong > 0)
                    {
                        var phongHoc = sukienTinChi.PLAN_PhongHoc;
                        //Chi_tiet += "\n";
                        try
                        {
                            int So_phong = int.Parse(phongHoc.So_phong);
                            Chi_tiet = String.Format("{0} Phòng {1}", Chi_tiet, So_phong);
                        }
                        catch (Exception)
                        {
                            Chi_tiet = String.Format("{0} Phòng {1}", Chi_tiet, phongHoc.So_phong);
                        }
                        if (phongHoc.ID_tang > 0)
                        {
                            Chi_tiet = String.Format("{0}, tầng {1}", Chi_tiet, phongHoc.PLAN_TANG.Ten_tang);
                        }
                        if (phongHoc.ID_nha > 0)
                        {
                            Chi_tiet = String.Format("{0}, Nhà {1}", Chi_tiet, phongHoc.PLAN_TOANHA.Ten_nha);
                        }
                        Chi_tiet += ".";
                    }
                    dicLopTinChi[sukienTinChi.ID_lop_tc].SuKienTinChi.Add(new SuKienTinChi()
                    {
                        Tu_ngay = sukienTinChi.Tu_ngay,
                        Den_ngay = sukienTinChi.Den_ngay,
                        Thu = sukienTinChi.Thu,
                        So_tiet = sukienTinChi.So_tiet,
                        Tiet = sukienTinChi.Tiet,
                        Chi_tiet = Chi_tiet,
                    });

                    dicLopTinChi[sukienTinChi.ID_lop_tc].Chi_tiet += Chi_tiet;
                }
                else
                    dicLopTinChi[sukienTinChi.ID_lop_tc] = _cacheDicLopTC[sukienTinChi.ID_lop_tc];
            }

            foreach (var lopTinChi in dicLopTinChi.Values)
            {
                if (_cacheDicLopTC.ContainsKey(lopTinChi.ID_lop_tc))
                    continue;
                if (lopTinChi.ID_lop_lt != 0 && dicLopTinChi.ContainsKey(lopTinChi.ID_lop_lt))
                {
                    var lopLT = dicLopTinChi[lopTinChi.ID_lop_lt];
                    dicLopTinChi[lopTinChi.ID_lop_tc].Ten_lop_tc = String.Format("{0}.TH{1:00}", lopLT.Ten_lop_tc, lopTinChi.STT_lop);
                    dicLopTinChi[lopTinChi.ID_lop_tc].ID_lop_lt = lopTinChi.ID_lop_lt;
                    dicLopTinChi[lopTinChi.ID_lop_lt].Co_lop_TH = true;
                }
                _cacheDicLopTC[lopTinChi.ID_lop_tc] = dicLopTinChi[lopTinChi.ID_lop_tc];
            }

            return dicLopTinChi;
        }
        public static StudentPortal.ViewModels.LopTinChiViewModel getDetails(int ID_lop_tc, bool Rut_bot_hoc_phan = false, bool Huy_dang_ky = false)
        {
            DHHHContext db = new DHHHContext();
            StudentPortal.ViewModels.LopTinChiViewModel result;
            var lopTC = db.PLAN_LopTinChi_TC.Single(t => t.ID_lop_tc == ID_lop_tc);

            var sukienTinChis = db.PLAN_SukiensTinChi_TC.Where(t => t.ID_lop_tc == ID_lop_tc).ToList();
            if (lopTC.ID_lop_lt != 0)
                sukienTinChis.AddRange(db.PLAN_SukiensTinChi_TC.Where(t => t.ID_lop_tc == lopTC.ID_lop_lt).ToList());
            var dicLopTinChi = getListDetails(sukienTinChis);
            if (dicLopTinChi.Values.Count > 0)
                result = dicLopTinChi.Values.ToList()[0];
            else
                result = getDetail(ID_lop_tc, db);
            result.Huy_dang_ky = Huy_dang_ky;
            result.Rut_bot_hoc_phan = Rut_bot_hoc_phan;
            return result;
        }
        public static LopTinChiViewModel getDetail(int ID_lop_tc, DHHHContext db)
        {
            var lopDetail = db.PLAN_LopTinChi_TC.Where(t => t.ID_lop_tc == ID_lop_tc).ToList().Select(t => new LopTinChiViewModel
            {
                Ten_lop_tc = String.Format("{0}{1} (N{2:00})", t.PLAN_MonTinChi_TC.MARK_MonHoc.Ten_mon, t.PLAN_MonTinChi_TC.Ky_hieu_lop_tc.Substring(t.PLAN_MonTinChi_TC.MARK_MonHoc.Ky_hieu.Length), t.STT_lop),
                ID_lop_lt = t.ID_lop_lt,
                ID_lop_tc = t.ID_lop_tc,
                SuKienTinChi = new List<SuKienTinChi>(),
                STT_lop = t.STT_lop,
                So_sv_max = t.So_sv_max,
                Ma_mon = t.PLAN_MonTinChi_TC.MARK_MonHoc.Ky_hieu,
                Chi_tiet = "",
                Giang_vien = t.ID_cb != 0 ? t.PLAN_GiaoVien.Ho_ten : null,
                So_tin_chi = t.PLAN_MonTinChi_TC.So_tin_chi,
                He_so = t.PLAN_MonTinChi_TC.He_so,
                Co_lop_TH = false,
                Cho_trong = t.Cho_trong,
                Da_dang_ky = t.Cho_trong == null ? 0 : t.So_sv_max - (int)t.Cho_trong,

            }).ToList()[0];
            if (lopDetail.ID_lop_lt != 0)
            {
                var lopLT = getDetail(lopDetail.ID_lop_lt, db);
                lopDetail.Ten_lop_tc = String.Format("{0}.TH{1:00}", lopLT.Ten_lop_tc, lopDetail.STT_lop);
            }
            return lopDetail;
        }
    }
}