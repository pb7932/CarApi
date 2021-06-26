using System.Collections.Generic;
using CarApi.Models;
using CarApi.Repo;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepo _repository;

        public CarsController(ICarRepo repositroy)
        {
            _repository = repositroy;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            var cars = _repository.GetAllCars();

            if (cars == null)
            {
                return NotFound();
            }

            return Ok(cars);
        }

        [HttpGet("{id}", Name = "GetCarById")]
        public ActionResult<Car> GetCarById(int id)
        {
            var car = _repository.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public ActionResult CreateCar(Car car)
        {
            _repository.CreateCar(car);

            return CreatedAtRoute(nameof(GetCarById), new { id = car.Id }, car);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCar(int id, Car car)
        {
            var carFromRepo = _repository.GetCarById(id);

            if (carFromRepo == null)
            {
                return NotFound();
            }

            _repository.UpdateCar(car);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var carFromRepo = _repository.GetCarById(id);

            if (carFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCar(carFromRepo);

            return NoContent();
        }
    }
}