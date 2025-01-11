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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext _context;

        public IndexModel(Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext context)
        {
            _context = context;
        }

        public IList<Diet> Diet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Diet = await _context.Diet.ToListAsync();
        }
    }
}
