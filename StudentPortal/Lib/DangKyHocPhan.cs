using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using StudentPortal.ViewModels;


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

        public static List<LopTinChi> getLopTinChi(int ID_mon)
        {
            DHHHContext db = new DHHHContext();

            var sukienTinChis = db.PLAN_SukiensTinChi_TC.Where(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.ID_mon == ID_mon).ToList();

            var dicLopTinChi = new Dictionary<int, LopTinChi>();

            foreach (var sukienTinChi in sukienTinChis)
            {
                if (!dicLopTinChi.ContainsKey(sukienTinChi.ID_lop_tc))
                {
                    var lopTinChi = sukienTinChi.PLAN_LopTinChi_TC;
                    string Ten_mon = lopTinChi.PLAN_MonTinChi_TC.MARK_MonHoc.Ten_mon;
                    string Ky_hieu_lop_tc = lopTinChi.PLAN_MonTinChi_TC.Ky_hieu_lop_tc;
                    int STT_lop = lopTinChi.STT_lop;
                    string Ky_hieu = lopTinChi.PLAN_MonTinChi_TC.MARK_MonHoc.Ky_hieu;
                    string Ten_lop_tc = "";
                    if (lopTinChi.ID_lop_lt == 0)
                    {
                        Ten_lop_tc = String.Format("{0}{1} (N{2:00})", Ten_mon, Ky_hieu_lop_tc.Substring(Ky_hieu.Length), STT_lop);
                    }
                    var listSuKienTinChi = new List<SuKienTinChi>();

                    dicLopTinChi.Add(sukienTinChi.ID_lop_tc, new LopTinChi
                    {
                        ID_lop_lt = lopTinChi.ID_lop_lt,
                        ID_lop_tc = sukienTinChi.ID_lop_tc,
                        Ten_lop_tc = Ten_lop_tc,
                        SuKienTinChi = listSuKienTinChi,
                        STT_lop = lopTinChi.STT_lop,
                        Si_so = lopTinChi.So_sv_max,
                        Ma_mon = Ky_hieu,
                        Chi_tiet = "",
                    });
                }
                var Chi_tiet = string.Format("Từ {0} đến {1}", sukienTinChi.Tu_ngay.ToString("dd/MM/yyyy"), sukienTinChi.Den_ngay.ToString("dd/MM/yyyy"));

                if (sukienTinChi.Thu > -1)
                {
                    Chi_tiet = String.Format("{0}, {1}",Chi_tiet,ThoiGian.getThu(sukienTinChi.Thu));
                }

                if (sukienTinChi.Tiet > -1)
                {
                    Chi_tiet = String.Format("{0}, tiết {1} đến {2}", Chi_tiet, sukienTinChi.Tiet + 1, sukienTinChi.Tiet + 1+sukienTinChi.So_tiet);
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

            foreach (var lopTinChi in dicLopTinChi.Values)
            {
                if (lopTinChi.ID_lop_lt != 0 && dicLopTinChi.ContainsKey(lopTinChi.ID_lop_lt))
                {
                    var lopLT = dicLopTinChi[lopTinChi.ID_lop_lt];
                    dicLopTinChi[lopTinChi.ID_lop_tc].Ten_lop_tc = String.Format("{0}.TH{1:00}", lopLT.Ten_lop_tc, lopTinChi.STT_lop);
                }
            }

            return dicLopTinChi.Values.ToList();
        }

    }
}