using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Licent_Ihut_Alexandra.Models
{
    public class Sonorizare
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        
        [Display(Name = "Detalii de contact")]
        [RegularExpression(@"^\(?([0]{1})\)?([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' si sa inceapa cu 0!")]
        public string Numar { get; set; }
        [StringLength(300)]
        public string Descriere { get; set; }
        [Display(Name = "Genuri muzicale interpretate")]

        
        public ICollection<SonorizareGenMuzical>? SonorizareGenuriMuzicale { get; set; }

        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }
        public ICollection<PachetulMeu>? PacheteleMele { get; set; }
    }
}
