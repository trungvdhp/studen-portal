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
    public class QuocTichController : BaseController
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/QuocTich/

        //[Authorize(Roles="QuocTich.Index")]
        public ActionResult Index()
        {
			return View();
        }

		//
        // GET: /Admin/QuocTich//Read

        //[Authorize(Roles="QuocTich.Read")]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(db.STU_QuocTich.ToDataSourceResult(request));
        }

        //
        // GET: /Admin/QuocTich/Details/5

        //[Authorize(Roles="QuocTich.Details")]
        public ActionResult Details(int id = 0)
        {
            STU_QuocTich stu_quoctich = db.STU_QuocTich.Find(id);
            if (stu_quoctich == null)
            {
                return HttpNotFound();
            }
            return View(stu_quoctich);
        }

        //
        // GET: /Admin/QuocTich/Create

        //[Authorize(Roles="QuocTich.Create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/QuocTich/Create

        [HttpPost]
        //[Authorize(Roles="QuocTich.Create")]
        public ActionResult Create(STU_QuocTich stu_quoctich)
        {
            if (ModelState.IsValid)
            {
                db.STU_QuocTich.Add(stu_quoctich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_quoctich);
        }

        //
        // GET: /Admin/QuocTich/Edit/5
        //[Authorize(Roles="QuocTich.Edit")]
        public ActionResult Edit(int id = 0)
        {
            STU_QuocTich stu_quoctich = db.STU_QuocTich.Find(id);
            if (stu_quoctich == null)
            {
                return HttpNotFound();
            }
            return View(stu_quoctich);
        }

        //
        // POST: /Admin/QuocTich/Edit/5

        [HttpPost]
        //[Authorize(Roles="QuocTich.Edit")]
        public ActionResult Edit(STU_QuocTich stu_quoctich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_quoctich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_quoctich);
        }

        //
        // GET: /Admin/QuocTich/Delete/5

        //[Authorize(Roles="QuocTich.Delete")]
        public ActionResult Delete(int id = 0)
        {
            STU_QuocTich stu_quoctich = db.STU_QuocTich.Find(id);
            if (stu_quoctich == null)
            {
                return HttpNotFound();
            }
            return View(stu_quoctich);
        }

        //
        // POST: /Admin/QuocTich/Delete/5

        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles="QuocTich.DeleteConfirmed")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_QuocTich stu_quoctich = db.STU_QuocTich.Find(id);
            db.STU_QuocTich.Remove(stu_quoctich);
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