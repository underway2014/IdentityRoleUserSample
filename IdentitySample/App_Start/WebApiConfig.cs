using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using IdentitySample.Models;

namespace IdentitySample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                model: ODataModel.GetEdmModel());

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{Id}",
            //    defaults: new { Id = RouteParameter.Optional }
            //);

            //config.AddODataQueryFilter();
        }
    }
}
