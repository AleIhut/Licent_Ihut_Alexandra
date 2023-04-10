using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.Hostess
{
    public class IndexModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        private readonly string ADMIN_EMAIL = "ihutalexandra@yahoo.com";
        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<Hostes> Hostess { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Hostess = new List<Hostes>();
            if (_context.Hostes != null)
            {
                Hostess = await _context.Hostes
                .Include(x => x.Membru)
                .Include(x => x.Judet)
                .Include(x => x.Localitate)
                .ToListAsync();
            }
            var userEmail = User.Identity.Name;
            var role = User.IsInRole("Admin"); // cum pot prelua rolul in variabila rol ????????????
            var role1 = User.IsInRole("User");
            var role2 = User.IsInRole("Prestator");

            if (userEmail != ADMIN_EMAIL)
            {

                //SaliDeEvenimente =  SaliDeEvenimente.Where(sala => sala.Membru?.Email == userEmail);
                //SalaEveniment = SalaEveniment.Where(sala => sala.Membru?.Email == userEmail);
                //    //SalaEveniment = (IList<SalaEveniment>)SalaEveniment.Where(b => b.Membru?.Email == userEmail);
                //    //SalaEveniment = (IList<SalaEveniment>)SalaEveniment.Where(SalaEveniment => SalaEveniment.Membru?.Email == userEmail);
                if (role2 == true)
                {   /// prestator 
                    IList<Hostes> filteredSali = new List<Hostes>();
                    foreach (Hostes host in Hostess)
                    {
                        if (host.Membru?.Email == userEmail)
                        {
                            filteredSali.Add(host);
                        }
                    }
                    Hostess = filteredSali;
                }
            }

        }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            Hostess = await _context.Hostes
                .Include(b => b.Judet)

                .Where(x => x.Nume.Contains(searchString) || x.Judet.Nume.Contains(searchString)).ToListAsync();
        }
    }
}
