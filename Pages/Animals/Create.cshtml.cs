using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Medii_ZOO.Data;
using Proiect_Medii_ZOO.Models;

namespace Proiect_Medii_ZOO.Pages.Animals
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : AnimalDietsPageModel
    {
        private readonly Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext _context;

        public CreateModel(Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["KeeperID"] = new SelectList(_context.Keeper, "ID", "KeeperName");
            ViewData["EnclosureID"] = new SelectList(_context.Enclosure, "ID", "EnclosureName");
            var animal = new Animal();
            animal.AnimalDiets = new List<AnimalDiet>();
            PopulateAssignedDietData(_context, animal);
            
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(string[] selectedDiets)
        {

            var newAnimal = new Animal();
            if (selectedDiets != null)
            {
                newAnimal.AnimalDiets = new List<AnimalDiet>();
                foreach (var die in selectedDiets)
                {
                    var dieToAdd = new AnimalDiet
                    {
                        DietID = int.Parse(die)
                    };
                    newAnimal.AnimalDiets.Add( dieToAdd );
                }
            }

            Animal.AnimalDiets = newAnimal.AnimalDiets;
            _context.Animal.Add(Animal);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

           
        }
    }
}
