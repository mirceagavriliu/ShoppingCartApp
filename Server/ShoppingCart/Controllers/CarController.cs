using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.Entities;
using Microsoft.AspNetCore.JsonPatch;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCart.Controllers
{
    [Route("api/cars")]
    public class CarController : Controller
    {
        private ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("{id}", Name ="GetCar")]
        public IActionResult GetCar(Guid id)
        {
           
            if (!_carRepository.CarExists(id))
            {
                return NotFound();
            }
            var carFromRepo = _carRepository.GetCar(id);
            CarDto carToReturn = Mapper.Map<CarDto>(carFromRepo);
            return Ok(carFromRepo);
        }
        [HttpGet()]
        public IActionResult GetCars()
        {
            var carsFromRepo = _carRepository.GetCars();
            //IEnumerable < CarDto > carsToReturn
            //    = Mapper.Map<IEnumerable<CarDto>>(carsFromRepo);
            return Ok(carsFromRepo);
        }
        [HttpPost()]
        public IActionResult CreateCar([FromBody] CarForCreationDto car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            var carForCreation = Mapper.Map<Car>(car);
            _carRepository.AddCar(carForCreation);
            
            if (!_carRepository.Save())
            {
                throw new Exception(" Saving error in Database");
            }
            var carToReturn = Mapper.Map<CarDto>(carForCreation);
            //return Ok(carToReturn);
            return CreatedAtRoute("GetCar", new { id = carForCreation.Id }, carToReturn);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(Guid id)
        {
            var carFromRepo = _carRepository.GetCar(id);
            if(carFromRepo == null)
            {
                return NotFound();
            }
            _carRepository.DeleteCar(carFromRepo);
            if (!_carRepository.Save())
            {
                throw new Exception("Error at Save");
            }
            return NoContent();
        }

        [HttpPut("{carId}")]
        public IActionResult UpdateCar(Guid carId, [FromBody] CarForUpdateDto car)
        {
            if(car == null)
            {
                return BadRequest();
            }
            if (!_carRepository.CarExists(carId))
            {
                return NotFound();
            }

            var carFromRepo = _carRepository.GetCar(carId);
            Mapper.Map(car, carFromRepo);
    
             

                if (!_carRepository.Save())
                {
                    throw new Exception("Fail to save");
                }

            return NoContent();


            
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateCar(Guid id, [FromBody] JsonPatchDocument<CarForUpdateDto> pathDoc)
        {
            if (pathDoc == null)
            {
                return BadRequest();
            }
            if (!_carRepository.CarExists(id))
            {
                return NotFound();
            }
            var carFromRepo = _carRepository.GetCar(id);
            var carForUpdate = Mapper.Map<CarForUpdateDto>(carFromRepo);
            pathDoc.ApplyTo(carForUpdate);
            Mapper.Map(carForUpdate, carFromRepo);
            if (!_carRepository.Save())
            {
                throw new Exception("Saving problem");
            }
            return NoContent();
        }
        
        
        
    }
}
