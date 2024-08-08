using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DefenseSimulator.Data;
using DefenseSimulator.Models;
using DefenseSystem.Data.Models;


namespace DefenseSimulator.Controllers
{
    public class ArsenalsController : Controller
    {
        private readonly DefenseSimulatorContext _context;

        public ArsenalsController(DefenseSimulatorContext context)
        {
            _context = context;
        }

        // GET: Arsenals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arsenal.ToListAsync());
        }

        // GET: Arsenals/Details/5
        public async Task<IActionResult> Details(CounterType id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arsenal = await _context.Arsenal
                .FirstOrDefaultAsync(m => m.Counter == id);
            if (arsenal == null)
            {
                return NotFound();
            }

            return View(arsenal);
        }

        // GET: Arsenals/Create
        public IActionResult Create()
        {
            ViewBag.CounterTypes = EnumServices.GetEnumSelectList<CounterType>();
            return View();
        }

        // POST: Arsenals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Counter,Amount")] Arsenal arsenal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arsenal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arsenal);
        }

        // GET: Arsenals/Edit/5
        public async Task<IActionResult> Edit(CounterType id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arsenal = await _context.Arsenal.FindAsync(id);
            if (arsenal == null)
            {
                return NotFound();
            }
            return View(arsenal);
        }

        // POST: Arsenals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CounterType id, [Bind("Counter,Amount")] Arsenal arsenal)
        {
            if (id != arsenal.Counter)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arsenal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArsenalExists(arsenal.Counter))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(arsenal);
        }

        // GET: Arsenals/Delete/5
        public async Task<IActionResult> Delete(CounterType id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arsenal = await _context.Arsenal
                .FirstOrDefaultAsync(m => m.Counter == id);
            if (arsenal == null)
            {
                return NotFound();
            }

            return View(arsenal);
        }

        // POST: Arsenals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(CounterType id)
        {
            var arsenal = await _context.Arsenal.FindAsync(id);
            if (arsenal != null)
            {
                _context.Arsenal.Remove(arsenal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArsenalExists(CounterType id)
        {
            return _context.Arsenal.Any(e => e.Counter == id);
        }
    }
    
}
