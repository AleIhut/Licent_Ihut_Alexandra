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

namespace Licent_Ihut_Alexandra.Pages.MaterialePirotehnice
{
    [Authorize(Roles = "Prestator")]
    public class EditModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public EditModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaterialPirotehnic MaterialPirotehnic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MaterialPirotehnic == null)
            {
                return NotFound();
            }

            var materialpirotehnic =  await _context.MaterialPirotehnic
                .Include(x => x.Judet)
                .Include(x => x.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (materialpirotehnic == null)
            {
                return NotFound();
            }
            MaterialPirotehnic = materialpirotehnic;
            var localitati = _context.Localitate
                 .Select(x => new
                 {
                     x.ID,
                     localitateNume = x.Judet.Nume + "-" + x.NumeLocalitate
                 })
                 .OrderBy(x => x.localitateNume);

            ViewData["JudetID"] = new SelectList(_context.Set<Judet>(), "ID", "Nume");

            ViewData["LocalitateID"] = new SelectList(localitati, "ID", "localitateNume");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MaterialPirotehnic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialPirotehnicExists(MaterialPirotehnic.ID))
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

        private bool MaterialPirotehnicExists(int id)
        {
          return _context.MaterialPirotehnic.Any(e => e.ID == id);
        }
    }
}
