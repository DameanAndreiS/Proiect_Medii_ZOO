using System.ComponentModel.DataAnnotations;

namespace Proiect_Medii_ZOO.Models
{
    public class Diet
    {
        public int ID { get; set; }
        [Display(Name = "Diet Name")]
        public string DietName { get; set; }
        public ICollection<AnimalDiet>? AnimalDiets { get; set; }
    }
}
