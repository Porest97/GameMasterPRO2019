using System.ComponentModel.DataAnnotations;

namespace ProPayment.Models
{
    public class RefereeType
    {
        public int Id { get; set; }

        [Display(Name = "Domar Typ")]
        public string RefereeTypeName { get; set; }
    }
}