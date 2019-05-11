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
    public class RefereeCategoriesController : Controller
    {
        private readonly GameManagerPROContext _context;

        public RefereeCategoriesController(GameManagerPROContext context)
        {
            _context = context;
        }

        // GET: RefereeCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefereeCategory.ToListAsync());
        }

        // GET: RefereeCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeCategory = await _context.RefereeCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refereeCategory == null)
            {
                return NotFound();
            }

            return View(refereeCategory);
        }

        // GET: RefereeCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefereeCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RefereeCategoryName")] RefereeCategory refereeCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refereeCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refereeCategory);
        }

        // GET: RefereeCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeCategory = await _context.RefereeCategory.FindAsync(id);
            if (refereeCategory == null)
            {
                return NotFound();
            }
            return View(refereeCategory);
        }

        // POST: RefereeCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RefereeCategoryName")] RefereeCategory refereeCategory)
        {
            if (id != refereeCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refereeCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefereeCategoryExists(refereeCategory.Id))
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
            return View(refereeCategory);
        }

        // GET: RefereeCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeCategory = await _context.RefereeCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refereeCategory == null)
            {
                return NotFound();
            }

            return View(refereeCategory);
        }

        // POST: RefereeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refereeCategory = await _context.RefereeCategory.FindAsync(id);
            _context.RefereeCategory.Remove(refereeCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefereeCategoryExists(int id)
        {
            return _context.RefereeCategory.Any(e => e.Id == id);
        }
    }
}
