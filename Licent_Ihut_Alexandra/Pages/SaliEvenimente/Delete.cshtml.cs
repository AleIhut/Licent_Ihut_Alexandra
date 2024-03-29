﻿using System;
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

namespace Licent_Ihut_Alexandra.Pages.SaliEvenimente
{
    [Authorize(Roles = "Prestator, Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DeleteModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SalaEveniment SalaEveniment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalaEveniment == null)
            {
                return NotFound();
            }

            var salaeveniment = await _context.SalaEveniment
                .Include(b => b.Judet)
                .Include(b => b.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (salaeveniment == null)
            {
                return NotFound();
            }
            else 
            {
                SalaEveniment = salaeveniment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SalaEveniment == null)
            {
                return NotFound();
            }
            var salaeveniment = await _context.SalaEveniment.FindAsync(id);

            if (salaeveniment != null)
            {
                SalaEveniment = salaeveniment;
                _context.SalaEveniment.Remove(SalaEveniment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
