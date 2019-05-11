using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameManagerPRO.Models;
using ProPayment.Models;

namespace GameManagerPRO.Controllers
{
    public class RefereeDistriktsController : Controller
    {
        private readonly GameManagerPROContext _context;

        public RefereeDistriktsController(GameManagerPROContext context)
        {
            _context = context;
        }

        // GET: RefereeDistrikts
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefereeDistrikt.ToListAsync());
        }

        // GET: RefereeDistrikts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeDistrikt = await _context.RefereeDistrikt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refereeDistrikt == null)
            {
                return NotFound();
            }

            return View(refereeDistrikt);
        }

        // GET: RefereeDistrikts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefereeDistrikts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RefereeDistriktName")] RefereeDistrikt refereeDistrikt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refereeDistrikt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refereeDistrikt);
        }

        // GET: RefereeDistrikts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeDistrikt = await _context.RefereeDistrikt.FindAsync(id);
            if (refereeDistrikt == null)
            {
                return NotFound();
            }
            return View(refereeDistrikt);
        }

        // POST: RefereeDistrikts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RefereeDistriktName")] RefereeDistrikt refereeDistrikt)
        {
            if (id != refereeDistrikt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refereeDistrikt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefereeDistriktExists(refereeDistrikt.Id))
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
            return View(refereeDistrikt);
        }

        // GET: RefereeDistrikts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeDistrikt = await _context.RefereeDistrikt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refereeDistrikt == null)
            {
                return NotFound();
            }

            return View(refereeDistrikt);
        }

        // POST: RefereeDistrikts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refereeDistrikt = await _context.RefereeDistrikt.FindAsync(id);
            _context.RefereeDistrikt.Remove(refereeDistrikt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefereeDistriktExists(int id)
        {
            return _context.RefereeDistrikt.Any(e => e.Id == id);
        }
    }
}
