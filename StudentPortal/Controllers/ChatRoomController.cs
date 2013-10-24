using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class ChatRoomController : BaseController
    {
        //
        // GET: /ChatRoom/

        public ActionResult Index()
        {
            return View();
        }

    }
}
