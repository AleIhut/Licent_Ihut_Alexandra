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

namespace Licent_Ihut_Alexandra.Pages.Decoratiuni
{
    public class IndexModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        private readonly string ADMIN_EMAIL = "ihutalexandra@yahoo.com";
        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<Decoratiune> Decoratiuni { get;set; } = default!;
       

        public async Task OnGetAsync( )
        {
            

           
            if (_context.Decoratiune != null)
            {
                Decoratiuni = await _context.Decoratiune
                 .Include(d => d.Membru)
                .Include(d => d.Material)
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
                    IList<Decoratiune> filteredSali = new List<Decoratiune>();
                    foreach (Decoratiune deco in Decoratiuni)
                    {
                        if (deco.Membru?.Email == userEmail)
                        {
                            filteredSali.Add(deco);
                        }
                    }
                    Decoratiuni = filteredSali;
                }
            }

        }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            Decoratiuni = await _context.Decoratiune
               
                .Where(x => x.Companie.Contains(searchString) ).ToListAsync();
        }
    }
}
