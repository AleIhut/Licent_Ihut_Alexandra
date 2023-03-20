using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.Prajituri
{
    public class DetailsModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DetailsModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

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
    }
}
