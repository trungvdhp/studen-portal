using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Areas.Admin.Controllers
{
	public class BoMonController : Controller
	{
		private DHHHContext db = new DHHHContext();

		//
		// GET: /Admin/BoMon/

		public ActionResult Index()
		{
			return View(db.PLAN_BoMon.ToList());
		}

		//
		// GET: /Admin/BoMon/Details/5

		public ActionResult Read(int page)
		{
			if (page < 1) page = 1;
			JsonResult result = new JsonResult();
			result.Data = db.PLAN_BoMon.OrderBy(t => t.ID_bm).Skip((page - 1) * 10).Take(10).ToList();
			result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return result;
		}

		public ActionResult Details(int id = 0)
		{
			PLAN_BoMon plan_bomon = db.PLAN_BoMon.Find(id);
			if (plan_bomon == null)
			{
				return HttpNotFound();
			}
			return View(plan_bomon);
		}

		//
		// GET: /Admin/BoMon/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Admin/BoMon/Create

		[HttpPost]
		public ActionResult Create(PLAN_BoMon plan_bomon)
		{
			if (ModelState.IsValid)
			{
				db.PLAN_BoMon.Add(plan_bomon);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(plan_bomon);
		}

		//
		// GET: /Admin/BoMon/Edit/5

		public ActionResult Edit(int id = 0)
		{
			PLAN_BoMon plan_bomon = db.PLAN_BoMon.Find(id);
			if (plan_bomon == null)
			{
				return HttpNotFound();
			}
			return View(plan_bomon);
		}

		//
		// POST: /Admin/BoMon/Edit/5

		[HttpPost]
		public ActionResult Edit(PLAN_BoMon plan_bomon)
		{
			if (ModelState.IsValid)
			{
				db.Entry(plan_bomon).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(plan_bomon);
		}

		//
		// GET: /Admin/BoMon/Delete/5

		public ActionResult Delete(int id = 0)
		{
			PLAN_BoMon plan_bomon = db.PLAN_BoMon.Find(id);
			if (plan_bomon == null)
			{
				return HttpNotFound();
			}
			return View(plan_bomon);
		}

		//
		// POST: /Admin/BoMon/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			PLAN_BoMon plan_bomon = db.PLAN_BoMon.Find(id);
			db.PLAN_BoMon.Remove(plan_bomon);
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