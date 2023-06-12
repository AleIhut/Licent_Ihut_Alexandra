using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Xml.Linq;

namespace Licent_Ihut_Alexandra.Models
{
    public class Membru
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adresa { get; set; }
        [EmailAddress(ErrorMessage = "Adresa de email nu este validă!")]
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0]{1})\)?([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' si sa inceapa cu 0!")]
        public string? Telefon { get; set; }
        public int? UserSauPrestatorID { get; set; }
        public UserSauPrestator? UserSauPrestator { get; set; }
        public ICollection<Fotograf>? Fotografi { get; set; }
        public ICollection<SalaEveniment>? SaliEvenimente { get; set; }
        public ICollection<Sonorizare>? Sonorizari { get; set; }
        public ICollection<Decoratiune>? Decoratiuni { get; set; }
        public ICollection<Artist>? Artisti { get; set; }
        public ICollection<Hostes>? Hostess { get; set; }
        public ICollection<MaterialPirotehnic>? MaterialePirotehnice { get; set; }
        public ICollection<Prajitura>? Prajituri { get; set; }
        public ICollection<PachetulMeu>? PacheteleMele { get; set; }


    }
}
