using System.ComponentModel.DataAnnotations.Schema;

namespace Licent_Ihut_Alexandra.Models
{
    public class SalaEveniment
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Judet { get; set; }
        public string Localitate { get; set; }
        public string Imagine { get; set; }

        [NotMapped]
        public IFormFile FisierImagine { get; set; }
        public decimal Capacitate  { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Descriere { get; set; }

    }
}
