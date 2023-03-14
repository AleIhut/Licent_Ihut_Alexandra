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
    public class IndexModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<MaterialPirotehnic> MaterialPirotehnic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MaterialPirotehnic != null)
            {
                MaterialPirotehnic = await _context.MaterialPirotehnic
                .Include(m => m.Judet)
                .Include(m => m.Localitate).ToListAsync();
            }
        }
    }
}
