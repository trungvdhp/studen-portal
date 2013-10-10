using System.Web.Mvc;

namespace StudentPortal.Areas
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { 
                    controller = "Dashboard",
                    action = "Index",
                    id = UrlParameter.Optional 
                },
                new[] { "StudentPortal.Areas.Admin.Controllers" }
            );
        }
    }
}