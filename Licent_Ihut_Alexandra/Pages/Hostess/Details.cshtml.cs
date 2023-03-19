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

namespace Licent_Ihut_Alexandra.Pages.Hostess
{
    public class DetailsModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DetailsModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

      public Hostes Hostes { get; set; }

        public HostesData HostesD { get; set; }
        public int HostesID { get; set; }
        public int CuloareID { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hostes == null)
            {
                return NotFound();
            }

            var hostes = await _context.Hostes
                .Include(x => x.Judet)
                .Include(x => x.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hostes == null)
            {
                return NotFound();
            }
            else
            {
                Hostes = hostes;
            }
            return Page();
        }

        //public async Task OnGetAsync(int? id, int? culoarerID)
        //{
        //    HostesD = new HostesData();
        //    HostesD.Hostess = await _context.Hostes
        //        .Include(x => x.Judet)
        //        .Include(x => x.Localitate)
        //        .Include(b => b.HostesCulori).ThenInclude(b => b.Culoare)
        //        .AsNoTracking()
        //        .ToListAsync();
        //    if (id != null)
        //    {
        //        HostesID = id.Value;
        //        Hostes hostes = HostesD.Hostess
        //            .Where(i => i.ID == id.Value).Single();
        //        HostesD.Culori = hostes.HostesCulori
        //            .Select(s => s.Category); }
        //}
    }

}
