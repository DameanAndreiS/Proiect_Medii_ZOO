using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_ZOO.Data;
using Proiect_Medii_ZOO.Models;

namespace Proiect_Medii_ZOO.Pages.Animals
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext _context;

        public IndexModel(Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext context)
        {
            _context = context;
        }

        public IList<Animal> Animal { get;set; }
        public AnimalData AnimalD { get; set; }
        public int AnimalID { get; set; }
        public int DietID { get; set; }

        public string NameSort { get; set; }
        public string EnclosureSort { get; set; }
        public async Task OnGetAsync(int? id, int? dietID, string sortOrder)
        {
            AnimalD = new AnimalData();

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            EnclosureSort = sortOrder == "enclosure" ? "enclosure_desc" : "enclosure";

            AnimalD.Animals = await _context.Animal
                .Include(b => b.Keeper)
                .Include(b => b.Enclosure)
                .Include(b => b.AnimalDiets)
                .ThenInclude(b => b.Diet)
                .AsNoTracking()
                .OrderBy(b => b.Name)
                .ToListAsync();

            if (id != null)
            {
                AnimalID = id.Value;
                Animal animal = AnimalD.Animals
                    .Where(i => i.ID == id.Value).Single();
                AnimalD.Diets = animal.AnimalDiets.Select(s => s.Diet);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    AnimalD.Animals = AnimalD.Animals.OrderByDescending(s => s.Name);
                    break;
                case "enclosure_desc":
                    AnimalD.Animals = AnimalD.Animals.OrderByDescending(s => s.Enclosure.EnclosureName);
                    break;
                case "enclosure":
                    AnimalD.Animals = AnimalD.Animals.OrderBy(s => s.Enclosure.EnclosureName);
                    break;
                default:
                    AnimalD.Animals = AnimalD.Animals.OrderBy(s => s.Name);
                    break;
            }

        }
    }
}
