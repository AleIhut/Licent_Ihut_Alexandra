using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.MaterialePirotehnice
{
    public class DetailsModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DetailsModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

      public MaterialPirotehnic MaterialPirotehnic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MaterialPirotehnic == null)
            {
                return NotFound();
            }

            var materialpirotehnic = await _context.MaterialPirotehnic.FirstOrDefaultAsync(m => m.ID == id);
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
    }
}
