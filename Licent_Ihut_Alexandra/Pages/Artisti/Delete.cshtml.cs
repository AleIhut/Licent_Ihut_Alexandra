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

namespace Licent_Ihut_Alexandra.Pages.Artisti
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
      public Artist Artist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Artist == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist
                .Include(b => b.Judet)
                .Include(b => b.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (artist == null)
            {
                return NotFound();
            }
            else 
            {
                Artist = artist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Artist == null)
            {
                return NotFound();
            }
            var artist = await _context.Artist.FindAsync(id);

            if (artist != null)
            {
                Artist = artist;
                _context.Artist.Remove(Artist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
