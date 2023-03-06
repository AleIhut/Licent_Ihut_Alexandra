using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.Sonorizari
{
    public class DeleteModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DeleteModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Sonorizare Sonorizare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sonorizare == null)
            {
                return NotFound();
            }

            var sonorizare = await _context.Sonorizare.FirstOrDefaultAsync(m => m.ID == id);

            if (sonorizare == null)
            {
                return NotFound();
            }
            else 
            {
                Sonorizare = sonorizare;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sonorizare == null)
            {
                return NotFound();
            }
            var sonorizare = await _context.Sonorizare.FindAsync(id);

            if (sonorizare != null)
            {
                Sonorizare = sonorizare;
                _context.Sonorizare.Remove(Sonorizare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
