using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


namespace StudentPortal.Areas.Admin.Controllers
{
    public class HoSoNopController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/HoSoNop/

        //[Authorize(Roles="HoSoNop.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/HoSoNop//Read

        //[Authorize(Roles="HoSoNop.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var stu_hosonop = db.STU_HoSoNop.Include(s => s.STU_LoaiGiayTo);
            return Json(stu_hosonop.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/HoSoNop/Details/5

        //[Authorize(Roles="HoSoNop.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_HoSoNop stu_hosonop = db.STU_HoSoNop.Find(id);
            if (stu_hosonop == null)
            {
                return HttpNotFound();
            }
            return View(stu_hosonop);
        }

        //
        // GET: /Admin/HoSoNop/Create

        //[Authorize(Roles="HoSoNop.Create")]
        public ActionResult Create()
        {
            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to");
            return View();
        }

        //
        // POST: /Admin/HoSoNop/Create

        [HttpPost]
        //[Authorize(Roles="HoSoNop.Create")]
        public ActionResult Create(STU_HoSoNop stu_hosonop)
        {
            if (ModelState.IsValid)
            {
                db.STU_HoSoNop.Add(stu_hosonop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to", stu_hosonop.ID_giay_to);
            return View(stu_hosonop);
        }

        //
        // GET: /Admin/HoSoNop/Edit/5
        //[Authorize(Roles="HoSoNop.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_HoSoNop stu_hosonop = db.STU_HoSoNop.Find(id);
            if (stu_hosonop == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to", stu_hosonop.ID_giay_to);
            return View(stu_hosonop);
        }

        //
        // POST: /Admin/HoSoNop/Edit/5

        [HttpPost]
        //[Authorize(Roles="HoSoNop.Edit")]
        public ActionResult Edit(STU_HoSoNop stu_hosonop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_hosonop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_giay_to = new SelectList(db.STU_LoaiGiayTo, "ID_giay_to", "Ma_giay_to", stu_hosonop.ID_giay_to);
            return View(stu_hosonop);
        }

        //
        // GET: /Admin/HoSoNop/Delete/5

        //[Authorize(Roles="HoSoNop.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_HoSoNop stu_hosonop = db.STU_HoSoNop.Find(id);
            if (stu_hosonop == null)
            {
                return HttpNotFound();
            }
            return View(stu_hosonop);
        }

        //
        // POST: /Admin/HoSoNop/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="HoSoNop.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_HoSoNop stu_hosonop = db.STU_HoSoNop.Find(id);
            db.STU_HoSoNop.Remove(stu_hosonop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}