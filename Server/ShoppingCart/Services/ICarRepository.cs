using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        Car GetCar(Guid carID);
        void AddCar(Car car);
        bool CarExists(Guid carId);
        bool Save();
        void DeleteCar(Car car);
        void UpdateCar(Car car);
    }
}
