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
    public class GamesController : Controller
    {
        private readonly GameManagerPROContext _context;

        public GamesController(GameManagerPROContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var gameManagerPROContext = _context.Game.Include(g => g.Arena).Include(g => g.AwayTeam).Include(g => g.HomeTeam).Include(g => g.Referee1).Include(g => g.Referee2).Include(g => g.Referee3).Include(g => g.Referee4).Include(g => g.Referee5).Include(g => g.Series);
            return View(await gameManagerPROContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.HomeTeam)
                .Include(g => g.Referee1)
                .Include(g => g.Referee2)
                .Include(g => g.Referee3)
                .Include(g => g.Referee4)
                .Include(g => g.Referee5)
                .Include(g => g.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "ArenaName");
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName");
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchNumber,MatchDateTime,ArenaId,TeamId,TeamId1,PersonId,PersonId1,PersonId2,PersonId3,PersonId4,SeriesId,HomeTeamScore,AwayTeamScore,TSMNumber")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "ArenaName", game.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", game.TeamId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", game.TeamId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId3);
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId4);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", game.SeriesId);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "ArenaName", game.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", game.TeamId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", game.TeamId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId3);
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId4);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", game.SeriesId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchNumber,MatchDateTime,ArenaId,TeamId,TeamId1,PersonId,PersonId1,PersonId2,PersonId3,PersonId4,SeriesId,HomeTeamScore,AwayTeamScore,TSMNumber")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            ViewData["ArenaId"] = new SelectList(_context.Set<Arena>(), "Id", "ArenaName", game.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "ArenaName", game.TeamId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "ArenaName", game.TeamId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId3);
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName", game.PersonId4);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", game.SeriesId);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Arena)
                .Include(g => g.AwayTeam)
                .Include(g => g.HomeTeam)
                .Include(g => g.Referee1)
                .Include(g => g.Referee2)
                .Include(g => g.Referee3)
                .Include(g => g.Referee4)
                .Include(g => g.Referee5)
                .Include(g => g.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
