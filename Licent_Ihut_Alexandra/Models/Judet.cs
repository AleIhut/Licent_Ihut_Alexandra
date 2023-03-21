namespace Licent_Ihut_Alexandra.Models
{
    public class Judet
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public ICollection<Localitate>? Localitati { get; set; }
        public ICollection<SalaEveniment>? SaliEvenimente { get; set; }
        public ICollection<Artist>? Artisti { get; set; }
        public ICollection<Fotograf>? Fotografi { get; set; }
        public ICollection<Hostes>? Hostess { get; set; }
        public ICollection<Prajitura>? Prajituri { get; set; }
        public ICollection<MaterialPirotehnic>? MaterialePirotehnice { get; set; }


    }
}
