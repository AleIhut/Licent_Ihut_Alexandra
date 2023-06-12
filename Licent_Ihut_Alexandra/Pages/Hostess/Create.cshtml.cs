using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace Licent_Ihut_Alexandra.Pages.Hostess
{
    [Authorize(Roles = "Prestator")]
    public class CreateModel : CuloriRochitaPageModel
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
            var userName = _userManager.GetUserName(User);
            var userEmail = User.Identity.Name;
            var hostes = new Hostes(); 
            hostes.HostesCulori = new List<HostesCuloare>();
            PopulateAssignedCuloareData(_context, hostes);
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
        public Hostes Hostes { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCulori)
        {
            byte[] bytes = null;
            if (Hostes.FisierImagine != null)
            {
                using (Stream fs = Hostes.FisierImagine.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }

                }
                Hostes.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Hostes.Add(Hostes);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");

            var newHostes =  Hostes;
            if (selectedCulori != null)
            {
                newHostes.HostesCulori = new List<HostesCuloare>();
                foreach (var cat in selectedCulori)
                {
                    var catToAdd = new HostesCuloare
                    {
                        CuloareID = int.Parse(cat)
                    };
                    newHostes.HostesCulori.Add(catToAdd);
                }
            }

           // if (await TryUpdateModelAsync<Hostes>(
           //newHostes,
           //"Hostes",
           //i => i.ID, i => i.Nume, i => i.Judet,
           //i => i.Localitate, i => i.Imagine, i => i.Telefon, i => i.Email, i => i.Descriere))
           // {
                _context.Hostes.Add(newHostes);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            
            PopulateAssignedCuloareData(_context, newHostes);
            return Page();
        }
    }
}
