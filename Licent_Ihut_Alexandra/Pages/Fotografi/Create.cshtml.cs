﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Licent_Ihut_Alexandra.Data;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Pages.Fotografi
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
        ViewData["JudetID"] = new SelectList(_context.Set<Judet>(), "ID", "Nume");
        ViewData["LocalitateID"] = new SelectList(_context.Set<Localitate>(), "ID", "NumeLocalitate");
            return Page();
        }

        [BindProperty]
        public Fotograf Fotograf { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid)
          //  {
          //      return Page();
          //  }
            byte[] bytes = null;
            if (Fotograf.FisierImagine != null)
            {
                using (Stream fs = Fotograf.FisierImagine.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }

                }
                Fotograf.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }

            _context.Fotograf.Add(Fotograf);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}