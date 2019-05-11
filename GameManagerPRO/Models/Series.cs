using System.ComponentModel.DataAnnotations;

namespace ProPayment.Models
{
    public class Series
    {
        public int Id { get; set; }

        [Display(Name ="Serie")]
        public string SeriesName { get; set; }
    }
}