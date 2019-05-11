using System.ComponentModel.DataAnnotations;

namespace ProPayment.Models
{
    public class RefereeCategoryType
    {
        public int Id { get; set; }

        [Display(Name = "DomarKategori Typ")]
        public string RefereeCategoryTypeName { get; set; }
    }
}