using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_ZOO.Data;
using Proiect_Medii_ZOO.Models;

namespace Proiect_Medii_ZOO.Pages.Enclosures
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext _context;

        public DeleteModel(Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enclosure Enclosure { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosure.FirstOrDefaultAsync(m => m.ID == id);

            if (enclosure == null)
            {
                return NotFound();
            }
            else
            {
                Enclosure = enclosure;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosure.FindAsync(id);
            if (enclosure != null)
            {
                Enclosure = enclosure;
                _context.Enclosure.Remove(Enclosure);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
