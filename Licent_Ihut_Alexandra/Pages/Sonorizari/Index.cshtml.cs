using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using System.Net;

namespace Licent_Ihut_Alexandra.Pages.Sonorizari
{
    public class IndexModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<Sonorizare> Sonorizare { get;set; } = default!;
        public SonorizareData SonorizareD { get; set; }
        public int SonorizareID { get; set; }
        public int GenMuzicalID { get; set; }

        public async Task OnGetAsync(int? id, int? GenMuzicalID)
        {
            SonorizareD = new SonorizareData();

            SonorizareD.Sonorizari = await _context.Sonorizare
             
                .Include(b => b.SonorizareGenuriMuzicale)
                .ThenInclude(b => b.GenMuzical)
                .AsNoTracking()
                .OrderBy(b => b.Nume)
                .ToListAsync();
            if (id != null) 
            { 
                SonorizareID = id.Value;
                Sonorizare sonorizare = SonorizareD.Sonorizari
                    .Where(i => i.ID == id.Value).Single(); 
                SonorizareD.GenuriMuzicale = sonorizare.SonorizareGenuriMuzicale.Select(s => s.GenMuzical);
            }

            //if (_context.Sonorizare != null)
            //{
            //    Sonorizare = await _context.Sonorizare.ToListAsync();
            //}
        }
    }
}
