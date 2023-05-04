namespace Licent_Ihut_Alexandra.Models
{
    public class SalaEvenimentAles
    {
        public int MembruID { get; set; }
        public int SalaEvenimentID { get; set; }
        public Membru Membru { get; set; }
        public SalaEveniment SalaEveniment { get; set; }
    }
}
