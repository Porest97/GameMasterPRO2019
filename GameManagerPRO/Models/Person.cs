using System.ComponentModel.DataAnnotations;

namespace ProPayment.Models
{
    public class Person
    {
        public int Id { get; set; }
        //Person props
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; } = "N";

        [Display(Name = "Efternamn")]
        public string LastName { get; set; } = "A";

        [Display(Name = "Namn")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        [Display(Name = "Gatuadress")]
        public string StreetAddress { get; set; }

        [Display(Name = "Post Nr")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Display(Name = "Post Ort")]
        public string County { get; set; }

        [Display(Name = "Land")]
        public string Country { get; set; }

        [Display(Name = "Adress")]
        public string Address { get { return string.Format("{0} {1} {2}", StreetAddress, ZipCode, County); } }

        [Display(Name = "Personnummer")]
        public string Ssn { get; set; }

        [Display(Name = "Telefonnummer")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-Post")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Refereerelated props
        [Display(Name = "Domarnummer")]
        public int? RefereeNumber { get; set; }

        [Display(Name = "Domartyp")]
        public RefereeType RefereeType { get; set; }
        public int? RefereeTypeId { get; set; }


        [Display(Name = "Domarkategori")]
        public RefereeCategory RefereeCategory { get; set; }
        public int? RefereeCategoryId { get; set; }

        [Display(Name = "Domardistrikt")]
        public RefereeDistrikt RefereeDistrikt { get; set; }
        public int? RefereeDistriktId { get; set; }
    }
}