using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.GenuriMuzicale
{
    public class DeleteModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DeleteModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
      public GenMuzical GenMuzical { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GenMuzical == null)
            {
                return NotFound();
            }

            var genmuzical = await _context.GenMuzical.FirstOrDefaultAsync(m => m.ID == id);

            if (genmuzical == null)
            {
                return NotFound();
            }
            else 
            {
                GenMuzical = genmuzical;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.GenMuzical == null)
            {
                return NotFound();
            }
            var genmuzical = await _context.GenMuzical.FindAsync(id);

            if (genmuzical != null)
            {
                GenMuzical = genmuzical;
                _context.GenMuzical.Remove(GenMuzical);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
