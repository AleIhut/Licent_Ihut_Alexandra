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
        private readonly string ADMIN_EMAIL = "ihutalexandra@yahoo.com";
        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<MaterialPirotehnic> MaterialePirotehnice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MaterialePirotehnice = new List<MaterialPirotehnic>();
            if (_context.MaterialPirotehnic != null)
            {
                MaterialePirotehnice = await _context.MaterialPirotehnic
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
                    IList<MaterialPirotehnic> filteredSali = new List<MaterialPirotehnic>();
                    foreach (MaterialPirotehnic mate in MaterialePirotehnice)
                    {
                        if (mate.Membru?.Email == userEmail)
                        {
                            filteredSali.Add(mate);
                        }
                    }
                    MaterialePirotehnice = filteredSali;
                }
            }

        }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            MaterialePirotehnice = await _context.MaterialPirotehnic
                .Include(b => b.Judet)
                .Include(b => b.Localitate)
                .Where(x => x.Nume.Contains(searchString) || x.Judet.Nume.Contains(searchString)).ToListAsync();
        }
    }
}
