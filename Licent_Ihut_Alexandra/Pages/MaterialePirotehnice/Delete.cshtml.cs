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

namespace Licent_Ihut_Alexandra.Pages.MaterialePirotehnice
{
    [Authorize(Roles = "Prestator")]
    public class DeleteModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DeleteModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MaterialPirotehnic MaterialPirotehnic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MaterialPirotehnic == null)
            {
                return NotFound();
            }

            var materialpirotehnic = await _context.MaterialPirotehnic
                .Include(x => x.Judet)
                .Include(x => x.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (materialpirotehnic == null)
            {
                return NotFound();
            }
            else 
            {
                MaterialPirotehnic = materialpirotehnic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MaterialPirotehnic == null)
            {
                return NotFound();
            }
            var materialpirotehnic = await _context.MaterialPirotehnic.FindAsync(id);

            if (materialpirotehnic != null)
            {
                MaterialPirotehnic = materialpirotehnic;
                _context.MaterialPirotehnic.Remove(MaterialPirotehnic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
