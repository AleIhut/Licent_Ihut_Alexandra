namespace Licent_Ihut_Alexandra.Models
{
    public class Judet
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public ICollection<SalaEveniment>? SaliEvenimente { get; set; }

    }
}
