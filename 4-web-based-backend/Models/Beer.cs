using System.ComponentModel.DataAnnotations;

namespace _4_web_based_backend.Models
{
    public class Beer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
