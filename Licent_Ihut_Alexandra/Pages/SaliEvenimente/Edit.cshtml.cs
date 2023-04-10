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
using Microsoft.AspNetCore.Identity;

namespace Licent_Ihut_Alexandra.Pages.SaliEvenimente
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
        public SalaEveniment SalaEveniment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalaEveniment == null)
            {
                return NotFound();
            }

            
             SalaEveniment = await _context.SalaEveniment
                .Include(b => b.Judet)
                .Include(b => b.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);
              //  .Include(b => b.Judet)
                
            if (SalaEveniment == null)
            {
                return NotFound();
            }
            //aceste 2 linii sunt pt ca fiecare sala sa fie pentru prestatorul ei
            //var userEmail = User.Identity.Name; //email of the connected user
            //int currentMembruID = _context.Membru.First(membru => membru.Email == userEmail).ID;
            SalaEveniment = SalaEveniment;
            var localitati = _context.Localitate
               .Select(x => new
               {
                   x.ID,
                   localitateNume = x.Judet.Nume + "-" + x.NumeLocalitate
               })
               .OrderBy(x => x.localitateNume);

            ViewData["JudetID"] = new SelectList(_context.Set<Judet>(), "ID", "Nume");

            ViewData["LocalitateID"] = new SelectList(localitati, "ID", "localitateNume");
            //ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "Nume", currentMembruID);




            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync( )
        {

            byte[] bytes = null;
            if (SalaEveniment.FisierImagine != null)
            {
                using (Stream fs = SalaEveniment.FisierImagine.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }

                }
                SalaEveniment.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            
            _context.Attach(SalaEveniment).State = EntityState.Modified;
           // var userEmail = User.Identity.Name;

            //if (userEmail == SalaEveniment.Membru?.Email) { 
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
           // }
           /* else
            {
                ///alert 
            }*/

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