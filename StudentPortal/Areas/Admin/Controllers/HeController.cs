using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Areas.Admin.Controllers
{
    public class HeController : Controller
    {
        private DHHHContext db = new DHHHContext();

        //
        // GET: /Admin/He/

        public ActionResult Index()
        {
            return View(db.STU_He.ToList());
        }

        //
        // GET: /Admin/He/Details/5

        public ActionResult Details(int id = 0)
        {
            STU_He stu_he = db.STU_He.Find(id);
            if (stu_he == null)
            {
                return HttpNotFound();
            }
            return View(stu_he);
        }

        //
        // GET: /Admin/He/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/He/Create

        [HttpPost]
        public ActionResult Create(STU_He stu_he)
        {
            if (ModelState.IsValid)
            {
                db.STU_He.Add(stu_he);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_he);
        }

        //
        // GET: /Admin/He/Edit/5

        public ActionResult Edit(int id = 0)
        {
            STU_He stu_he = db.STU_He.Find(id);
            if (stu_he == null)
            {
                return HttpNotFound();
            }
            return View(stu_he);
        }

        //
        // POST: /Admin/He/Edit/5

        [HttpPost]
        public ActionResult Edit(STU_He stu_he)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_he).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_he);
        }

        //
        // GET: /Admin/He/Delete/5

        public ActionResult Delete(int id = 0)
        {
            STU_He stu_he = db.STU_He.Find(id);
            if (stu_he == null)
            {
                return HttpNotFound();
            }
            return View(stu_he);
        }

        //
        // POST: /Admin/He/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            STU_He stu_he = db.STU_He.Find(id);
            db.STU_He.Remove(stu_he);
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