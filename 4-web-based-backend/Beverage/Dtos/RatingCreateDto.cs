using Beverage.Models;
using System.ComponentModel.DataAnnotations;

namespace Beverage.Dtos
{
    public class RatingCreateDto
    {
        [Required]
        public int Score { get; set; }
        [Required]
        public int BeerId { get; set; }
    }
}
