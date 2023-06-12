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
   
    public class DeleteModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public DeleteModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PachetulMeu PachetulMeu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PachetulMeu == null)
            {
                return NotFound();
            }

            var pachetulmeu = await _context.PachetulMeu
                .Include(p => p.Artist)
                .Include(p => p.Decoratiune)
                .Include(p => p.Fotograf)
                .Include(p => p.Hostes)
                .Include(p => p.MaterialPirotehnic)
                .Include(p => p.Prajitura)
                .Include(p => p.SalaEveniment)
                .Include(p => p.Sonorizare)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (pachetulmeu == null)
            {
                return NotFound();
            }
            else 
            {
                PachetulMeu = pachetulmeu;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PachetulMeu == null)
            {
                return NotFound();
            }
            var pachetulmeu = await _context.PachetulMeu.FindAsync(id);

            if (pachetulmeu != null)
            {
                PachetulMeu = pachetulmeu;
              
                _context.PachetulMeu.Remove(PachetulMeu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
