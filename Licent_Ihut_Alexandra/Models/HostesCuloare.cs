namespace Licent_Ihut_Alexandra.Models
{
    public class HostesCuloare
    {
        public int ID { get; set; }
        public int HostesID { get; set; }
        public Hostes Hostes { get; set; }
        public int CuloareID { get; set; }
        public Culoare Culoare { get; set; }
    }
}
