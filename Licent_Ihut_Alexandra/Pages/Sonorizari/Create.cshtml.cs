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
using Microsoft.AspNetCore.Identity;

namespace Licent_Ihut_Alexandra.Pages.Sonorizari
{ 
     [Authorize(Roles = "Prestator")]
    public class CreateModel : GenuriMuzicaleModel
    {
        
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        //private Sonorizare newSonorizare;
        private readonly UserManager<IdentityUser> _userManager;
       
        public CreateModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult OnGet()
        {
            var userName = _userManager.GetUserName(User);
            var userEmail = User.Identity.Name;
            var sonorizare = new Sonorizare();
            sonorizare.SonorizareGenuriMuzicale = new List<SonorizareGenMuzical>();
            PopulateGenMuzicalAsignat(_context, sonorizare);
            var detaliiMembru = _context.Membru
              .Where(c => c.Email == userName)
              .Select(x => new
              {
                  x.ID,
                  DetaliiMembru = x.Nume
              });
            ViewData["MembruID"] = new SelectList(detaliiMembru, "ID", "DetaliiMembru");
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
