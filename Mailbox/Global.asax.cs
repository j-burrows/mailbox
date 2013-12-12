using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mailbox{
    public class MvcApplication : System.Web.HttpApplication{
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "Account/{action}",
                new { controller = "Account" },
                new string[]{"Mailbox.Controllers"}
            );

            routes.MapRoute(
                null,
                "{action}",
                new { controller = "Home", action="Index"},
                new string[] { "Mailbox.Controllers" }
            );
        }

        protected void Application_Start(){
            Repository.Configuration.connString = System.Configuration.ConfigurationManager
                .ConnectionStrings["MailboxAppConnection"].ConnectionString;
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //Replaces with custom register routes
            RegisterRoutes(RouteTable.Routes);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}