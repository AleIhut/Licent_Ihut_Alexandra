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

namespace Licent_Ihut_Alexandra.Pages.SaliEvenimente
{
    public class EditModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public EditModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalaEveniment SalaEveniment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalaEveniment == null)
            {
                return NotFound();
            }

            
            var salaeveniment = await _context.SalaEveniment.FirstOrDefaultAsync(m => m.ID == id);
            if (salaeveniment == null)
            {
                return NotFound();
            }
            SalaEveniment = salaeveniment;
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
            //byte[] bytes = null;
            //if (SalaEveniment.FisierImagine != null)
            //{
            //    using (Stream fs = SalaEveniment.FisierImagine.OpenReadStream())
            //    {
            //        using (BinaryReader br = new BinaryReader(fs))
            //        {
            //            bytes = br.ReadBytes((Int32)fs.Length);
            //        }

            //    }
            //    SalaEveniment.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            //}
            _context.Attach(SalaEveniment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaEvenimentExists(SalaEveniment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

           
        }

             private bool SalaEvenimentExists(int id)
            {
                return _context.SalaEveniment.Any(e => e.ID == id);
            }
        }
    }

