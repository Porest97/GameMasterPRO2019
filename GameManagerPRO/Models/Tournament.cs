using System.ComponentModel.DataAnnotations;

namespace GameManagerPRO.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        [Display(Name = "Turnering")]
        public string TournamentName { get; set; }
    }
}