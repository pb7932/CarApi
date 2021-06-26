using System;
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

        public void CreateCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            var carModel = car;

            _context.Cars.Add(carModel);
            _context.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            var carModel = car;

            _context.Cars.Remove(carModel);
            _context.SaveChanges();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            var carModel = car;

            _context.Cars.Update(carModel);
            _context.SaveChanges();
        }
    }
}