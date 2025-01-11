using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_ZOO.Data;
using Proiect_Medii_ZOO.Models;

namespace Proiect_Medii_ZOO.Pages.Keepers
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext _context;

        public DetailsModel(Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext context)
        {
            _context = context;
        }

        public Keeper Keeper { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keeper = await _context.Keeper.FirstOrDefaultAsync(m => m.ID == id);
            if (keeper == null)
            {
                return NotFound();
            }
            else
            {
                Keeper = keeper;
            }
            return Page();
        }
    }
}
