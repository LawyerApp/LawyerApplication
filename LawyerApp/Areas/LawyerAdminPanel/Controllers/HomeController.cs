using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Controllers
{
    [Area(nameof(LawyerAdminPanel))]
    [Authorize]
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("index","slider");
        }
    }
}
