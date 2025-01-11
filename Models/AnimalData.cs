namespace Proiect_Medii_ZOO.Models
{
    public class AnimalData
    {
        public IEnumerable<Animal> Animals { get; set; }
        public IEnumerable<Diet> Diets { get; set; }
        public IEnumerable<AnimalDiet> AnimalDiets { get; set; }
    }
}
