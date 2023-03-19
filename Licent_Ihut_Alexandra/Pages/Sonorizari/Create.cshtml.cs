using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.Sonorizari
{
    public class CreateModel : GenuriMuzicaleModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        private Sonorizare newSonorizare;

        public CreateModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var sonorizare = new Sonorizare();
            sonorizare.SonorizareGenuriMuzicale = new List<SonorizareGenMuzical>();
            PopulateGenMuzicalAsignat(_context, sonorizare);
            return Page();
        }

        [BindProperty]
        public Sonorizare Sonorizare { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedGenuriMuzicale)
        {
            var newBook = Sonorizare;
            if (selectedGenuriMuzicale != null)
            {
                newBook.SonorizareGenuriMuzicale = new List<SonorizareGenMuzical>();
                foreach (var cat in selectedGenuriMuzicale)
                {
                    var catToAdd = new SonorizareGenMuzical
                    {
                        GenMuzicalID = int.Parse(cat)
                    };
                    newBook.SonorizareGenuriMuzicale.Add(catToAdd);
                }
            }

           
            _context.Sonorizare.Add(Sonorizare);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateGenMuzicalAsignat(_context, newSonorizare);
            return Page();


            //// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
            //public async Task<IActionResult> OnPostAsync()
            //{
            //  if (!ModelState.IsValid)
            //    {
            //        return Page();
            //    }

            //    _context.Sonorizare.Add(Sonorizare);
            //    await _context.SaveChangesAsync();

            //    return RedirectToPage("./Index");
            //}
        }
    }
}
