using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Licent_Ihut_Alexandra.Models
{
    public class Sonorizare
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        //[Display(Name = "Gen muzical")]
       // public string GenMuzical { get; set; }
        [Display(Name = "Contact")]
        public string Numar { get; set; }
        public string Descriere { get; set; }
        public ICollection<SonorizareGenMuzical>? SonorizareGenuriMuzicale { get; set; }

    }
}
