using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licent_Ihut_Alexandra.Models
{
    public class MaterialPirotehnic
    {
        public int ID { get; set; }
        [Display(Name = "Firmă prestatoare")]
        public string Nume { get; set; }

        public int JudetID { get; set; }
        public Judet Judet { get; set; }
        public int LocalitateID { get; set; }
        public Localitate Localitate { get; set; }

        [RegularExpression(@"^\(?([0]{1})\)?([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' si sa inceapa cu 0!")]
        public string Telefon { get; set; }


        [EmailAddress(ErrorMessage = "Adresa de email nu este validă!")]
        // [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Adresa de email nu este valida!")]
        public string? Email { get; set; }

        [StringLength(300)]
        public string? Descriere { get; set; }

    }
}
