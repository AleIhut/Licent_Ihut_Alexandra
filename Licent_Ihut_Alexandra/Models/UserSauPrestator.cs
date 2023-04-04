namespace Licent_Ihut_Alexandra.Models
{
    public class UserSauPrestator
    {
        public int ID { get; set; }
        public string Tip { get; set; }
        public ICollection<Membru>? Membri { get; set; }
    }
}
