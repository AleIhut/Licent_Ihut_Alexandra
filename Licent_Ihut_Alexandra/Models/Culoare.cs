namespace Licent_Ihut_Alexandra.Models
{
    public class Culoare
    {
        public int ID { get; set; }
        public string CuloareName { get; set; }
        public ICollection<HostesCuloare>? HostesCulori { get; set; }
    }
}
