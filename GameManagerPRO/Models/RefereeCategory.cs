using System.ComponentModel.DataAnnotations;

namespace ProPayment.Models
{
    public class RefereeCategory
    {
        public int Id { get; set; }

        [Display(Name = "Domar Kategori")]
        public string RefereeCategoryName { get; set; }
    }
}