using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class ChuongTrinhDTController : BaseController
    {

        public ActionResult getHeDaoTao()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.STU_He.ToList(), "ID_he", "Ten_he");
            return result;
        }

        public ActionResult getChuyenNganh(int ID_he)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new SelectList(db.PLAN_ChuongTrinhDaoTao.Where(t => t.ID_he == ID_he).Select(t => new
            {
                ID_chuyen_nganh = t.ID_chuyen_nganh,
                Chuyen_nganh = t.STU_ChuyenNganh.Chuyen_nganh,
            }).Distinct().OrderBy(t => t.Chuyen_nganh).ToList(), "ID_chuyen_nganh", "Chuyen_nganh");
            return result;
        }
    }
}
