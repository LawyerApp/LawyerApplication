using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading;

namespace LawyerApp.Infrastructures
{
    public static class HttpContextExtensions
    {
        public static string GetCurrentUserId(this Controller controller)
        {
            return GetCurrentUserId(controller.HttpContext);
        }

        public static string GetCurrentUserId(this HttpContext context)
        {
            return context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public static string GetCurrentCulture(this HttpContext context)
        {
            return Thread.CurrentThread.CurrentCulture.DisplayName;
        }
    }
}
