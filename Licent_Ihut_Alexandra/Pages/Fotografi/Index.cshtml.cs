using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.Data.SqlClient;

namespace Licent_Ihut_Alexandra.Pages.Fotografi
{
    public class IndexModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        private readonly string ADMIN_EMAIL = "ihutalexandra@yahoo.com";
        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<Fotograf> Fotografi { get; set; } = default!;

       

        public async Task OnGetAsync(/*string sortOrder*/)
        {
            Fotografi = new List<Fotograf>();
            //JudetSort = String.IsNullOrEmpty(sortOrder) ? "judet_desc" : "";
            if (_context.Fotograf != null)
            {
                //var searchString = Request.Form["searchString"];

                Fotografi = await _context.Fotograf
                .Include(f => f.Membru)
               .Include(f => f.Judet)
               .Include(f => f.Localitate)
             //  .Where(x => x.Nume.Contains(searchString))
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
                    IList<Fotograf> filteredSali = new List<Fotograf>();
                    foreach (Fotograf foto in Fotografi)
                    {
                        if (foto.Membru?.Email == userEmail)
                        {
                            filteredSali.Add(foto);
                        }
                    }
                    Fotografi = filteredSali;
                }
            }


            //switch (sortOrder)
            //{
            //    case "judet_desc":
            //       Fotograf = Fotograf.OrderByDescending(s => s.Judet);
            //        break;
            //}
        }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            Fotografi = await _context.Fotograf
                .Include(b => b.Judet)
                .Where(x => x.Nume.Contains(searchString) || x.Judet.Nume.Contains(searchString) ).ToListAsync();
        }
    }
}
