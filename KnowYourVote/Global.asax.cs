using KnowYourVote.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KnowYourVote
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Default stuff
            AreaRegistration.RegisterAllAreas();

            // Manually installed WebAPI 2.2 after making an MVC project.
            GlobalConfiguration.Configure(WebApiConfig.Register); // NEW way
                                                                  //WebApiConfig.Register(GlobalConfiguration.Configuration); // DEPRECATED

            // Default stuff
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

//protected void Application_Start()
//{
//    GlobalConfiguration.Configure(WebApiConfig.Register);
//    AreaRegistration.RegisterAllAreas();
//    RouteConfig.RegisterRoutes(RouteTable.Routes);
//}