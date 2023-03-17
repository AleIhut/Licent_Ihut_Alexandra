using System.ComponentModel.DataAnnotations;

namespace Licent_Ihut_Alexandra.Models
{
    public class Decoratiune
    {
        public int ID { get; set; }
        public string Companie { get; set; }

        [Display(Name = "Adresa completă")]
       
        public string Locație { get; set; }
        [RegularExpression(@"^\(?([0]{1})\)?([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' si sa inceapa cu 0!")]
        public string Telefon { get; set; }

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Adresa de email nu este valida!")]
        public string Email { get; set; }
       public int? MaterialID { get; set; } //cheia straina materie prima
        public Material? Material { get; set; }
        [Display(Name = "Oferă câteva detalii suplimentare!")]
        [StringLength(300)]

        public string? Descriere { get; set; }
        
       
    }
}
