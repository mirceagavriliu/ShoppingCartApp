using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class CarForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        
        public int Stock { get; set; }

        public string ImagePath { get; set; }

    }
}