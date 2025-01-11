using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_ZOO.Data;
using Proiect_Medii_ZOO.Models;

namespace Proiect_Medii_ZOO.Pages.Diets
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext _context;

        public DetailsModel(Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext context)
        {
            _context = context;
        }

        public Diet Diet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diet = await _context.Diet.FirstOrDefaultAsync(m => m.ID == id);
            if (diet == null)
            {
                return NotFound();
            }
            else
            {
                Diet = diet;
            }
            return Page();
        }
    }
}
