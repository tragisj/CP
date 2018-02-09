using System.Web.Mvc;
using System.Web.Routing;

namespace FNSB.PW.Projects.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Projects", action = "ActiveProjects", id = UrlParameter.Optional }
            );
        }
    }
}
