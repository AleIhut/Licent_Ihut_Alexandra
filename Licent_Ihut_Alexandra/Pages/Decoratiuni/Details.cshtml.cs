using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.Decoratiuni
{
    public class DetailsModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DetailsModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

      public Decoratiune Decoratiune { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Decoratiune == null)
            {
                return NotFound();
            }

            var decoratiune = await _context.Decoratiune.FirstOrDefaultAsync(m => m.ID == id);
            if (decoratiune == null)
            {
                return NotFound();
            }
            else 
            {
                Decoratiune = decoratiune;
            }
            return Page();
        }
    }
}
