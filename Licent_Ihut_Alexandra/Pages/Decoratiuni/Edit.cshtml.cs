﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Licent_Ihut_Alexandra.Pages.Decoratiuni
{
    [Authorize(Roles = "Prestator")]
    public class EditModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public EditModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Decoratiune Decoratiuni { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Decoratiune == null)
            {
                return NotFound();
            }

             Decoratiuni =  await _context.Decoratiune
                .Include(b => b.Material)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Decoratiuni == null)
            {
                return NotFound();
            }
            var userName = _userManager.GetUserName(User);
            var userEmail = User.Identity.Name; //email of the connected user
           // int currentMembruID = _context.Membru.First(membru => membru.Email == userEmail).ID;
            Decoratiuni = Decoratiuni;
            var detaliiMembru = _context.Membru
               .Where(c => c.Email == userName)
               .Select(x => new
               {
                   x.ID,
                   DetaliiMembru = x.Nume
               });
            ViewData["MaterialID"] = new SelectList(_context.Set<Material>(), "ID", "Tip");
            ViewData["MembruID"] = new SelectList(detaliiMembru, "ID", "DetaliiMembru");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Decoratiuni).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DecoratiuneExists(Decoratiuni.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DecoratiuneExists(int id)
        {
           
              
            return _context.Decoratiune.Any(e => e.ID == id);
        }
    }
}
