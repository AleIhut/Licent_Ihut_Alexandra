using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;
using Microsoft.CodeAnalysis;


namespace Licent_Ihut_Alexandra.Pages.SaliEvenimente
{
    public class CreateModel : PageModel
    {
        private readonly Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext _context;

        public CreateModel(Licent_Ihut_Alexandra.Data.Licent_Ihut_AlexandraContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SalaEveniment SalaEveniment { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
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
                //  {
                //      return Page();
                //  }

                _context.SalaEveniment.Add(SalaEveniment);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }
    }

