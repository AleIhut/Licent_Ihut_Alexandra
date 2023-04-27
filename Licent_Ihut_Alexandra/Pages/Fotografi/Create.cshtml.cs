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

namespace Licent_Ihut_Alexandra.Pages.Fotografi
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
            var userName = _userManager.GetUserName(User);
            var userEmail = User.Identity.Name; //email of the connected user
           
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
        public Fotograf Fotograf { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid)
          //  {
          //      return Page();
          //  }
            byte[] bytes = null;
            if (Fotograf.FisierImagine != null)
            {
                using (Stream fs = Fotograf.FisierImagine.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }

                }
                Fotograf.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }

            _context.Fotograf.Add(Fotograf);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
