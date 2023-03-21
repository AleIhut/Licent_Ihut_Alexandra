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
    public class IndexModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<SalaEveniment> SalaEveniment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SalaEveniment = new List<SalaEveniment>();
            if (_context.SalaEveniment != null)
            {

                SalaEveniment = await _context.SalaEveniment
                    .Include(b=>b.Judet)
                     .Include(b => b.Localitate)
                    .ToListAsync();

            }
        }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            SalaEveniment = await _context.SalaEveniment
                 .Include(b => b.Judet)
                .Where(x => x.Nume.Contains(searchString) || x.Judet.Nume.Contains(searchString)).ToListAsync();
        }
    }
}
