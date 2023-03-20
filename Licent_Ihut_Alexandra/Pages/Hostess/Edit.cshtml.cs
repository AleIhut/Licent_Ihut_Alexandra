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


namespace Licent_Ihut_Alexandra.Pages.Hostess
{
    public class EditModel : CuloriRochitaPageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public EditModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hostes Hostes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hostes == null)
            {
                return NotFound();
            }

             Hostes = await _context.Hostes
                .Include(b => b.Judet)
                .Include(b => b.Localitate)
                .Include(b => b.HostesCulori).ThenInclude(b => b.Culoare)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Hostes == null)
            {
                return NotFound();
            }

            PopulateAssignedCuloareData(_context, Hostes);
            Hostes = Hostes;
            ViewData["JudetID"] = new SelectList(_context.Set<Judet>(), "ID", "Nume");
            ViewData["LocalitateID"] = new SelectList(_context.Set<Localitate>(), "ID", "NumeLocalitate");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCulori)
        {

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
            //if (id == null)
            //{
            //    return NotFound();
            //}
            var hostesToUpdate = await _context.Hostes
                //.Include(i => i.Judet)
                //.Include(i => i.Localitate)
            .Include(i => i.HostesCulori)
            .ThenInclude(i => i.Culoare)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (hostesToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Hostes>(
            hostesToUpdate,
            "Hostes",
            i => i.ID, i => i.Nume, i => i.JudetID,
            i => i.LocalitateID, i => i.Imagine, i => i.Telefon, i => i.Email, i => i.Descriere))
            {
                UpdateHostesCulori(_context, selectedCulori, hostesToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateHostesCulori(_context, selectedCulori, hostesToUpdate);
            PopulateAssignedCuloareData(_context, hostesToUpdate);
            return Page();
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

        }
    }
}



