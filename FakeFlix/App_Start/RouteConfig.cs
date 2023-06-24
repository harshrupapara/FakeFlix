
using System.Web.Mvc;
using System.Web.Routing;

namespace FakeFlix.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathinfo}");
            routes.MapRoute(
                name: "FakeFlix",
                url: "api/{controller}/{action}",
                defaults: new { controller = "{controller}", action = "{action}" }
            );
        }
    }
}