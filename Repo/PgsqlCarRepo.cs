using System.Collections.Generic;
using System.Linq;
using CarApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Repo
{
    public class PgsqlCarRepo : ICarRepo
    {
        private readonly CarContext _context;

        public PgsqlCarRepo(CarContext context)
        {
            _context = context;
        }
        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }
    }
}