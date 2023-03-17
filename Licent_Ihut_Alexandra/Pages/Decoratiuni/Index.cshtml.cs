﻿using System;
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

        public IndexModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IList<Decoratiune> Decoratiune { get;set; } = default!;
       

        public async Task OnGetAsync( )
        {
            

           
            if (_context.Decoratiune != null)
            {
                Decoratiune = await _context.Decoratiune
                .Include(d => d.Material)
                .ToListAsync();
            }
          
            }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            Decoratiune = await _context.Decoratiune
                .Where(x => x.Companie.Contains(searchString) ).ToListAsync();
        }
    }
}
