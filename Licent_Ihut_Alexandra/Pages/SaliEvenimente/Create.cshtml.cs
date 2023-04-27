using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.CodeAnalysis;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace Licent_Ihut_Alexandra.Pages.SaliEvenimente
{
    [Authorize(Roles = "Prestator")]
    public class CreateModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public IActionResult OnGet()
        {

            //aceste 2 linii sunt pt ca fiecare sala sa fie pentru prestatorul ei
            var userName = _userManager.GetUserName(User);
            var userEmail = User.Identity.Name; //email of the connected user
           // int currentMembruID = _context.Membru.First(membru => membru.Email == userEmail).ID;
            var localitati = _context.Localitate
                .Select(x => new
                {
                    x.ID,
                    localitateNume = x.Judet.Nume + "-" + x.NumeLocalitate
                })
                .OrderBy(x => x.localitateNume);
            var detaliiMembru = _context.Membru
               .Where(c => c.Email == userName)
               .Select(x => new
               {
                   x.ID,
                   DetaliiMembru = x.Nume
               });
            ViewData["JudetID"] = new SelectList(_context.Set<Judet>(), "ID", "Nume");

            ViewData["LocalitateID"] = new SelectList(localitati, "ID", "localitateNume");
            ViewData["MembruID"] = new SelectList(detaliiMembru, "ID", "DetaliiMembru");
            return Page();
        }

        [BindProperty]
        public SalaEveniment SalaEveniment { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            byte[] bytes = null;
            if (SalaEveniment.FisierImagine != null)
            {
                using (Stream fs = SalaEveniment.FisierImagine.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }

                }
                SalaEveniment.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }

            //List<string> validCountries = new List<string>() { "Alba", "Arad", "Arges", "Bacau", "Bihor", "Bistrita-Nasaud", "Botosani", "Braila", "Brasov", "Bucuresti", "Buzau", "Calarasi", "Caras-Severin", "Cluj", "Constanta", "Covasna", "Dambovita", "Dolj", "Galati", "Giurgiu", "Gorj", "Harghita", "Hunedoara", "Ialomita", "Iasi", "Ilfov", "Maramures", "Mehedinti", "Mures", "Neamt", "Olt", "Prahova", "Salaj", "Satu Mare", "Sibiu", "Suceava", "Teleorman", "Timis", "Tulcea", "Vaslui", "Vrancea" };


            // User input
            // string userInput = SalaEveniment.Judet;

            // Check if the input is a valid country
            //if (validCountries.Contains(SalaEveniment.Judet))
            //{
            //    // Insert the data into the database
            //    // ...
            //}
            //else
            //{
            //    // Display an error message
            //    MessageBox.Show("Invalid country. Please enter a valid country.");
            //}
            //string[] JudetValid = { "Alba", "Arad", "Arges", "Bacau", "Bihor", "Bistrita-Nasaud", "Botosani", "Braila", "Brasov", "Bucuresti", "Buzau", "Calarasi", "Caras-Severin", "Cluj", "Constanta", "Covasna", "Dambovita", "Dolj", "Galati", "Giurgiu", "Gorj", "Harghita", "Hunedoara", "Ialomita", "Iasi", "Ilfov", "Maramures", "Mehedinti", "Mures", "Neamt", "Olt", "Prahova", "Salaj", "Satu Mare", "Sibiu", "Suceava", "Teleorman", "Timis", "Tulcea", "Vaslui", "Vrancea" };

            //if (string.IsNullOrEmpty(SalaEveniment.Judet))
            //{
            //    Console.WriteLine("County name cannot be null or empty. Please enter a valid county name.");
            //}
            //else if (JudetValid.Contains(SalaEveniment.Judet, StringComparer.OrdinalIgnoreCase))
            //{
            //    // Do something if the county name is valid
            //}
            //else
            //{
            //    Console.WriteLine("Invalid county name. Please enter a valid county name.");
            //    // Or you can throw an exception, display an error message, or perform some other action
            //}
            //string[] JudetValid = { "Alba", "Arad", "Arges", "Bacau", "Bihor", "Bistrita-Nasaud", "Botosani", "Braila", "Brasov", "Bucuresti", "Buzau", "Calarasi", "Caras-Severin", "Cluj", "Constanta", "Covasna", "Dambovita", "Dolj", "Galati", "Giurgiu", "Gorj", "Harghita", "Hunedoara", "Ialomita", "Iasi", "Ilfov", "Maramures", "Mehedinti", "Mures", "Neamt", "Olt", "Prahova", "Salaj", "Satu Mare", "Sibiu", "Suceava", "Teleorman", "Timis", "Tulcea", "Vaslui", "Vrancea" };


            //if (JudetValid.Contains(SalaEveniment.Judet, StringComparer.OrdinalIgnoreCase))
            //{

            //}
            //else
            //{
            //    //    //    // județul introdus nu este valid
            //    //    //    //MessageBox.Show("Acesta este un mesaj de alertă!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //    //    //window.alert([message]);
            //     return RedirectToPage("./Create");
            //    //Console.WriteLine("Invalid county name. Please enter a valid county name.");
            //    // static string GetMessage()
            //    //{
            //    //    return "Judetul nu e bun";
            //    //}


            //}
            //var regex = new System.Text.RegularExpressions.Regex(@"^(Alba|Arad|Arges|Bacau|Bihor|Bistrita-Nasaud|Botosani|Braila|Brasov|Bucuresti|Buzau|Calarasi|Caras-Severin|Cluj|Constanta|Covasna|Dambovita|Dolj|Galati|Giurgiu|Gorj|Harghita|Hunedoara|Ialomita|Iasi|Ilfov|Maramures|Mehedinti|Mures|Neamt|Olt|Prahova|Salaj|Satu-Mare|Sibiu|Suceava|Teleorman|Timis|Tulcea|Valcea|Vaslui|Vrancea)$");
            ////var Judet = "InvalidCounty";
            //if (regex.IsMatch(SalaEveniment.Judet))
            //{
            //    Console.WriteLine("Judetul este valid");
            //}
            //else
            //{
            //    Console.WriteLine("Judetul nu este valid. Vă rugăm să introduceți un județ valid din România.");
            //}


            // Se definește o funcție care verifică dacă județul este valid
            //function validareJudeț(Judet)
            //{
            //    // Lista cu județele valide
            //    var județeValide = ["Alba", "Arad", "Argeș", "Bacău", "Bihor", "Bistrița-Năsăud", "Botoșani", "Brașov", "Brăila", "Buzău", "Caraș-Severin", "Călărași", "Cluj", "Constanța", "Covasna", "Dâmbovița", "Dolj", "Galați", "Giurgiu", "Gorj", "Harghita", "Hunedoara", "Ialomița", "Iași", "Ilfov", "Maramureș", "Mehedinți", "Mureș", "Neamț", "Olt", "Prahova", "Satu Mare", "Sălaj", "Sibiu", "Suceava", "Teleorman", "Timiș", "Tulcea", "Vaslui", "Vâlcea", "Vrancea"];

            // Se verifică dacă județul este în lista cu județele valide
            //    if (județeValide.includes(Judet))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}

            //// Se obține valoarea introdusă în câmpul de județ
            //var Judet = document.getElementById("camp-Judet").value;

            //// Se verifică dacă județul este valid
            //if (validareJudeț(Judet))
            //{
            //    // Județul este valid, se poate continua cu procesarea formularului
            //}
            //else
            //{
            //    // Județul nu este valid, se afișează un mesaj de alertă
            //    alert("Județul introdus nu este un județ valid. Vă rugăm să introduceți un județ din lista cu județele valide.");
            //}


            _context.SalaEveniment.Add(SalaEveniment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

