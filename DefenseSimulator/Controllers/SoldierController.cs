using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DefenseSimulator.Data;
using DefenseSimulator.Models;
namespace DefenseSimulator.Controllers
{
    public class SoldierController : Controller

    {
        private readonly DefenseSimulatorContext _context;

        public SoldierController(DefenseSimulatorContext context)
        {
            _context = context;
        }

        // GET: Threats
        public async Task<IActionResult> Index()
        {
            var defenseSimulatorContext = _context.Threat.Include(t => t.Weapon);
            return View(await defenseSimulatorContext.ToListAsync());
        }

        

    }
}