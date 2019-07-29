using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }

        public string ImagePath { get; set; }

        public int Stock { get; set; }



    }
}
