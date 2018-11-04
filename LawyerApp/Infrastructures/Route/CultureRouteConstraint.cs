using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LawyerApp.Infrastructures
{
    public class CultureRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string ReceivedValue = values[routeKey].ToString();
            if (ReceivedValue.Contains("en-US") || ReceivedValue.Contains("ru-RU") || ReceivedValue.Contains("az-LATN"))
                return true;
            else
                return false;
        }
    }
}
