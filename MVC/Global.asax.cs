using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DummyImage
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Default",                                              // Route name
                "",                           // URL with parameters
                new { controller = "Dummy", action = "Get", width = 640, height = 480 }  // Parameter defaults
            );
            routes.MapRoute(
                "Default2",                                              // Route name
                "{width}x{height}",                           // URL with parameters
                new { controller = "Dummy", action = "Get", width = 640, height = 480 }  // Parameter defaults
            );
            routes.MapRoute(
                "DummyImage",                                              // Route name
                "{controller}/{width}x{height}",                           // URL with parameters
                new { controller = "Dummy", action = "Get", width=640, height=480 }  // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}