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
    public class IndexModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
       // public string Figurina { get; set; }
        //public string[] Figurine = new[] { "Da", "Nu" };
        public IList<Prajitura> Prajitura { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Prajitura = new List<Prajitura>();
            if (_context.Prajitura != null)
            {
                Prajitura = await _context.Prajitura
                //.Include(p => p.Figurine)
                .Include(p => p.Judet)
               .Include(p => p.Localitate)
                .ToListAsync();
            }
        }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            Prajitura = await _context.Prajitura.Include(b => b.Judet)
                .Where(x => x.Nume.Contains(searchString) || x.Judet.Nume.Contains(searchString)).ToListAsync();
        }
    }
}
