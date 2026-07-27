using Gym_Mvc_Project.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gym_Mvc_Project.Controllers
{
    public class PlanController : Controller
    {

        private readonly GymDbContext context;

        public PlanController()
        {
            context = new GymDbContext();
        }
        //GET :: BaseUrl/Plan/Index
        public async Task<IActionResult> Index()
        {
            var plans = await context.Plans.ToListAsync();
            return View(plans);
        }
        //GET :: BaseUrl/Plan/Details/{Id}
        public async Task<IActionResult> Details(int id)
        {
            var plan = await context.Plans.FindAsync(id);
            if (plan == null) 
                return RedirectToAction(nameof(Index));

            return View(plan);
        }

    }
}
