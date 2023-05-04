using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Licent_Ihut_Alexandra.Pages.SaliEvenimente
{
    public class IndexModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        private readonly string ADMIN_EMAIL = "ihutalexandra@yahoo.com";

        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<SalaEveniment> SalaEveniment { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Cautare2 { get; set; }

        [BindProperty(SupportsGet = true)]

        public string? Cautare1 { get; set; }
        public async Task OnGetAsync(bool? CeleAlese)
        {
            SalaEveniment = new List<SalaEveniment>();
            if (_context.SalaEveniment != null)
            {
                var userEmail1 = User.Identity.Name;
                var logareMembruID = _context.Membru.Where(c => c.Email == userEmail1).Select(c => c.ID).FirstOrDefault();
                var salaEvenimente = _context.SalaEveniment
                       .Include(b => b.Judet)
                        .Include(b => b.Localitate)
                        .Include(b => b.Membru)

                        .AsNoTracking();
                if (CeleAlese != null && CeleAlese == true)
                {
                    salaEvenimente = salaEvenimente.Join(
                        _context.SalaEvenimentAles.Where(x => x.MembruID == logareMembruID),
                        e => e.ID,
                       f => f.SalaEvenimentID, (firstentity, secondentity) => new
                       {
                           SalaEveniment = firstentity,
                           SalaEvenimentAles = secondentity
                       }).Select(entity => entity.SalaEveniment);

                }
                //pt search
                if (!String.IsNullOrEmpty(SearchString))
                {
                    salaEvenimente = salaEvenimente.Where(s => s.Judet.Nume.Contains(SearchString)
                    ||
                    s.Nume.Contains(SearchString)

                    );
                }
                SalaEveniment = await salaEvenimente.ToListAsync();

                var SalaPreferata = _context.SalaEvenimentAles.Where(x => x.MembruID == logareMembruID).ToList();

                for (int i = 0; i < SalaEveniment.Count(); i++)
                {
                    var SalaActuala = SalaEveniment.ElementAt(i);

                   
                    SalaActuala.AdaugatLaAlese = SalaPreferata.Where(x => x.MembruID == logareMembruID &&
                      x.SalaEvenimentID == SalaActuala.ID
                    ).FirstOrDefault() != null;
                }




            }

               var userEmail = User.Identity.Name;
            var role = User.IsInRole("Admin"); // cum pot prelua rolul in variabila rol ????????????
            var role1 = User.IsInRole("User");
            var role2 = User.IsInRole("Prestator");

            if (userEmail != ADMIN_EMAIL)
            {

                //SalaEveniment =  SalaEveniment.Where(sala => sala.Membru?.Email == userEmail);
                //SalaEveniment = SalaEveniment.Where(sala => sala.Membru?.Email == userEmail);
                //    //SalaEveniment = (IList<SalaEveniment>)SalaEveniment.Where(b => b.Membru?.Email == userEmail);
                //    //SalaEveniment = (IList<SalaEveniment>)SalaEveniment.Where(SalaEveniment => SalaEveniment.Membru?.Email == userEmail);
                if (role2 == true) {   /// prestator 
                    IList<SalaEveniment> filteredSali = new List<SalaEveniment>();
                    foreach (SalaEveniment sala in SalaEveniment)
                    {
                        if (sala.Membru?.Email == userEmail)
                        {
                            filteredSali.Add(sala);
                        }
                    }
                    SalaEveniment = filteredSali;
                }
            }
           
            }
        
           public IActionResult OnPost()
        {
            var userEmail1 = User.Identity.Name;
            var logareMembruId = _context.Membru.Where(c => c.Email == userEmail1).Select(c => c.ID).FirstOrDefault();

            var SalaID = Request.Form["SalaID"];
            var EsteAdaugatLaAlese = Request.Form["EsteAdaugatLaAlese"];
            var SalaIubita = new SalaEvenimentAles();

            SalaIubita.SalaEvenimentID = Int32.Parse(SalaID);
            SalaIubita.MembruID = logareMembruId;

            if (!bool.Parse(EsteAdaugatLaAlese))
            {
                _context.SalaEvenimentAles.Add(SalaIubita);
            }
            else
            {
                _context.SalaEvenimentAles.Remove(SalaIubita);

            }

            _context.SaveChanges();


            return RedirectToPage("./Index");

        }
        // public async Task OnPostAsync() 

        //{
        //    var searchString = Request.Form["searchString"];

        //    SalaEveniment = await _context.SalaEveniment
        //         .Include(b => b.Judet)
        //        .Where(x => x.Nume.Contains(searchString) || x.Judet.Nume.Contains(searchString)).ToListAsync();




        // }

    }
}
