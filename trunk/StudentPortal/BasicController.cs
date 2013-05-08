using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal
{
	public class BasicController : Controller
	{
		protected int items_per_page;

		public BasicController()
		{
			items_per_page = Properties.Settings.Default.items_per_page;

		}
	}
}