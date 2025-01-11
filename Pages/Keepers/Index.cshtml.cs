using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_ZOO.Data;
using Proiect_Medii_ZOO.Models;
using Proiect_Medii_ZOO.Models.ViewModels;

namespace Proiect_Medii_ZOO.Pages.Keepers
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext _context;

        public IndexModel(Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext context)
        {
            _context = context;
        }

        public IList<Keeper> Keeper { get;set; } = default!;

        public KeeperIndexData KeeperData { get; set; }
        public int KeeperID { get; set; }
        public int AnimalID { get; set; }

        public async Task OnGetAsync(int? id, int? animalID)
        {

            KeeperData = new KeeperIndexData();
            KeeperData.Keepers = await _context.Keeper
                .Include(i => i.Animals)
                .ThenInclude(c => c.Enclosure)
                .OrderBy(i => i.KeeperName)
                .ToListAsync();
            if (id != null)
            {
                KeeperID = id.Value;
                Keeper keeper = KeeperData.Keepers
                    .Where(i => i.ID == id.Value).Single();
                KeeperData.Animals = keeper.Animals;
            }
            //Keeper = await _context.Keeper.ToListAsync();
        }
    }
}
