using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Licent_Ihut_Alexandra.Pages.Sonorizari
{
    [Authorize(Roles = "Prestator")]
    public class EditModel : GenuriMuzicaleModel
    {
       
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public EditModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sonorizare Sonorizare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sonorizare == null)
            {
                return NotFound();
            }

            Sonorizare =  await _context.Sonorizare
                .Include(b => b.SonorizareGenuriMuzicale).ThenInclude(b => b.GenMuzical)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Sonorizare == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulateGenMuzicalAsignat(_context, Sonorizare);
           Sonorizare = Sonorizare;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGenuriMuzicale)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonorizareToUpdate = await _context.Sonorizare
            .Include(i => i.SonorizareGenuriMuzicale)
            .ThenInclude(i => i.GenMuzical)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (sonorizareToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Sonorizare>(
            sonorizareToUpdate,
            "Sonorizare",
            i=> i.ID , i=>i.Nume,  i => i.Numar,
            i => i.Descriere ))
            {
                UpdateSonorizareGenuriMuzicale(_context, selectedGenuriMuzicale, sonorizareToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateSonorizareGenuriMuzicale(_context, selectedGenuriMuzicale, sonorizareToUpdate);
            PopulateGenMuzicalAsignat(_context, sonorizareToUpdate);
            return Page();

            // if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Sonorizare).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!SonorizareExists(Sonorizare.ID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");
        }

        //private bool SonorizareExists(int id)
        //{
        //  return _context.Sonorizare.Any(e => e.ID == id);
        //}
    }
}
