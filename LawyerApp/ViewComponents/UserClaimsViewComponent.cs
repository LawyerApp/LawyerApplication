using LawyerApp.Areas.LawyerAdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LawyerApp.ViewComponents
{
    [ViewComponent(Name ="Claims")]
    public class UserClaimsViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new UserDto
            {
                Id=HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Name=HttpContext.User.FindFirst(ClaimTypes.Name)?.Value,
                Role=HttpContext.User.FindFirst(ClaimTypes.Role)?.Value
            });
        }
    }
}
