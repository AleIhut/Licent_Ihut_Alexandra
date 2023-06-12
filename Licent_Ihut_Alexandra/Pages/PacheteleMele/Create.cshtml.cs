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

namespace Licent_Ihut_Alexandra.Pages.PacheteleMele
{
    [Authorize(Roles = "User")]
    public class CreateModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            // urm 2 linii pentru client - aia sa apara evenimentele fiecarui client in parte si adminul sa le vada pe toate
            var userEmail = User.Identity.Name; //email of the connected user
            int currenrMembruID = _context.Membru.First(client => client.Email == userEmail).ID;

            var userName = _userManager.GetUserName(User);
            //var userEmail = User.Identity.Name;
            var detaliiMembru = _context.Membru
               .Where(c => c.Email == userName)
               .Select(x => new
               {
                   x.ID,
                   DetaliiMembru = x.Nume
               });
           
            ViewData["ArtistID"] = new SelectList(_context.Artist.Select(a => new { a.ID, NumeTelefon = a.Nume + "-" + a.Telefon }), "ID", "NumeTelefon");
            ViewData["DecoratiuneID"] = new SelectList(_context.Decoratiune.Select(a => new { a.ID, NumeTelefon = a.Companie + "-" + a.Telefon }), "ID", "NumeTelefon");
            ViewData["FotografID"] = new SelectList(_context.Fotograf.Select(a => new { a.ID, NumeTelefon = a.Nume + "-" + a.Telefon }), "ID", "NumeTelefon");
            ViewData["HostesID"] = new SelectList(_context.Hostes.Select(a => new { a.ID, NumeTelefon = a.Nume + "-" + a.Telefon }), "ID", "NumeTelefon");
            ViewData["MaterialPirotehnicID"] = new SelectList(_context.MaterialPirotehnic.Select(a => new { a.ID, NumeTelefon = a.Nume + "-" + a.Telefon }), "ID", "NumeTelefon");
            ViewData["PrajituraID"] = new SelectList(_context.Prajitura.Select(a => new { a.ID, NumeTelefon = a.Nume + "-" + a.Telefon }), "ID", "NumeTelefon");
            ViewData["SalaEvenimentID"] = new SelectList(_context.SalaEveniment.Select(a => new { a.ID, NumeTelefon = a.Nume + "-" + a.Telefon }), "ID", "NumeTelefon");
            ViewData["SonorizareID"] = new SelectList(_context.Sonorizare.Select(a => new { a.ID, NumeTelefon = a.Nume + "-" + a.Numar }), "ID", "NumeTelefon");

           
            ViewData["MembruID"] = new SelectList(detaliiMembru, "ID", "DetaliiMembru", currenrMembruID);
            return Page();
        }

        [BindProperty]
        public PachetulMeu PachetulMeu { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PachetulMeu == null || PachetulMeu == null)
            {
                return Page();
            }

            _context.PachetulMeu.Add(PachetulMeu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
