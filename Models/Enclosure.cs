namespace Proiect_Medii_ZOO.Models
{
    public class Enclosure
    {
        public int ID { get; set; }
        public string EnclosureName { get; set; }
        public string Location { get; set; }
        public int Size { get; set; }

        public ICollection<Animal>? Animals { get; set; }
    }
}
