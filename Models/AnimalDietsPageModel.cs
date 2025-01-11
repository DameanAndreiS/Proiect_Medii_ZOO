using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Medii_ZOO.Data;
namespace Proiect_Medii_ZOO.Models
{
    public class AnimalDietsPageModel : PageModel
    {
        public List<AssignedDietData> AssignedDietDataList;
        public void PopulateAssignedDietData(Proiect_Medii_ZOOContext context,
        Animal animal)
        {
            var allDiets = context.Diet;
            var animalDiets = new HashSet<int>(
            animal.AnimalDiets.Select(c => c.DietID)); //
            AssignedDietDataList = new List<AssignedDietData>();
            foreach (var die in allDiets)
            {
                AssignedDietDataList.Add(new AssignedDietData
                {
                    DietID = die.ID,
                    Name = die.DietName,
                    Assigned = animalDiets.Contains(die.ID)
                });
            }
        }
        public void UpdateAnimalDiets(Proiect_Medii_ZOOContext context,
        string[] selectedDiets, Animal animalToUpdate)
        {
            if (selectedDiets == null)
            {
                animalToUpdate.AnimalDiets = new List<AnimalDiet>();
                return;
            }
            var selectedDietsHS = new HashSet<string>(selectedDiets);
            var animalDiets = new HashSet<int>
            (animalToUpdate.AnimalDiets.Select(c => c.Diet.ID));
            foreach (var die in context.Diet)
            {
                if (selectedDietsHS.Contains(die.ID.ToString()))
                {
                    if (!animalDiets.Contains(die.ID))
                    {
                        animalToUpdate.AnimalDiets.Add(
                        new AnimalDiet
                        {
                            AnimalID = animalToUpdate.ID,
                            DietID = die.ID
                        });
                    }
                }
                else
                {
                    if (animalDiets.Contains(die.ID))
                    {
                        AnimalDiet animalToRemove
                        = animalToUpdate
                        .AnimalDiets
                       .SingleOrDefault(i => i.DietID == die.ID);
                        context.Remove(animalToRemove);
                    }
                }
            }
        }
    }
}