using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using StudentPortal.ViewModels;


namespace StudentPortal.Lib
{
    public class GiaiDoan
    {
        public DateTime? TuNgay;
        public DateTime? DenNgay;
        public GiaiDoan()
        {
            TuNgay = null;
            DenNgay = null;
        }
    }
    public class DangKyHocPhan
    {


        public static List<PLAN_QUYDINH_DANGKY> GetQuyDinhDangKy(STU_DanhSach sinhVien)
        {
            DHHHContext db = new DHHHContext();
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

        public static List<StudentPortal.ViewModels.LopTinChiViewModel> getLopTinChi(int? ID_mon)
        {
            DHHHContext db = new DHHHContext();

            var sukienTinChis = db.PLAN_SukiensTinChi_TC.Where(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.ID_mon == ID_mon).ToList();

            var dicLopTinChi = LopTinChi.getListDetails(sukienTinChis);

            return dicLopTinChi.Values.ToList();
        }

        public static List<GiaiDoan> getGiaiDoan(List<GiaiDoan> giaidoans)
        {
            var set = new HashSet<DateTime?>();
            var check = new List<int>();
            var result = new List<GiaiDoan>();
            for(int i=0;i<giaidoans.Count;i++)
            {
                check.Add(0);
                set.Add(giaidoans[i].TuNgay);
                set.Add(giaidoans[i].DenNgay);
            }
            GiaiDoan giaidoanTmp = new GiaiDoan();
            foreach (var ngay in set)
            {
                int countGiaidoanMo=0;
                for (int i = 0; i < giaidoans.Count; i++)
                {
                    if (check[i] == 0 && giaidoans[i].TuNgay == ngay)
                    {
                        check[i] = 1;
                        
                        if (giaidoanTmp.TuNgay == null)
                            giaidoanTmp.TuNgay = ngay;
                        else
                            giaidoanTmp.DenNgay = ngay;
                    }
                    else if (check[i] == 1)
                    {
                        countGiaidoanMo++;
                        if (giaidoans[i].DenNgay == ngay)
                        {
                            check[i] = 2;
                            giaidoanTmp.DenNgay = ngay;
                        }
                    }
                }
                if (countGiaidoanMo>0 && giaidoanTmp.TuNgay != null && giaidoanTmp.DenNgay != null)
                {
                    result.Add(giaidoanTmp);
                    giaidoanTmp = new GiaiDoan();
                }
                    
            }

            
            return result;
        }

        //public static List<MARK_MonHoc> getMonDangKy(STU_DanhSach sinhVien, string KieuDK, int ID_dt)
        //{
        //    DHHHContext db = new DHHHContext();
        //    var monDK = new List<MARK_MonHoc>();
        //    var chuongtrinhDaotao = db.PLAN_ChuongTrinhDaoTao.Single(t =>
        //        t.ID_dt == ID_dt
        //       );
        //    if (chuongtrinhDaotao != null)
        //    {
        //        var monChuongTrinhKhung = ChuongTrinhDaoTao.getMonHoc(chuongtrinhDaotao.ID_dt);
        //        var idMonChuongTrinhKhung = monChuongTrinhKhung.Select(t => t.ID_mon).ToList();
        //        var quydinhDangkys = DangKyHocPhan.GetQuyDinhDangKy();

        //        if (quydinhDangkys.Count > 0)
        //        {
        //            var hockyDangky = quydinhDangkys[0];


        //            var monDangMo = db.PLAN_SukiensTinChi_TC
        //                .Where(t => t.Ky_dang_ky == hockyDangky.Ky_dang_ky)
        //                .Select(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.MARK_MonHoc)
        //                .Distinct()
        //                .ToList();


        //            List<MARK_MonHoc> monDuocDK = new List<MARK_MonHoc>();

        //            foreach (var mon in monDangMo)
        //            {
        //                if (idMonChuongTrinhKhung.Contains(mon.ID_mon))
        //                    monDuocDK.Add(mon);
        //            }
                    
        //            var bangdiem = SinhVien.GetBangDiem(sinhVien.ID_sv);
        //            var dicBangdiem = bangdiem.ToDictionary(t => t.ID_mon, t => t.Z);
        //            var monRangBuoc = db.PLAN_ChuongTrinhDaoTaoRangBuoc.Where(t => t.ID_dt == chuongtrinhDaotao.ID_dt).ToList();
        //            var dicMonRangBuoc = monRangBuoc.ToDictionary(t => t.ID_mon, t => t);
        //            switch (KieuDK)
        //            {
        //                case "tien_do":
        //                    foreach (var mon in monDuocDK)
        //                    {
        //                        if (!dicBangdiem.ContainsKey(mon.ID_mon) &&
        //                                (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
        //                                    (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
        //                                        (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
        //                                            bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
        //                                        )
        //                                    )
        //                                )
        //                            )
        //                        {
        //                            monDK.Add(mon);
        //                        }
        //                    }
        //                    break;
        //                case "cai_thien":
        //                    foreach (var mon in monDuocDK)
        //                    {
        //                        if (dicBangdiem.ContainsKey(mon.ID_mon) && dicBangdiem[mon.ID_mon] <= SinhVien.DiemHe4["C+"] &&
        //                            (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
        //                                    (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
        //                                        (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
        //                                            bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
        //                                        )
        //                                    )
        //                                )
        //                            )
        //                            monDK.Add(mon);
        //                    }
        //                    break;
        //                case "hoc_lai":
        //                    foreach (var mon in monDuocDK)
        //                    {
        //                        if (dicBangdiem.ContainsKey(mon.ID_mon) && dicBangdiem[mon.ID_mon] < SinhVien.DiemHe4["D"] &&
        //                            (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
        //                                    (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
        //                                        (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
        //                                            bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
        //                                        )
        //                                    )
        //                                )
        //                            )
        //                            monDK.Add(mon);
        //                    }
        //                    break;
        //                default:
        //                    foreach (var mon in monDuocDK)
        //                    {
        //                        if ((dicBangdiem.ContainsKey(mon.ID_mon) && dicBangdiem[mon.ID_mon] < SinhVien.DiemHe4["D"] &&
        //                            (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
        //                                    (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
        //                                        (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
        //                                            bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
        //                                        )
        //                                    )
        //                                )
        //                            ) || (!dicBangdiem.ContainsKey(mon.ID_mon) &&
        //                                (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
        //                                    (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
        //                                        (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
        //                                            bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
        //                                        )
        //                                    )
        //                                )
        //                            ) || (dicBangdiem.ContainsKey(mon.ID_mon) && dicBangdiem[mon.ID_mon] <= SinhVien.DiemHe4["C+"] &&
        //                            (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
        //                                    (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
        //                                        (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
        //                                            bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
        //                                        )
        //                                    )
        //                                )
        //                            ))

        //                            monDK.Add(mon);
        //                    }
        //                    break;
        //            }
                    
        //        }
        //    }
        //    return monDK;
        //}
    }
}