﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Licent_Ihut_Alexandra.Models
{
    public class Prajitura
    {
        public int ID { get; set; }
        [Display(Name = "Cofetărie")]
        public string Nume { get; set; }
        //  [RegularExpression(@"(Alba|Arad|Arges|Bacau|Bihor|Bistrita-Nasaud|Botosani|Braila|Brasov|Bucuresti|Buzau|Calarasi|Caras-Severin|Cluj|Constanta|Covasna|Dambovita|Dolj|Galati|Giurgiu|Gorj|Harghita|Hunedoara|Ialomita|Iasi|Ilfov|Maramures|Mehedinti|Mures|Neamt|Olt|Prahova|Salaj|Satu-Mare|Sibiu|Suceava|Teleorman|Timis|Tulcea|Valcea|Vaslui|Vrancea)$", ErrorMessage = "Județ invalid!Trebuie să fie de forma 'Bihor'.")]

        public int? JudetID { get; set; }
        public Judet? Judet { get; set; }

        // public string? Localitate { get; set; }
        public int? LocalitateID { get; set; }
        public Localitate? Localitate { get; set; }
        public string? Imagine { get; set; }

        [NotMapped]
        [Display(Name = "Forografie(.jpg sau .png)")]
        public IFormFile FisierImagine { get; set; }

        //[StringLength(8, MinimumLength = 5, ErrorMessage = "Capacitatea trebuie să fie în intervalul minim 10-10 și maxim 9999-9999 de această formă ")]

        [Display(Name = "Creme de bază")]
        public string Creme { get; set; }

        [Display(Name = "Tipuri prăjituri")]
        public string Feluri { get; set; }

        [Display(Name = "Se realizează figurine?")]
        // public string? Figurine { get; set; }
        [BindProperty]

        public string Figurina { get; set; }
       public string[] Figurine = new[] { "da", "nu" };

        [RegularExpression(@"^\(?([0]{1})\)?([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' si sa inceapa cu 0!")]
        public string Telefon { get; set; }


       // [EmailAddress(ErrorMessage = "Adresa de email nu este validă!")]
        // [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Adresa de email nu este valida!")]
       // public string Email { get; set; }

        [StringLength(300)]
        public string? Descriere { get; set; }
        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }

        public ICollection<PachetulMeu>? PacheteleMele { get; set; }
    }
}
