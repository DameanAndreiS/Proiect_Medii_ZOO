namespace Proiect_Medii_ZOO.Models
{
    public class AnimalDiet
    {
        public int ID { get; set; }
        public int AnimalID { get; set; }
        public Animal Animal { get; set; }
        public int DietID { get; set; }
        public Diet Diet { get; set; }
    }
}
