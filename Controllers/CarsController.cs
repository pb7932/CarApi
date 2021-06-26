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
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            var cars = _repository.GetAllCars();

            if (cars == null)
            {
                return NotFound();
            }

            return Ok(cars);
        }
    }
}