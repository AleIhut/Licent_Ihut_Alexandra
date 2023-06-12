namespace Licent_Ihut_Alexandra.Models
{
    public class PachetulMeu
    {
        public int ID { get; set; }

        public int? SalaEvenimentID { get; set; }
        public SalaEveniment? SalaEveniment { get; set; }

        public int? SonorizareID { get; set; }
        public Sonorizare? Sonorizare { get; set; }

        public int? DecoratiuneID { get; set; }
        public Decoratiune? Decoratiune { get; set; }

        public int? FotografID { get; set; }
        public Fotograf? Fotograf { get; set; }

        public int? ArtistID { get; set; }
        public Artist? Artist { get; set; }

        public int? HostesID { get; set; }
        public Hostes? Hostes { get; set; }

        public int? MaterialPirotehnicID { get; set; }
        public MaterialPirotehnic? MaterialPirotehnic { get; set; }

        public int? PrajituraID { get; set; }
        public Prajitura? Prajitura { get; set; }

        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }

        public PachetulMeu()
        {
            SalaEveniment = null;
            Sonorizare = null;
            Decoratiune = null;
            Fotograf = null;
            Artist = null;
            Hostes = null;
            MaterialPirotehnic = null;
            Prajitura = null;
            
        }
    }
}
