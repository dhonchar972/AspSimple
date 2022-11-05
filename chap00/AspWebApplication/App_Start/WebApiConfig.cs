using System.Web.Http;

namespace AspWebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            // var cors = new EnableCorsAttribute("http://www.example.com", "*", "*");
            // config.EnableCors(cors);
            config.EnableCors();

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "GetAllProducts",
                routeTemplate: "api/{controller}"
            );
            config.Routes.MapHttpRoute(
                name: "GetProduct",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            // ,constraints: new
            //     {
            //         action = new AlphaRouteConstraint(),
            //         myConstraint = new CustomConstraint("/api/values/get")
            //     }
            );
        }
    }
}