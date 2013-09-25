﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using StudentPortal.Models;
using StudentPortal.Lib;

using StudentPortal.ViewModels;
using StudentPortal.Filters;

namespace StudentPortal
{
    [InitializeSimpleMembership]
    public class BaseController : Controller
    {
        private PLAN_HocKyDangKy_TC _HocKyDangKy;
        private UserProfile _userProfile;
        private Dictionary<int,STU_DanhSach> _sinhVien;
        private PLAN_QUYDINH_DANGKY _quydinhDK;
        private Dictionary<int,List<DiemHocTap>> _diemHocTap = new Dictionary<int,List<DiemHocTap>>();
        private Dictionary<int,List<DiemHocTap> >_bangdiem = new Dictionary<int,List<DiemHocTap>>();
        private Dictionary<int, HocKy> _hocKyTruoc = new Dictionary<int,HocKy>();
        private bool _hetHanDK;
        private Dictionary<string, List<PLAN_MonTinChi_TC>> _dicMonDangKy = new Dictionary<string, List<PLAN_MonTinChi_TC>>();

        protected int itemsPerPage;
        protected DHHHContext db = new DHHHContext();
        protected UserProfile userProfile
        {
            get
            {
                if (_userProfile == null && WebSecurity.IsAuthenticated)
                {
                    _userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
                }
                return _userProfile;
            }
        }
        protected Dictionary<int, STU_DanhSach> sinhVien
        {
            get
            {
                if (_sinhVien == null && userProfile != null)
                {
                    _sinhVien = SinhVien.GetSinhVien(userProfile).ToDictionary(t=>t.STU_Lop.ID_dt,t=>t)  ;
                }
                return _sinhVien;
            }
        }
        protected PLAN_HocKyDangKy_TC HocKyDangKy
        {
            get
            {
                if (_HocKyDangKy == null)
                {
                    var db = new DHHHContext();
                    _HocKyDangKy = db.PLAN_HocKyDangKy_TC.Single(t => t.Chon_dang_ky == true);
                }
                return _HocKyDangKy;
            }
        }
        protected PLAN_QUYDINH_DANGKY QuyDinhDK
        {
            get
            {
                if (_quydinhDK == null)
                {
                    _quydinhDK = db.PLAN_QUYDINH_DANGKY.Single(t => t.Ky_dang_ky == this.HocKyDangKy.Ky_dang_ky);
                }
                return _quydinhDK;
            }
        }
        protected bool HetHanDK
        {
            get
            {
                if (_hetHanDK == null)
                {
                    _hetHanDK = QuyDinhDK.Tu_ngay <= DateTime.Now && QuyDinhDK.Den_ngay >= DateTime.Now.Date;
                }
                return _hetHanDK;
            }
        }
        protected List<DiemHocTap> getDiemHocTap(int ID_dt)
        {
            
                if (!_diemHocTap.ContainsKey(ID_dt))
                    _diemHocTap[ID_dt]= SinhVien.GetDiemHocTap(sinhVien[ID_dt].ID_sv,ID_dt);
                return _diemHocTap[ID_dt];
            
        }
        protected List<DiemHocTap> getBangDiem(int ID_dt)
        {
                if (!_bangdiem.ContainsKey(ID_dt))
                {
                    var diems = this.getDiemHocTap(ID_dt);
                    Dictionary<int, DiemHocTap> bangdiem = new Dictionary<int, DiemHocTap>();
                    foreach (var diem in diems)
                    {
                        if (!bangdiem.ContainsKey(diem.ID_mon))
                            bangdiem[diem.ID_mon] = diem;
                        else if (diem.Z > bangdiem[diem.ID_mon].Z)
                            bangdiem[diem.ID_mon] = diem;
                    }
                    _bangdiem[ID_dt] = bangdiem.Values.ToList();
                }
                return _bangdiem[ID_dt];
         
        }
        protected HocKy getHocKyTruoc(int ID_dt)
        {
            
                if (_hocKyTruoc.ContainsKey(ID_dt))
                {
                    var hocky = this.getDiemHocTap(ID_dt).Select(t => new HocKy
                    {
                        Hoc_ky = t.Hoc_ky,
                        Nam_hoc = t.Nam_hoc,
                    }).Distinct().OrderByDescending(t => t.Nam_hoc).ThenByDescending(t => t.Hoc_ky).ToList();
                    _hocKyTruoc[ID_dt] = hocky.First();
                }
                return _hocKyTruoc[ID_dt];
        }
        

        protected List<PLAN_MonTinChi_TC> getMonDangKy(string KieuDK, int ID_dt)
        {
            if (!_dicMonDangKy.ContainsKey(KieuDK + ID_dt))
            {
                var monDK = new List<PLAN_MonTinChi_TC>();
                var chuongtrinhDaotao = db.PLAN_ChuongTrinhDaoTao.Single(t =>
                    t.ID_dt == ID_dt
                   );
                if (chuongtrinhDaotao != null)
                {
                    var monChuongTrinhKhung = ChuongTrinhDaoTao.getMonHoc(chuongtrinhDaotao.ID_dt);
                    var idMonChuongTrinhKhung = monChuongTrinhKhung.Select(t => t.ID_mon).ToList();
                    var quydinhDangkys = DangKyHocPhan.GetQuyDinhDangKy(sinhVien[ID_dt]);

                    if (quydinhDangkys.Count > 0)
                    {
                        var hockyDangky = quydinhDangkys[0];


                        var monDangMo = db.PLAN_SukiensTinChi_TC
                            .Where(t => t.Ky_dang_ky == hockyDangky.Ky_dang_ky)
                            .Select(t => t.PLAN_LopTinChi_TC.PLAN_MonTinChi_TC)
                            .Distinct()
                            .ToList();
                        var lopHC = sinhVien[ID_dt].STU_Lop;
                        var phamviDKs = db.PLAN_PhamViDangKy_TC
                            .Where(t => t.ID_he == 0 || t.ID_he == lopHC.ID_he)
                            .Where(t => t.ID_khoa == 0 || t.ID_khoa == lopHC.ID_khoa)
                            .Where(t => t.ID_nganh == 0 || t.ID_nganh == lopHC.STU_ChuyenNganh.ID_nganh)
                            .Where(t => t.ID_chuyen_nganh == lopHC.ID_chuyen_nganh || t.ID_chuyen_nganh == 0)
                            .Where(t => t.Khoa_hoc == lopHC.Khoa_hoc || t.Khoa_hoc == 0)
                            .ToList();
                        var monTrongPhamViDKs = phamviDKs.Select(t => t.ID_mon_tc).ToList();

                        List<PLAN_MonTinChi_TC> monDuocDK = new List<PLAN_MonTinChi_TC>();

                        foreach (var mon in monDangMo)
                        {
                            if (idMonChuongTrinhKhung.Contains(mon.ID_mon) && monTrongPhamViDKs.Contains(mon.ID_mon_tc))
                                monDuocDK.Add(mon);
                        }

                        var bangdiem = this.getBangDiem(ID_dt);
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
                            case "cai_thien":
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
                            case "hoc_lai":
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
                _dicMonDangKy[KieuDK + ID_dt] = monDK;
            }
            return _dicMonDangKy[KieuDK + ID_dt];
        }

        private List<ChuyenNganh> _chuyenNganh;
        protected List<ChuyenNganh> ChuyenNganh
        {
            get
            {
                if (_chuyenNganh == null)
                {
                    _chuyenNganh = SinhVien.getChuyenNganh(sinhVien.Values.First().ID_sv);
                }
                return _chuyenNganh;
            }
        }
        public BaseController()
        {
            itemsPerPage = Properties.Settings.Default.items_per_page;
            DHHHContext db = new DHHHContext();

            if (WebSecurity.IsAuthenticated)
            {

            }
        }
    }
}