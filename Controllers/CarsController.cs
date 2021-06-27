using System.Collections.Generic;
using CarApi.Models;
using CarApi.Repo;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CarApi.Dtos;

namespace CarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepo _repository;
        private readonly IMapper _mapper;

        public CarsController(ICarRepo repositroy, IMapper mapper)
        {
            _repository = repositroy;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            var cars = _repository.GetAllCars();

            if (cars == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<CarReadDto>>(cars));
        }

        [HttpGet("{id}", Name = "GetCarById")]
        public ActionResult<CarReadDto> GetCarById(int id)
        {
            var car = _repository.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            var carReadDto = _mapper.Map<CarReadDto>(car);

            return Ok(carReadDto);
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