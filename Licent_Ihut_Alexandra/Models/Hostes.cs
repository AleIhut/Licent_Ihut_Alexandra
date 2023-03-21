using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licent_Ihut_Alexandra.Models
{
    public class Hostes
    {
        public int ID { get; set; }
        [Display(Name = "Companie")]
        public string Nume { get; set; }
        //  [RegularExpression(@"(Alba|Arad|Arges|Bacau|Bihor|Bistrita-Nasaud|Botosani|Braila|Brasov|Bucuresti|Buzau|Calarasi|Caras-Severin|Cluj|Constanta|Covasna|Dambovita|Dolj|Galati|Giurgiu|Gorj|Harghita|Hunedoara|Ialomita|Iasi|Ilfov|Maramures|Mehedinti|Mures|Neamt|Olt|Prahova|Salaj|Satu-Mare|Sibiu|Suceava|Teleorman|Timis|Tulcea|Valcea|Vaslui|Vrancea)$", ErrorMessage = "Județ invalid!Trebuie să fie de forma 'Bihor'.")]

        public int? JudetID { get; set; }
        public Judet? Judet { get; set; }

        // public string? Localitate { get; set; }
        public int? LocalitateID { get; set; }
        public Localitate? Localitate { get; set; }
        public string Imagine { get; set; }

        [NotMapped]
        [Display(Name = "Forografie(.jpg sau .png)")]
        public IFormFile FisierImagine { get; set; }


        [Display(Name = "Culori disponibile pentru ținute")]
        //public string Culori { get; set; }
        public ICollection<HostesCuloare>? HostesCulori { get; set; }

        [RegularExpression(@"^\(?([0]{1})\)?([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' si sa inceapa cu 0!")]
        public string Telefon { get; set; }


        [EmailAddress(ErrorMessage = "Adresa de email nu este validă!")]
        // [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Adresa de email nu este valida!")]
        public string Email { get; set; }

        [StringLength(300)]
        public string? Descriere { get; set; }
    }
}
