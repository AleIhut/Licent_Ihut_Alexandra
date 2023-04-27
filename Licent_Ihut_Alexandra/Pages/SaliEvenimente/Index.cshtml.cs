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

        public async Task OnGetAsync()
        {/*bool? CeleAlese*/
            SalaEveniment = new List<SalaEveniment>();
            if (_context.SalaEveniment != null)
            {
                //var userEmail1 = User.Identity.Name;
                //var logareMembruId = _context.Membru.Where(c => c.Email == userEmail1).Select(c => c.ID).FirstOrDefault();
                 SalaEveniment = await  _context.SalaEveniment
                      .Include(b => b.Judet)
                       .Include(b => b.Localitate)
                       .Include(b => b.Membru)
                              .ToListAsync();
                //      .AsNoTracking();

                //if (CeleAlese != null && CeleAlese == true)
                //{
                //    salaEveniment = salaEveniment.Join(
                //        _context.SalaEvenimentAles1.Where(x => x.MembruID == logareMembruId),
                //        e => e.ID,
                //       f => f.SalaEvenimentID, (firstentity, secondentity) => new
                //       {
                //           SalaEveniment = firstentity,
                //           SalaEvenimentAles1 = secondentity
                //       }).Select(entity => entity.SalaEveniment);
                //}
                //SalaEveniment = await salaEveniment.ToListAsync();




                //var SalaAleasa = _context.SalaEvenimentAles1.Where(x => x.MembruID == logareMembruId).ToList();

                //for (int i = 0; i < SalaEveniment.Count(); i++)
                //{
                //    var SalaActuala = SalaEveniment.ElementAt(i);

                    //Aici verifica...Pt event urile din Db se seteaza valoarea pt Addedtofav ca sa seteze Add/Remove to fav
                    //SalaActuala.AdaugatLaAlese = SalaAleasa.Where(x => x.MembruID == logareMembruId &&
                    //  x.SalaEvenimentID == SalaActuala.ID
                    //).FirstOrDefault() != null;
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
        

         public async Task OnPostAsync() 
        //public IActionResult OnPost()
        {
            var searchString = Request.Form["searchString"];

            SalaEveniment = await _context.SalaEveniment
                 .Include(b => b.Judet)
                .Where(x => x.Nume.Contains(searchString) || x.Judet.Nume.Contains(searchString)).ToListAsync();



            //var userEmail1 = User.Identity.Name;
            //var logareMembruId = _context.Membru.Where(c => c.Email == userEmail1).Select(c => c.ID).FirstOrDefault();

            //var SalaID = Request.Form["SalaID"];
            //var EsteAdaugatLaAlese = Request.Form["EsteAdaugatLaAlese"];
            //var SalaIubita = new SalaEvenimentAles1();

            //SalaIubita.SalaEvenimentID = Int32.Parse(SalaID);
            //SalaIubita.MembruID = logareMembruId;

            //if (!bool.Parse(EsteAdaugatLaAlese))
            //{
            //    _context.SalaEvenimentAles1.Add(SalaIubita);
            //}
            //else
            //{
            //    _context.SalaEvenimentAles1.Remove(SalaIubita);

            //}

           // _context.SaveChanges();


           //return RedirectToPage("./Index");
         }
     
    }
}
