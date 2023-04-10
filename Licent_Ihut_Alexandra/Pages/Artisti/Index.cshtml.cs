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
        private readonly string ADMIN_EMAIL = "ihutalexandra@yahoo.com";
        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<Artist> Artisti { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Artisti = new List<Artist>();
            if (_context.Artist != null)
            {
                Artisti = await _context.Artist
                    .Include(a => a.Membru)
                .Include(a => a.Judet)
                .Include(a => a.Localitate)
                .ToListAsync();
            }
            var userEmail = User.Identity.Name;
            var role = User.IsInRole("Admin"); // cum pot prelua rolul in variabila rol ????????????
            var role1 = User.IsInRole("User");
            var role2 = User.IsInRole("Prestator");

            if (userEmail != ADMIN_EMAIL)
            {
                if (role2 == true)
                {   /// prestator 
                    IList<Artist> filteredSali = new List<Artist>();
                    foreach (Artist art in Artisti)
                    {
                        if (art.Membru?.Email == userEmail)
                        {
                            filteredSali.Add(art);
                        }
                    }
                    Artisti = filteredSali;
                }
            }
        }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            Artisti = await _context.Artist
                .Include(b => b.Judet)
                .Where(x => x.Nume.Contains(searchString) || x.Judet.Nume.Contains(searchString)).ToListAsync();
        }
    }

}
