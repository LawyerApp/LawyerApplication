using Microsoft.AspNetCore.Localization;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LawyerApp.Infrastructures.CustomCulture
{
    public class RouteRequestCultureProvider : RequestCultureProvider
    {
        public int Segment { get; set; } = 1;

        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            string culture = httpContext.Request.Path.Value.Split('/')[Segment];
            if (string.IsNullOrEmpty(culture))
            {
                return NullProviderCultureResult;
            }
            var providerResultCulture = new ProviderCultureResult(culture, culture);

            return Task.FromResult(providerResultCulture);
        }
    }
}
