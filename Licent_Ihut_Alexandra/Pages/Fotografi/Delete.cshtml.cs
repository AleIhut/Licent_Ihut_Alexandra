using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.Fotografi
{
    public class DeleteModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DeleteModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Fotograf Fotograf { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fotograf == null)
            {
                return NotFound();
            }

            var fotograf = await _context.Fotograf
                  .Include(b => b.Judet)
                 .Include(b => b.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (fotograf == null)
            {
                return NotFound();
            }
            else 
            {
                Fotograf = fotograf;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Fotograf == null)
            {
                return NotFound();
            }
            var fotograf = await _context.Fotograf.FindAsync(id);

            if (fotograf != null)
            {
                Fotograf = fotograf;
                _context.Fotograf.Remove(Fotograf);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
