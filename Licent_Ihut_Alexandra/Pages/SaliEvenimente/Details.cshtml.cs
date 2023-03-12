using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.SaliEvenimente
{
    public class DetailsModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DetailsModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

      public SalaEveniment SalaEveniment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalaEveniment == null)
            {
                return NotFound();
            }

            var salaeveniment = await _context.SalaEveniment
                .Include(b => b.Judet)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (salaeveniment == null)
            {
                return NotFound();
            }
            else 
            {
                SalaEveniment = salaeveniment;
            }
            return Page();
        }
    }
}
