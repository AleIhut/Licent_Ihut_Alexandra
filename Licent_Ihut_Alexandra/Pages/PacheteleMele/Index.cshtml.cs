using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Licent_Ihut_Alexandra.Pages.PacheteleMele
{
    [Authorize(Roles = "User")]
    public class IndexModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        private readonly string ADMIN_EMAIL = "ihutalexandra@yahoo.com";

        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<PachetulMeu> PachetulMeu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PachetulMeu != null)
            {
                //PachetulMeu = await _context.PachetulMeu
                var pachetelemele = _context.PachetulMeu
                .Include(p => p.Artist)
                .Include(p => p.Decoratiune)
                .Include(p => p.Fotograf)
                .Include(p => p.Hostes)
                .Include(p => p.MaterialPirotehnic)
                .Include(p => p.Prajitura)
                .Include(p => p.SalaEveniment)
                .Include(p => p.Sonorizare)
                .Include(p => p.Membru)
                .AsNoTracking();
                

                var userEmail1 = User.Identity.Name; //preia user-u7l curent
                if (userEmail1 != ADMIN_EMAIL)
                { pachetelemele = pachetelemele.Where(pachet => pachet.Membru.Email == userEmail1);
                }
                PachetulMeu = await pachetelemele.ToListAsync();
                //var logareMembruID = _context.Membru.Where(c => c.Email == userEmail1).Select(c => c.ID).FirstOrDefault();
            }
        }
    }
}
