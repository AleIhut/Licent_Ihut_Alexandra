namespace Licent_Ihut_Alexandra.Models
{
    public class Localitate
    {
        public int ID { get; set; }
        public string NumeLocalitate { get; set; }
        public ICollection<SalaEveniment>? SaliEvenimente { get; set; }
        public ICollection<Prajitura>? Prajituri { get; set; }
        public ICollection<Hostes>? Hostess { get; set; }
        public int? JudetID { get; set; }
        public Judet? Judet { get; set; }

    }
}
