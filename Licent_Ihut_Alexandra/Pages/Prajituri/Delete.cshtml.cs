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

namespace Licent_Ihut_Alexandra.Pages.Prajituri
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
      public Prajitura Prajitura { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prajitura == null)
            {
                return NotFound();
            }

            var prajitura = await _context.Prajitura
              .Include(b => b.Judet)
                .Include(b => b.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (prajitura == null)
            {
                return NotFound();
            }
            else 
            {
                Prajitura = prajitura;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Prajitura == null)
            {
                return NotFound();
            }
            var prajitura = await _context.Prajitura.FindAsync(id);

            if (prajitura != null)
            {
                Prajitura = prajitura;
                _context.Prajitura.Remove(Prajitura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
