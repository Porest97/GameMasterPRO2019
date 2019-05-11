using ProPayment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameManagerPRO.Models
{
    public class PROGame
    {
        public int Id { get; set; }

        [Display(Name = "#")]
        public int? MatchNumber { get; set; }

        [Display(Name = "Datum & Tid")]
        public DateTime MatchDateTime { get; set; }

        [Display(Name = "Arena")]
        public Arena Arena { get; set; }
        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }

        [Display(Name = "Hemmalag")]
        public int? TeamId { get; set; }
        [Display(Name = "Hemmalag")]
        [ForeignKey("TeamId")]
        public Team HomeTeam { get; set; }

        [Display(Name = "Bortalag")]
        public int? TeamId1 { get; set; }
        [Display(Name = "Bortalag")]
        [ForeignKey("TeamId1")]
        public Team AwayTeam { get; set; }

        [Display(Name = "Mål Hemmalag")]
        public int? HomeTeamScore { get; set; }

        [Display(Name = "Mål Bortalag")]
        public int? AwayTeamScore { get; set; }

        [Display(Name = "Resultat")]
        public string Result { get { return string.Format("{0} {1} {2}", HomeTeamScore, " - ", AwayTeamScore); } }


        [Display(Name = "HD")]
        public int? PersonId { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("PersonId")]
        public Person Referee1 { get; set; }

        [Display(Name = "HD")]
        public int? PersonId1 { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("PersonId1")]
        public Person Referee2 { get; set; }

        [Display(Name = "LD")]
        public int? PersonId2 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("PersonId2")]
        public Person Referee3 { get; set; }

        [Display(Name = "LD")]
        public int? PersonId3 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("PersonId3")]
        public Person Referee4 { get; set; }

        [Display(Name = "Supervisor")]
        public int? PersonId4 { get; set; }
        [Display(Name = "Supervisor")]
        [ForeignKey("PersonId4")]
        public Person Referee5 { get; set; }

        [Display(Name = "Serie")]
        public int? SeriesId { get; set; }
        [Display(Name = "Serie")]
        [ForeignKey("SeriesId")]
        public Series Series { get; set; }

        [Display(Name = "TSM#")]
        public int? TSMNumber { get; set; }
        [Display(Name = "Betalning")]
        [DataType(DataType.Currency)]
        public double Payment { get; set; }

        [Display(Name = "Betald")]
        public bool Payed { get; set; } = false;


        [Display(Name = "Turnering")]
        public int? TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
