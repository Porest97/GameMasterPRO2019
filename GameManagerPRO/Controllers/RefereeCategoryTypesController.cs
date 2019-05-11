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
    public class RefereeCategoryTypesController : Controller
    {
        private readonly GameManagerPROContext _context;

        public RefereeCategoryTypesController(GameManagerPROContext context)
        {
            _context = context;
        }

        // GET: RefereeCategoryTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefereeCategoryType.ToListAsync());
        }

        // GET: RefereeCategoryTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeCategoryType = await _context.RefereeCategoryType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refereeCategoryType == null)
            {
                return NotFound();
            }

            return View(refereeCategoryType);
        }

        // GET: RefereeCategoryTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefereeCategoryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RefereeCategoryTypeName")] RefereeCategoryType refereeCategoryType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refereeCategoryType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refereeCategoryType);
        }

        // GET: RefereeCategoryTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeCategoryType = await _context.RefereeCategoryType.FindAsync(id);
            if (refereeCategoryType == null)
            {
                return NotFound();
            }
            return View(refereeCategoryType);
        }

        // POST: RefereeCategoryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RefereeCategoryTypeName")] RefereeCategoryType refereeCategoryType)
        {
            if (id != refereeCategoryType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refereeCategoryType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefereeCategoryTypeExists(refereeCategoryType.Id))
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
            return View(refereeCategoryType);
        }

        // GET: RefereeCategoryTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refereeCategoryType = await _context.RefereeCategoryType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refereeCategoryType == null)
            {
                return NotFound();
            }

            return View(refereeCategoryType);
        }

        // POST: RefereeCategoryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refereeCategoryType = await _context.RefereeCategoryType.FindAsync(id);
            _context.RefereeCategoryType.Remove(refereeCategoryType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefereeCategoryTypeExists(int id)
        {
            return _context.RefereeCategoryType.Any(e => e.Id == id);
        }
    }
}
