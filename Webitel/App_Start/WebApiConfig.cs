using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Webitel
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //На кожен з запитів повертатається response у форматі json.
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // config.Formatters.Clear();
            // config.Formatters.Add(GlobalConfiguration.Configuration.Formatters.JsonFormatter);
        }
    }
}
