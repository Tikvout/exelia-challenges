using System.ComponentModel.DataAnnotations;

namespace Beverage.Models
{
    public class Beer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        // Navigation Properties
        public List<Rating> Ratings { get; set; }
    }
}
