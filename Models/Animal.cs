using System.ComponentModel.DataAnnotations;

namespace Proiect_Medii_ZOO.Models
{
    public class Animal
    {
        public int ID { get; set; }
        [Display(Name = "Animal Species")]
        [StringLength(150, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        public int? KeeperID{ get; set; }
        [Display(Name = "Keeper")]
        public Keeper? Keeper {  get; set; }
        public int? EnclosureID{ get; set; }
        [Display(Name = "Enclosure")]
        public Enclosure? Enclosure { get; set; }
        [Display(Name = "Animal Diets")]
        public ICollection<AnimalDiet>? AnimalDiets { get; set; }
    }
}
