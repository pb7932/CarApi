using System.Collections.Generic;
using CarApi.Models;
using CarApi.Repo;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CarApi.Dtos;
using System;
using System.Text;

namespace CarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
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
        public ActionResult<CarReadDto> CreateCar(CarCreateDto carCreateDto)
        {
            var carModel = _mapper.Map<Car>(carCreateDto);
            _repository.CreateCar(carModel);

            var carReadDto = _mapper.Map<CarReadDto>(carModel);

            return CreatedAtRoute(nameof(GetCarById), new { id = carReadDto.Id }, carReadDto);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCar(int id, CarUpdateDto carUpdateDto)
        {
            var carFromRepo = _repository.GetCarById(id);

            if (carFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(carUpdateDto, carFromRepo);

            _repository.UpdateCar(carFromRepo);

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

        [Route("verify")]
        [AcceptVerbs("GET", "POST", "PUT")]
        public IActionResult VerifyUniqueName(string name)
        {
            if (!_repository.VerifyUniqueName(name))
            {
                return Json(false);
            }

            return Json(true);
        }
    }
}