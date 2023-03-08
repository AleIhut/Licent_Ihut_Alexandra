using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Licent_Ihut_Alexandra.Models
{
    public class SalaEveniment
    {
        public int ID { get; set; }
        [Display(Name = "Denumire locație")]
        public string? Nume { get; set; }


        public string? Judet { get; set; }
        public string? Localitate { get; set; }
        public string? Imagine { get; set; }

        [NotMapped]
        [Display(Name = "Forografie(.jpg sau .png)")]
        public IFormFile FisierImagine { get; set; }

        //[StringLength(8, MinimumLength = 2)]

        [Display(Name="Capacitate maximă")]
        public decimal Capacitate  { get; set; }

        [RegularExpression(@"^\(?([0]{1})\)?([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' si sa inceapa cu 0!")]
        public string? Telefon { get; set; }

        
        [EmailAddress(ErrorMessage ="Adresa de email nu este validă!")]
        public string  Email { get; set; }

        [StringLength(300)]
        public string? Descriere { get; set; }

    }
}
