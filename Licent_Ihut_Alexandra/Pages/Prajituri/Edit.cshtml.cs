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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Licent_Ihut_Alexandra.Pages.Prajituri
{
    [Authorize(Roles = "Prestator")]
    public class EditModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public EditModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }
        [BindProperty]

        public string Figurina { get; set; }
        public string[] Figurine = new[] { "da", "nu" };
        [BindProperty]
        public Prajitura Prajitura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prajitura == null)
            {
                return NotFound();
            }

            var prajitura =  await _context.Prajitura.FirstOrDefaultAsync(m => m.ID == id);
            if (prajitura == null)
            {
                return NotFound();
            }
            Prajitura = prajitura;
            var localitati = _context.Localitate
                 .Select(x => new
                 {
                     x.ID,
                     localitateNume = x.Judet.Nume + "-" + x.NumeLocalitate
                 })
                 .OrderBy(x => x.localitateNume);

            ViewData["JudetID"] = new SelectList(_context.Set<Judet>(), "ID", "Nume");

            ViewData["LocalitateID"] = new SelectList(localitati, "ID", "localitateNume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            byte[] bytes = null;
            if (Prajitura.FisierImagine != null)
            {
                using (Stream fs = Prajitura.FisierImagine.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }

                }
                Prajitura.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }
            _context.Attach(Prajitura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrajituraExists(Prajitura.ID))
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

        private bool PrajituraExists(int id)
        {
          return _context.Prajitura.Any(e => e.ID == id);
        }
    }
}
