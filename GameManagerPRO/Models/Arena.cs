using System.ComponentModel.DataAnnotations;

namespace ProPayment.Models
{
    public class Arena
    {
        public int Id { get; set; }

        [Display(Name = "Arena")]
        public string ArenaName { get; set; }
    }
}