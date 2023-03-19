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
    public class DetailsModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DetailsModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

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
    }
}
