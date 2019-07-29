using Microsoft.EntityFrameworkCore;
using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class CarContext: DbContext
    {
        public CarContext(DbContextOptions<CarContext> options): base(options)
        {
            Database.Migrate();
        }
        public DbSet<Car> Cars { get; set; }
    }
}
