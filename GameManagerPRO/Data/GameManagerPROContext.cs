using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProPayment.Models;
using GameManagerPRO.Models;

namespace GameManagerPRO.Models
{
    public class GameManagerPROContext : DbContext
    {
        public GameManagerPROContext (DbContextOptions<GameManagerPROContext> options)
            : base(options)
        {
        }

        public DbSet<ProPayment.Models.Team> Team { get; set; }

        public DbSet<ProPayment.Models.Series> Series { get; set; }

        public DbSet<ProPayment.Models.RefereeType> RefereeType { get; set; }

        public DbSet<ProPayment.Models.RefereeDistrikt> RefereeDistrikt { get; set; }

        public DbSet<ProPayment.Models.RefereeCategory> RefereeCategory { get; set; }

        public DbSet<ProPayment.Models.Person> Person { get; set; }

        public DbSet<ProPayment.Models.Game> Game { get; set; }

        public DbSet<ProPayment.Models.Arena> Arena { get; set; }

        public DbSet<GameManagerPRO.Models.PROGame> PROGame { get; set; }

        public DbSet<GameManagerPRO.Models.Tournament> Tournament { get; set; }

        public DbSet<ProPayment.Models.RefereeCategoryType> RefereeCategoryType { get; set; }
    }
}
