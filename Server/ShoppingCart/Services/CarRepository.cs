using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Entities;
using ShoppingCart.Models;

namespace ShoppingCart.Services
{
    public class CarRepository : ICarRepository
    {
        private CarContext _context;

        public CarRepository(CarContext context)
        {
            _context = context;
        }

        public Car GetCar(Guid carID)
        {
            return _context.Cars.FirstOrDefault(c => c.Id == carID);
        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.OrderBy(c => c.Name).ThenBy(c => c.Price);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }


        public void AddCar(Car car)
        {
            car.Id = Guid.NewGuid();
            _context.Cars.Add(car);
        }

        public bool CarExists(Guid carId)
        {
            return _context.Cars.Any(a => a.Id == carId);
        }

        public void DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
        }

        public void UpdateCar(Car car)
        {
           
        }
    }
}
