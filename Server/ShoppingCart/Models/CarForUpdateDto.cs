using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class CarForUpdateDto
    {

        [MaxLength(100)]
        public string Name { get; set; }
        
        public double Price { get; set; }

        public int Stock { get; set; }

        public string ImagePath { get; set; }

    }
}