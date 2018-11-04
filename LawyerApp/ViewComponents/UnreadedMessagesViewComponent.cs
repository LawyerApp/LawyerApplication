using LawyerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.ViewComponents
{
    [ViewComponent(Name = "UnreadedMessages")]
    public class UnreadedMessagesViewComponent : ViewComponent
    {
        private readonly LawyerDbContext lawyerDbContext;

        public UnreadedMessagesViewComponent(LawyerDbContext lawyerDbContext)
        {
            this.lawyerDbContext = lawyerDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await lawyerDbContext.Messages.Where(x => x.Status == false).OrderByDescending(x => x.Id).Take(5).ToListAsync());
        }
    }
}
