namespace Licent_Ihut_Alexandra.Models
{
    public class SonorizareData
    {
        public IEnumerable<Sonorizare> Sonorizari { get; set; }
        public IEnumerable<GenMuzical> GenuriMuzicale { get; set; }
        public IEnumerable<SonorizareGenMuzical> SonorizareGenuriMuzicale { get; set; }
    }
}
