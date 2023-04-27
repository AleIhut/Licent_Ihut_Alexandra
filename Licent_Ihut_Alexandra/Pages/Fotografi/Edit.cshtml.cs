using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace Licent_Ihut_Alexandra.Pages.Fotografi
{
    [Authorize(Roles = "Prestator")]
    public class EditModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        public EditModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Fotograf Fotograf { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fotograf == null)
            {
                return NotFound();
            }

            var fotograf =  await _context.Fotograf
                .Include(b => b.Judet)
                .Include(b => b.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fotograf == null)
            {
                return NotFound();
            }
            var userName = _userManager.GetUserName(User);
            var userEmail = User.Identity.Name; //email of the connected user
         //   int currentMembruID = _context.Membru.First(membru => membru.Email == userEmail).ID;
            Fotograf = fotograf;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
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
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Attach(Fotograf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotografExists(Fotograf.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FotografExists(int id)
        {
          return _context.Fotograf.Any(e => e.ID == id);
        }
    }
}
