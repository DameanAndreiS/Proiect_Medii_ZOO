using System.ComponentModel.DataAnnotations;

namespace Proiect_Medii_ZOO.Models
{
    public class Keeper
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
"Numele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau Ana-Maria")]
        [Display(Name = "Zoo Keeper")]
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string KeeperName { get; set; }
        [Display(Name = "Phone Number")]
        [StringLength(10, MinimumLength = 10),]
        public string PhoneNumber { get; set; }
        public ICollection<Animal>? Animals { get; set; }
    }
}
