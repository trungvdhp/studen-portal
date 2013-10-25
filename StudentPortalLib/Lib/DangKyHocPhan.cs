using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using WebMatrix.WebData;
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

        public static List<StudentPortal.ViewModels.LopTinChiViewModel> getLopTinChi(int? ID_mon, int Ky_dang_ky,bool Co_SKTC = true)
        {
            DHHHContext db = new DHHHContext();
            if (Co_SKTC)
            {
                var sukienTinChis = db.PLAN_SukiensTinChi_TC.Where(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.ID_mon == ID_mon && t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky == Ky_dang_ky).ToList();

                var dicLopTinChi = LopTinChi.getListDetails(sukienTinChis);

                return dicLopTinChi.Values.ToList();
            }
            var lopTCs = db.PLAN_LopTinChi_TC.Where(t => t.PLAN_MonTinChi_TC.ID_mon == ID_mon && t.PLAN_MonTinChi_TC.Ky_dang_ky == Ky_dang_ky).Select(t => t.ID_lop_tc).ToList();
            List<LopTinChiViewModel> result = new List<LopTinChiViewModel>();
            foreach (var ID_lop_tc in lopTCs)
            {
                result.Add(LopTinChi.getDetail(ID_lop_tc, db));
            }
            return result;
        }

        public static List<GiaiDoan> getGiaiDoan(List<GiaiDoan> giaidoans)
        {
            var set = new HashSet<DateTime?>();
            var check = new List<int>();
            var result = new List<GiaiDoan>();
            for (int i = 0; i < giaidoans.Count; i++)
            {
                check.Add(0);
                set.Add(giaidoans[i].TuNgay);
                set.Add(giaidoans[i].DenNgay);
            }
            GiaiDoan giaidoanTmp = new GiaiDoan();
            foreach (var ngay in set)
            {
                int countGiaidoanMo = 0;
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
                if (countGiaidoanMo > 0 && giaidoanTmp.TuNgay != null && giaidoanTmp.DenNgay != null)
                {
                    result.Add(giaidoanTmp);
                    giaidoanTmp = new GiaiDoan();
                }

            }


            return result;
        }

        public static void KiemTraDieuKienDangKy(ref DHHHContext db, int ID_sv, int ID_lop_tc, int ID_dt, PLAN_HocKyDangKy_TC HocKyDangKy)
        {
            var lopDKs = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv && t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky == HocKyDangKy.Ky_dang_ky).Select(t => t.PLAN_LopTinChi_TC).ToList();
            var idLopDKs = lopDKs.Select(t => t.ID_lop_tc).ToList();

            var hockyTruoc = SinhVien.GetHocKyTruoc(ID_sv, ID_dt);
            
            // Lịch của lớp đang đăng ký
            var skLopTCs = db.PLAN_SukiensTinChi_TC.Where(t => t.ID_lop_tc == ID_lop_tc).ToList();
            var lopTC = skLopTCs.First().PLAN_LopTinChi_TC;
            
            var ID_mon_tc = skLopTCs.First().PLAN_LopTinChi_TC.ID_mon_tc;

            // Kiem tra gioi han sinh vien lop TC

            if (lopTC.Cho_trong <1)
            {
                throw new Exception(String.Format("Bạn không thể đăng ký vì lớp đã quá giới hạn số sinh viên đăng ký!", (int)CauHinh.get("So_TC_max")));
            }

            // Kiem tra so tin chi 
            var xetLenLop = db.Mark_XetLenLop.Where(t => t.ID_sv == ID_sv && t.Hoc_ky == hockyTruoc.Hoc_ky && t.Nam_hoc == t.Nam_hoc);
            if (xetLenLop.Count() != 0)
            {
                var dkLenLop = xetLenLop.First();
                if (dkLenLop.Lan_canh_bao == 0)
                {
                    // Kiem tra so tin chi max ky phu
                    if (HocKyDangKy.Ky_phu && lopDKs.Sum(t => t.PLAN_MonTinChi_TC.So_tin_chi) > (int)CauHinh.get("So_TC_ky_phu"))
                    {
                        throw new Exception(String.Format("Bạn không thể đăng ký quá {0} tín chỉ!", (int)CauHinh.get("So_TC_ky_phu")));
                    }
                        // Kiem tra so tin chi max ky chinh
                    else if (lopDKs.Sum(t => t.PLAN_MonTinChi_TC.So_tin_chi) > (int)CauHinh.get("So_TC_max"))
                    {
                        throw new Exception(String.Format("Bạn không thể đăng ký quá {0} tín chỉ!", (int)CauHinh.get("So_TC_max")));
                    }
                }
                else
                {
                    if (lopDKs.Sum(t => t.PLAN_MonTinChi_TC.So_tin_chi) > (int)CauHinh.get("So_TC_CC_max"))
                    {
                        throw new Exception(String.Format("Bạn đang bị cảnh cáo nên không thể đăng ký quá {0} tín chỉ!", (int)CauHinh.get("So_TC_CC_max")));
                    }
                }
            }

            // Kiem tra mon hoc co nam trong danh sach mon duoc dang ky ko
            var ID_dts = SinhVien.getChuyenNganh(ID_sv).Select(t => t.ID_dt).ToList();

            if (ID_dts.Contains(ID_dt))
            {
                var IdMonDKs = getMonDangKy(db.STU_DanhSach.Single(t=>t.ID_sv ==ID_sv), KieuDangKy.TATCA, ID_dt).Select(t => t.ID_mon).ToList();
                if (!IdMonDKs.Contains(lopTC.PLAN_MonTinChi_TC.ID_mon))
                {
                    throw new Exception(String.Format("Bạn đang đăng ký môn ngoài chương trình đào tạo!"));
                }
                
            }

            // Kiem tra mon da dang ky truoc do hay chua
            var idMonDangKys = db.STU_DanhSachLopTinChi.Where(t => t.ID_sv == ID_sv).Select(t => t.PLAN_LopTinChi_TC.ID_mon_tc).Distinct().ToList();
            if (idMonDangKys.Contains(ID_mon_tc))
            {
                throw new Exception(String.Format("Bạn đã đăng ký lớp cho môn học này. Để đăng ký lớp này, bạn phải hủy lớp đã có!"));
            }

            // Kiem tra mon dang ky tuong duong
            var monTuongduongs = db.PLAN_ChuongTrinhDaoTaoMonTuongDuong.Where(t => t.ID_dt == ID_dt).Select(t => new
            {
                ID_mon = t.ID_mon,
                ID_mon_tuong_duong = t.ID_mon_tuong_duong,
            }).ToDictionary(t => t.ID_mon, t => t.ID_mon_tuong_duong);

            var daDkMonTuongDuong = false;
            foreach (var idMon in idMonDangKys)
            {

                if (monTuongduongs.ContainsKey(idMon) && monTuongduongs[idMon] == lopTC.PLAN_MonTinChi_TC.ID_mon)
                {
                    daDkMonTuongDuong = true;
                    break;
                }
            }
            if (daDkMonTuongDuong)
            {
                throw new Exception(String.Format("Bạn đã đămg ký môn tương đương với môn học này rồi!"));
            }

            // Kiem tra mon da hoc tuong duong
            var monDaHoc = SinhVien.GetBangDiem(ID_sv,ID_dt).ToDictionary(t => t.ID_mon, t => t);
            foreach (var mon in monDaHoc.Values)
            {
                if (monTuongduongs.ContainsKey(mon.ID_mon) && SinhVien.DiemHe4[monDaHoc[mon.ID_mon].Diem_chu] >= SinhVien.DiemHe4["C+"])
                {
                    throw new Exception(String.Format("Bạn đã học môn tương đương của môn học này rồi!"));
                }
            }
            // Kiem tra mon rang buoc
            var monRangBuoc = db.PLAN_ChuongTrinhDaoTaoRangBuoc.Where(t => t.ID_dt == ID_dt).ToDictionary(t => t.ID_mon, t => t);
            if (monRangBuoc.ContainsKey(lopTC.PLAN_MonTinChi_TC.ID_mon))
            {
                if (monDaHoc.ContainsKey(monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].ID_mon_rb) && monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].Diem_rang_buoc > monDaHoc[monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].ID_mon_rb].Z)
                {
                    throw new Exception(String.Format("Bạn phải học môn {0} trước và có điểm đạt tối thiểu {1:1} có thể đăng ký môn này!", monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].Mon_Rang_Buoc.Ten_mon, monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].Diem_rang_buoc));
                }
                else
                {
                    throw new Exception(String.Format("Bạn phải học môn {0} trước mới có thể đăng ký môn này!", monRangBuoc[lopTC.PLAN_MonTinChi_TC.ID_mon].Mon_Rang_Buoc.Ten_mon));
                }
            }
        }
        /// <summary>
        /// Lấy danh sách các môn cần đăng ký của sinh viên
        /// </summary>
        /// <param name="sinhVien"></param>
        /// <param name="KieuDK">Kiểu đăng ký "tien_do", "cai_thien", "hoc_lai"</param>
        /// <param name="ID_dt"></param>
        /// <returns>Danh sách môn học cần đăng ký</returns>
        public static List<MARK_MonHoc> getMonDangKy(STU_DanhSach sinhVien, KieuDangKy KieuDK, int ID_dt)
        {
            DHHHContext db = new DHHHContext();
            var monDK = new List<MARK_MonHoc>();
            var chuongtrinhDaotao = db.PLAN_ChuongTrinhDaoTao.Single(t =>
                t.ID_dt == ID_dt
               );
            if (chuongtrinhDaotao != null)
            {
                var monChuongTrinhKhung = ChuongTrinhDaoTao.getMonHoc(chuongtrinhDaotao.ID_dt);
                var idMonChuongTrinhKhung = monChuongTrinhKhung.Select(t => t.ID_mon).ToList();
                var quydinhDangkys = DangKyHocPhan.GetQuyDinhDangKy(sinhVien);

                if (quydinhDangkys.Count > 0)
                {
                    var hockyDangky = quydinhDangkys[0];


                    var monDangMo = db.PLAN_SukiensTinChi_TC
                        .Where(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.Ky_dang_ky == hockyDangky.Ky_dang_ky)
                        .Select(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC.MARK_MonHoc)
                        .Distinct()
                        .ToList();


                    List<MARK_MonHoc> monDuocDK = new List<MARK_MonHoc>();

                    foreach (var mon in monDangMo)
                    {
                        if (idMonChuongTrinhKhung.Contains(mon.ID_mon))
                            monDuocDK.Add(mon);
                    }

                    var bangdiem = SinhVien.GetBangDiem(sinhVien.ID_sv,ID_dt);
                    var dicBangdiem = bangdiem.ToDictionary(t => t.ID_mon, t => t.Z);
                    var monRangBuoc = db.PLAN_ChuongTrinhDaoTaoRangBuoc.Where(t => t.ID_dt == chuongtrinhDaotao.ID_dt).ToList();
                    var dicMonRangBuoc = monRangBuoc.ToDictionary(t => t.ID_mon, t => t);
                    switch (KieuDK)
                    {
                        case KieuDangKy.TIENDO:
                            foreach (var mon in monDuocDK)
                            {
                                if (!dicBangdiem.ContainsKey(mon.ID_mon) &&
                                        (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
                                            (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
                                                (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
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
                        case KieuDangKy.CAITHIEN:
                            foreach (var mon in monDuocDK)
                            {
                                if (dicBangdiem.ContainsKey(mon.ID_mon) && dicBangdiem[mon.ID_mon] <= SinhVien.DiemHe4["C+"] &&
                                    (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
                                            (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
                                                (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
                                                    bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
                                                )
                                            )
                                        )
                                    )
                                    monDK.Add(mon);
                            }
                            break;
                        case KieuDangKy.HOCLAI:
                            foreach (var mon in monDuocDK)
                            {
                                if (dicBangdiem.ContainsKey(mon.ID_mon) && dicBangdiem[mon.ID_mon] < SinhVien.DiemHe4["D"] &&
                                    (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
                                            (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
                                                (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
                                                    bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
                                                )
                                            )
                                        )
                                    )
                                    monDK.Add(mon);
                            }
                            break;
                        default:
                            foreach (var mon in monDuocDK)
                            {
                                if ((dicBangdiem.ContainsKey(mon.ID_mon) && dicBangdiem[mon.ID_mon] < SinhVien.DiemHe4["D"] &&
                                    (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
                                            (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
                                                (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
                                                    bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
                                                )
                                            )
                                        )
                                    ) || (!dicBangdiem.ContainsKey(mon.ID_mon) &&
                                        (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
                                            (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
                                                (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
                                                    bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
                                                )
                                            )
                                        )
                                    ) || (dicBangdiem.ContainsKey(mon.ID_mon) && dicBangdiem[mon.ID_mon] <= SinhVien.DiemHe4["C+"] &&
                                    (!dicMonRangBuoc.ContainsKey(mon.ID_mon) ||
                                            (dicBangdiem.ContainsKey(dicMonRangBuoc[mon.ID_mon].ID_mon_rb) &&
                                                (dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc == 0 ||
                                                    bangdiem[dicMonRangBuoc[mon.ID_mon].ID_mon_rb].Z >= dicMonRangBuoc[mon.ID_mon].Diem_rang_buoc
                                                )
                                            )
                                        )
                                    ))

                                    monDK.Add(mon);
                            }
                            break;
                    }

                }
            }
            return monDK;
        }
    }
}