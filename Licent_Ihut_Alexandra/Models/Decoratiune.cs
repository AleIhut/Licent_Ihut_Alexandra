namespace Licent_Ihut_Alexandra.Models
{
    public class Decoratiune
    {
        public int ID { get; set; }
        public string Companie { get; set; }
        public string Locație { get; set; }
        public decimal Telefon { get; set; }
        public string Email { get; set; }
       public int? MaterialID { get; set; } //cheia straina materie prima
        public Material? Material { get; set; }
        public string Descriere { get; set; }
        
       
    }
}
