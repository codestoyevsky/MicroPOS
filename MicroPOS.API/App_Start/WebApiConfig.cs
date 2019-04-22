using System.Web.Http;
using Newtonsoft.Json;

namespace MicroPOS.API
{
   public static class WebApiConfig
   {
      public static void Register(HttpConfiguration config)
      {
         config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
         {
            NullValueHandling = NullValueHandling.Ignore
         };

         config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

         // Web API routes
         config.MapHttpAttributeRoutes();

         config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "api/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
         );
      }
   }
}
