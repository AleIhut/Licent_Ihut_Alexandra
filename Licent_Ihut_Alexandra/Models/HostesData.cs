namespace Licent_Ihut_Alexandra.Models
{
    public class HostesData
    {
        public IEnumerable<Hostes> Hostess { get; set; }
        public IEnumerable<Culoare> Culori { get; set; }
        public IEnumerable<HostesCuloare> HostesCulori { get; set; }
    }
}
