using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameManagerPRO.Models;

namespace GameManagerPRO.Controllers
{
    public class PROGamesController : Controller
    {
        private readonly GameManagerPROContext _context;

        public PROGamesController(GameManagerPROContext context)
        {
            _context = context;
        }

        // GET: PROGames
        public async Task<IActionResult> Index()
        {
            var gameManagerPROContext = _context.PROGame.Include(p => p.Arena).Include(p => p.AwayTeam).Include(p => p.HomeTeam).Include(p => p.Referee1).Include(p => p.Referee2).Include(p => p.Referee3).Include(p => p.Referee4).Include(p => p.Referee5).Include(p => p.Series).Include(p => p.Tournament);
            return View(await gameManagerPROContext.ToListAsync());
        }

        // GET: PROGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pROGame = await _context.PROGame
                .Include(p => p.Arena)
                .Include(p => p.AwayTeam)
                .Include(p => p.HomeTeam)
                .Include(p => p.Referee1)
                .Include(p => p.Referee2)
                .Include(p => p.Referee3)
                .Include(p => p.Referee4)
                .Include(p => p.Referee5)
                .Include(p => p.Series)
                .Include(p => p.Tournament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pROGame == null)
            {
                return NotFound();
            }

            return View(pROGame);
        }

        // GET: PROGames/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName");
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName");
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "Id", "TournamentName");
            return View();
        }

        // POST: PROGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchNumber,MatchDateTime,ArenaId,TeamId,TeamId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3,PersonId4,SeriesId,TSMNumber,Payment,Payed,TournamentId")] PROGame pROGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pROGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", pROGame.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", pROGame.TeamId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", pROGame.TeamId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId3);
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId4);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", pROGame.SeriesId);
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "Id", "TournamentName", pROGame.TournamentId);
            return View(pROGame);
        }

        // GET: PROGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pROGame = await _context.PROGame.FindAsync(id);
            if (pROGame == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", pROGame.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", pROGame.TeamId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", pROGame.TeamId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId3);
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId4);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", pROGame.SeriesId);
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "Id", "TournamentName", pROGame.TournamentId);
            return View(pROGame);
        }

        // POST: PROGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchNumber,MatchDateTime,ArenaId,TeamId,TeamId1,HomeTeamScore,AwayTeamScore,PersonId,PersonId1,PersonId2,PersonId3,PersonId4,SeriesId,TSMNumber,Payment,Payed,TournamentId")] PROGame pROGame)
        {
            if (id != pROGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pROGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PROGameExists(pROGame.Id))
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
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", pROGame.ArenaId);
            ViewData["TeamId1"] = new SelectList(_context.Team, "Id", "TeamName", pROGame.TeamId1);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", pROGame.TeamId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId1);
            ViewData["PersonId2"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId2);
            ViewData["PersonId3"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId3);
            ViewData["PersonId4"] = new SelectList(_context.Person, "Id", "FullName", pROGame.PersonId4);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", pROGame.SeriesId);
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "Id", "TournamentName", pROGame.TournamentId);
            return View(pROGame);
        }

        // GET: PROGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pROGame = await _context.PROGame
                .Include(p => p.Arena)
                .Include(p => p.AwayTeam)
                .Include(p => p.HomeTeam)
                .Include(p => p.Referee1)
                .Include(p => p.Referee2)
                .Include(p => p.Referee3)
                .Include(p => p.Referee4)
                .Include(p => p.Referee5)
                .Include(p => p.Series)
                .Include(p => p.Tournament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pROGame == null)
            {
                return NotFound();
            }

            return View(pROGame);
        }

        // POST: PROGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pROGame = await _context.PROGame.FindAsync(id);
            _context.PROGame.Remove(pROGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PROGameExists(int id)
        {
            return _context.PROGame.Any(e => e.Id == id);
        }
    }
}
