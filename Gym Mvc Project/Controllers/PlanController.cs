using Gym_Mvc_Project.Contexts;
using GymManagment.DAL.Respositories.Classes;
using GymManagment.DAL.Respositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gym_Mvc_Project.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanRepository _planRepository ;
        public PlanController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

       
        //GET :: BaseUrl/Plan/Index
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var plans = await _planRepository.GetAllAsync(ct : ct);  //pass by name
            return View(plans); 
        }
        //GET :: BaseUrl/Plan/Details/{Id}
        public async Task<IActionResult> Details(int id , CancellationToken ct)
        {
            var plan = await _planRepository.GetByIdAsync(id , ct);
            if (plan == null) 
                return RedirectToAction(nameof(Index));

            return View(plan);
        }

    }
}
