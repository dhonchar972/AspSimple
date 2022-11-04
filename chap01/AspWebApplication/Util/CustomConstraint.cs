using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace AspWebApplication.Util
{
    public class CustomConstraint : IHttpRouteConstraint
    {
        private string uri;

        public CustomConstraint(string uri)
        {
            this.uri = uri;
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            return !(uri == request.RequestUri.AbsolutePath);
        }
    }
}