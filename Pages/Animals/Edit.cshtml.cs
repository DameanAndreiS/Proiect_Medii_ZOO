using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_ZOO.Data;
using Proiect_Medii_ZOO.Models;

namespace Proiect_Medii_ZOO.Pages.Animals
{
    [Authorize(Roles = "Admin")]
    public class EditModel : AnimalDietsPageModel
    {
        private readonly Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext _context;

        public EditModel(Proiect_Medii_ZOO.Data.Proiect_Medii_ZOOContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Animal = await _context.Animal
                            .Include(a => a.Keeper)
                            .Include(a => a.Enclosure)
                            .Include(a => a.AnimalDiets)
                            .ThenInclude(a => a.Diet)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.ID == id);

            if (Animal == null)
            {
                return NotFound();
            }

            PopulateAssignedDietData(_context, Animal);

           
           ViewData["KeeperID"] = new SelectList(_context.Keeper, "ID","KeeperName");
           ViewData["EnclosureID"] = new SelectList(_context.Enclosure, "ID", "EnclosureName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedDiets)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            var animalToUpdate = await _context.Animal
                .Include(a => a.Keeper)
                .Include(a => a.Enclosure)
                .Include(a => a.AnimalDiets)
                .ThenInclude(a => a.Diet)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (animalToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Animal>(
                animalToUpdate,
                "Animal",
                i => i.Name, i => i.EnclosureID, i => i.KeeperID))
            {
                UpdateAnimalDiets(_context, selectedDiets, animalToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateAnimalDiets(_context, selectedDiets, animalToUpdate);
            PopulateAssignedDietData(_context, animalToUpdate);
            return Page();
        }
    }
}
