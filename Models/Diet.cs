namespace Proiect_Medii_ZOO.Models
{
    public class Diet
    {
        public int ID { get; set; }
        public string DietName { get; set; }
        public ICollection<AnimalDiet>? AnimalDiets { get; set; }
    }
}
