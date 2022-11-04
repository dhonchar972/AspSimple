using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace AspWebApplication.Util
{
    public class CustomConstraint : IHttpRouteConstraint
    {
        private readonly string _uri;

        public CustomConstraint(string uri)
        {
            _uri = uri;
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            return !(_uri == request.RequestUri.AbsolutePath);
        }
    }
}