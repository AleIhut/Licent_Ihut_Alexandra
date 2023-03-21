using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.Artisti
{
    public class IndexModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Artist = new List<Artist>();
            if (_context.Artist != null)
            {
                Artist = await _context.Artist
                .Include(a => a.Judet)
                .Include(a => a.Localitate)
                .ToListAsync();
            }
        }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            Artist = await _context.Artist
                .Include(b => b.Judet)
                .Where(x => x.Nume.Contains(searchString) || x.Judet.Nume.Contains(searchString)).ToListAsync();
        }
    }

}
