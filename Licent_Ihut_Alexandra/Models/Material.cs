namespace Licent_Ihut_Alexandra.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string Tip { get; set; }

        public ICollection<Decoratiune>? Decoratiune { get; set; }
    }
}
