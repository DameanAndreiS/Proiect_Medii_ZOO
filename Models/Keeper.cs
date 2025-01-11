using System.ComponentModel.DataAnnotations;

namespace Proiect_Medii_ZOO.Models
{
    public class Keeper
    {
        public int ID { get; set; }
        [Display(Name = "Zoo Keeper")]
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string KeeperName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Animal>? Animals { get; set; }
    }
}
