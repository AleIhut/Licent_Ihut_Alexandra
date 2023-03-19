using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.Culori
{
    public class DeleteModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DeleteModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Culoare Culoare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Culoare == null)
            {
                return NotFound();
            }

            var culoare = await _context.Culoare.FirstOrDefaultAsync(m => m.ID == id);

            if (culoare == null)
            {
                return NotFound();
            }
            else 
            {
                Culoare = culoare;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Culoare == null)
            {
                return NotFound();
            }
            var culoare = await _context.Culoare.FindAsync(id);

            if (culoare != null)
            {
                Culoare = culoare;
                _context.Culoare.Remove(Culoare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
