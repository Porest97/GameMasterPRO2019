using System.ComponentModel.DataAnnotations;

namespace ProPayment.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Display(Name ="LAG")]
        public string TeamName { get; set; }
    }
}