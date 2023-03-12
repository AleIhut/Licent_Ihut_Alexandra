namespace Licent_Ihut_Alexandra.Models
{
    public class Localitate
    {
        public int ID { get; set; }
        public string NumeLocalitate { get; set; }
        public ICollection<SalaEveniment>? SaliEvenimente { get; set; }
    }
}
