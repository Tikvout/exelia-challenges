using System.ComponentModel.DataAnnotations;

namespace Beverage.Dtos
{
    public class BeerCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
