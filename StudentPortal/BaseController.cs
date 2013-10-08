using System;
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
    [Authorize]
    public class BaseController : Controller
    {
        private PLAN_HocKyDangKy_TC _HocKyDangKy;
        private UserProfile _userProfile;
        private Dictionary<int, STU_DanhSach> _sinhVien;
        private PLAN_QUYDINH_DANGKY _quydinhDK;
        private Dictionary<int, List<DiemHocTap>> _diemHocTap = new Dictionary<int, List<DiemHocTap>>();
        private Dictionary<int, List<DiemHocTap>> _bangdiem = new Dictionary<int, List<DiemHocTap>>();
        private Dictionary<int, HocKy> _hocKyTruoc = new Dictionary<int, HocKy>();
        private bool _hetHanDK;
        private Dictionary<string, List<MARK_MonHoc>> _dicMonDangKy = new Dictionary<string, List<MARK_MonHoc>>();
        private int _iD_sv = 0;
        private List<ChuyenNganh> _chuyenNganh;

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
                    _sinhVien = SinhVien.GetSinhVien(userProfile).ToDictionary(t => t.STU_Lop.ID_dt, t => t);
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
                _diemHocTap[ID_dt] = SinhVien.GetDiemHocTap(this.ID_sv, ID_dt);
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

            if (!_hocKyTruoc.ContainsKey(ID_dt))
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
        protected List<MARK_MonHoc> getMonDangKy(KieuDangKy KieuDK, int ID_dt)
        {
            string key = KieuDK + "_" + ID_dt;
            if (!_dicMonDangKy.ContainsKey(key))
            {
                _dicMonDangKy[key] = DangKyHocPhan.getMonDangKy(sinhVien[ID_dt],KieuDK,ID_dt);
            }
            return _dicMonDangKy[key];
        }
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
        protected int ID_sv
        {
            get
            {
                if (_iD_sv == 0)
                    _iD_sv = sinhVien.Values.First().ID_sv;
                return _iD_sv;
            }
        }
        public BaseController()
        {
            itemsPerPage = Properties.Settings.Default.items_per_page;
            DHHHContext db = new DHHHContext();

            if (WebSecurity.IsAuthenticated)
            {
                string strUserGroups = CauHinh.get("User_Groups").ToString();
                string[] buf = strUserGroups.Split(new char[] { ',' });
                var groupIDs = new List<int>();
                foreach (string e in buf)
                {
                    int groupID = Convert.ToInt32(e);
                    groupIDs.Add(groupID);
                }
                if (!groupIDs.Contains(userProfile.GroupId))
                {
                    var groupRoles = db.webpages_Groups_Roles.Where(t => t.GroupId == userProfile.GroupId).Select(t => t.webpages_Roles.RoleName).ToList();
                    var userRoles = Roles.GetRolesForUser(userProfile.UserName);
                    var addRoles = new List<string>();
                    foreach (var role in groupRoles)
                    {
                        if (!userRoles.Contains(role))
                            Roles.AddUserToRole(userProfile.UserName, role);
                    }
                    var removeRoles = new List<string>();
                    foreach (var role in userRoles)
                    {
                        if (!groupRoles.Contains(role))
                            Roles.RemoveUserFromRole(userProfile.UserName, role);
                    }
                    
                }
            }
        }
    }
}