using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentPortal
{
	public class AjaxResult
	{
		public AjaxStatus Status { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
		public object Data { get; set; }
	}
	public enum AjaxStatus
	{
		ERROR = 0,
		SUCCESS = 1
	}
}