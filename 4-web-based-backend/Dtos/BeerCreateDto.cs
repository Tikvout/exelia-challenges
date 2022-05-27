using System.ComponentModel.DataAnnotations;

namespace _4_web_based_backend.Dtos
{
    public class BeerCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
