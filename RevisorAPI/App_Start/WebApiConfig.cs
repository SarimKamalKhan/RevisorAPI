using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RevisorAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

          
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/private/v1/{controller}/{action}/{id}/{sID}",
                defaults: new { id = RouteParameter.Optional, sID = RouteParameter.Optional }
            );
        }
    }
}
