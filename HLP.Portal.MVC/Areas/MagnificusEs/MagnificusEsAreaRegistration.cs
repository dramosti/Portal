using System.Web.Mvc;

namespace HLP.Portal.MVC.Areas.MagnificusEs
{
    public class MagnificusEsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MagnificusEs";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MagnificusEs_default",
                "MagnificusEs/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
