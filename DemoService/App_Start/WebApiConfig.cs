using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DemoService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //var cors = new CorsPolicy
            //{
            //    AllowAnyOrigin = true,
            //    AllowAnyHeader = true,
            //    AllowAnyMethod = true
            //};
            //cors.Origins.Add("http://example.com");

            var corsAttribute = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(corsAttribute);
        }
    }
}
