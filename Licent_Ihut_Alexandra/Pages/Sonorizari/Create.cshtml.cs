using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.AspNetCore.Authorization;

namespace Licent_Ihut_Alexandra.Pages.Sonorizari
{ 
     [Authorize(Roles = "Prestator")]
    public class CreateModel : GenuriMuzicaleModel
    {
        
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        //private Sonorizare newSonorizare;

        public CreateModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var userEmail = User.Identity.Name; //email of the connected user
            int currentMembruID = _context.Membru.First(membru => membru.Email == userEmail).ID;
            var sonorizare = new Sonorizare();
            sonorizare.SonorizareGenuriMuzicale = new List<SonorizareGenMuzical>();
            PopulateGenMuzicalAsignat(_context, sonorizare);
            ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "Nume", currentMembruID);
            return Page();
        }

        [BindProperty]
        public Sonorizare Sonorizare { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedGenuriMuzicale)
        {
            var newSonorizare = Sonorizare;
            if (selectedGenuriMuzicale != null)
            {
                newSonorizare.SonorizareGenuriMuzicale = new List<SonorizareGenMuzical>();
                foreach (var cat in selectedGenuriMuzicale)
                {
                    var catToAdd = new SonorizareGenMuzical
                    {
                        GenMuzicalID = int.Parse(cat)
                    };
                    newSonorizare.SonorizareGenuriMuzicale.Add(catToAdd);
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
