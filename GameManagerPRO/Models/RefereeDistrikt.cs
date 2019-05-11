using System.ComponentModel.DataAnnotations;

namespace ProPayment.Models
{
    public class RefereeDistrikt
    {
        public int Id { get; set; }

        [Display(Name = "Domar Distrikt")]
        public string RefereeDistriktName { get; set; }
    }
}