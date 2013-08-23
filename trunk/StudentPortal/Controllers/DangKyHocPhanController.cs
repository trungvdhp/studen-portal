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
        #endregion

        public ActionResult getKhoaHoc()
        {
            var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            var sinhVien = SinhVien.getSinhVien(userProfile);
            JsonResult result = new JsonResult();
            result.Data = new SelectList(ChuongTrinhDaoTao.getKhoaHoc(sinhVien.STU_Lop.ID_he, sinhVien.STU_Lop.ID_khoa),"","");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult getNganh(int Khoa_hoc)
        {
            var userProfile = StudentPortal.Lib.User.getUserProfile(WebSecurity.CurrentUserId);
            var sinhVien = SinhVien.getSinhVien(userProfile);
            JsonResult result = new JsonResult();
            result.Data = new SelectList(ChuongTrinhDaoTao.getNganh(sinhVien.STU_Lop.ID_he, sinhVien.STU_Lop.ID_khoa,Khoa_hoc).Select(t=>new{
                ID_dt = t.ID_dt,
                Chuyen_nganh = t.STU_ChuyenNganh.Chuyen_nganh,
            }).ToList(),"ID_dt","Chuyen_nganh");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult getMonHoc(int ID_dt)
        {
            
            JsonResult result = new JsonResult();
            result.Data = new SelectList(ChuongTrinhDaoTao.getMonHoc(ID_dt),"ID_mon","Ten_mon");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }
}
