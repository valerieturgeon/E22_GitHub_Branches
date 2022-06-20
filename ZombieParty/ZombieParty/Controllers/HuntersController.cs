using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZombieParty_DataAccess.Data;
using ZombieParty_Models;

namespace ZombieParty.Controllers
{
    public class HuntersController : Controller
    {
        private readonly ZombiePartyDbContext _context;

        public HuntersController(ZombiePartyDbContext context)
        {
            _context = context;
        }

        // GET: Hunters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hunter.ToListAsync());
        }

        // GET: Hunters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hunter = await _context.Hunter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hunter == null)
            {
                return NotFound();
            }

            return View(hunter);
        }

        // GET: Hunters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hunters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nickname,Biography")] Hunter hunter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hunter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hunter);
        }

        // GET: Hunters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hunter = await _context.Hunter.FindAsync(id);
            if (hunter == null)
            {
                return NotFound();
            }
            return View(hunter);
        }

        // POST: Hunters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nickname,Biography")] Hunter hunter)
        {
            if (id != hunter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hunter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HunterExists(hunter.Id))
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
            return View(hunter);
        }

        // GET: Hunters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hunter = await _context.Hunter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hunter == null)
            {
                return NotFound();
            }

            return View(hunter);
        }

        // POST: Hunters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hunter = await _context.Hunter.FindAsync(id);
            _context.Hunter.Remove(hunter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HunterExists(int id)
        {
            return _context.Hunter.Any(e => e.Id == id);
        }
    }
}
