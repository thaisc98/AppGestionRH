using System.Web.Mvc;
using System.Web.Routing;

namespace AppFinalRH
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Principal", action = "Index", id = UrlParameter.Optional}
            );
            (RouteTable.Routes[routes.Count - 1] as Route).DataTokens["area"] = "Lobby";
        }
    }
}
