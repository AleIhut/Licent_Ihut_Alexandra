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
using Microsoft.Extensions.Hosting;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Licent_Ihut_Alexandra.Pages.Hostess
{
    [Authorize(Roles = "Prestator")]
    public class EditModel : CuloriRochitaPageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public EditModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Hostes Hostes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hostes == null)
            {
                return NotFound();
            }

             //var hostes = await _context.Hostes
              Hostes = await _context.Hostes
                .Include(b => b.Judet)
                .Include(b => b.Localitate)
                //.Include(b => b.HostesCulori).ThenInclude(b => b.Culoare)
               // .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Hostes == null)
            {
                return NotFound();
            }

            //PopulateAssignedCuloareData(_context, Hostes);
            var userName = _userManager.GetUserName(User);
            var userEmail = User.Identity.Name;
            Hostes = Hostes;
            var localitati = _context.Localitate
                .Select(x => new
                {
                    x.ID,
                    localitateNume = x.Judet.Nume + "-" + x.NumeLocalitate
                })
                .OrderBy(x => x.localitateNume);
            var detaliiMembru = _context.Membru
               .Where(c => c.Email == userName)
               .Select(x => new
               {
                   x.ID,
                   DetaliiMembru = x.Nume
               });
            ViewData["JudetID"] = new SelectList(_context.Set<Judet>(), "ID", "Nume");

            ViewData["LocalitateID"] = new SelectList(localitati, "ID", "localitateNume");
            ViewData["MembruID"] = new SelectList(detaliiMembru, "ID", "DetaliiMembru");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
//int? id, string[] selectedCulori
            //if (id == null)
            //{
            //    return NotFound();
            //}

            byte[] bytes = null;
            if (Hostes.FisierImagine != null)
            {
                using (Stream fs = Hostes.FisierImagine.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }

                }
                Hostes.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }


            //var hostesToUpdate = await _context.Hostes
            //   .Include(i => i.Judet)
            //   .Include(i => i.Localitate)
            //.Include(i => i.HostesCulori)
            //.ThenInclude(i => i.Culoare)
            //.FirstOrDefaultAsync(s => s.ID == id);




            //if (hostesToUpdate == null)
            //{
            //    return NotFound();
            //}



            //if (await TryUpdateModelAsync<Hostes>(
            //hostesToUpdate,
            //"Hostes",
            //i => i.Nume, i => i.JudetID,
            //i => i.LocalitateID,  i => i.Telefon, i => i.Email, i => i.Descriere))

            //    i => i.JudetID,
            //i => i.LocalitateID, i => i.Imagine,

            //{
            //    UpdateHostesCulori(_context, selectedCulori, hostesToUpdate);

            //    await _context.SaveChangesAsync();

            //    return RedirectToPage("./Index");
            //}
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            //Console.WriteLine("UPDATE HOSTES");

            //UpdateHostesCulori(_context, selectedCulori, hostesToUpdate);
            //PopulateAssignedCuloareData(_context, hostesToUpdate);
            //return Page();

            //    if (!ModelState.IsValid)
            //    {
            //        return Page();
            //    }

            //    _context.Attach(Hostes).State = EntityState.Modified;

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!HostesExists(Hostes.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return RedirectToPage("./Index");
            //}

            //private bool HostesExists(int id)
            //{
            //    return _context.Hostes.Any(e => e.ID == id);
            //}

            _context.Attach(Hostes).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostesExists(Hostes.ID))
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
        private bool HostesExists(int id)
        {
            return _context.Hostes.Any(e => e.ID == id);
        }
    }
}



