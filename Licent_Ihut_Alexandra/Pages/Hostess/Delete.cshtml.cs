using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Licent_Ihut_Alexandra.Pages.Hostess
{
    [Authorize(Roles = "Prestator, Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DeleteModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Hostes Hostes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hostes == null)
            {
                return NotFound();
            }

            var hostes = await _context.Hostes
                .Include(b => b.Judet)
                .Include(b => b.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (hostes == null)
            {
                return NotFound();
            }
            else 
            {
                Hostes = hostes;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hostes == null)
            {
                return NotFound();
            }
            var hostes = await _context.Hostes.FindAsync(id);

            if (hostes != null)
            {
                Hostes = hostes;
                _context.Hostes.Remove(Hostes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
