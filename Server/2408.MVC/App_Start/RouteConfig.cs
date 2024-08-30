using System.Web.Mvc;
using System.Web.Routing;

namespace _2408.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "FindItems",
                url: "Item/FindItems",
                defaults: new { controller = "Item", action = "FindItems" }
            );

            routes.MapRoute(
                name: "SaleRegistraion",
                url: "Sale/Input/Registraion",
                defaults: new { controller = "Sale", action = "SaleRegistraion" }
            );

            routes.MapRoute(
                name: "SaleModification",
                url: "Sale/Input/Modification",
                defaults: new { controller = "Sale", action = "SaleModification" }
            );

            routes.MapRoute(
                name: "ItemRegistraion",
                url: "Item/Input/Registraion",
                defaults: new { controller = "Item", action = "Input", id = "ItemRegistraion" }
            );

            routes.MapRoute(
                name: "ItemModification",
                url: "Item/Input/Modification",
                defaults: new { controller = "Item", action = "Input", id = "ItemModification" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
