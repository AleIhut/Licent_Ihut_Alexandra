namespace Licent_Ihut_Alexandra.Models
{
    public class GenMuzical
    {
        public int ID { get; set; }
        public string GenMuzicalNume { get; set; }
        public ICollection<SonorizareGenMuzical>? SonorizareGenuriMuzicale { get; set; }
    }
}
