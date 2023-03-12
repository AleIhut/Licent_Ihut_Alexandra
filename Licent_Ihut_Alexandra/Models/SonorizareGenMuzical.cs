using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Licent_Ihut_Alexandra.Models
{
    public class SonorizareGenMuzical
    {
       
            public int ID { get; set; }

        public int SonorizareID { get; set; }
        
        public Sonorizare Sonorizare { get; set; }
        public int GenMuzicalID { get; set; }
            public GenMuzical GenMuzical { get; set; }
        
    }
}
