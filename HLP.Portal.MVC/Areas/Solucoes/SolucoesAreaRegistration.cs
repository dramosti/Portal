using System.Web.Mvc;

namespace HLP.Portal.MVC.Areas.Solucoes
{
    public class SolucoesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Solucoes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Solucoes_default",
                "Solucoes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
