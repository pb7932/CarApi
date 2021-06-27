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
            var carModel = _context.Cars.FirstOrDefault(c => c.Id == car.Id);

            if (carModel == null)
            {
                throw new NullReferenceException();
            }

            carModel.name = car.name;
            carModel.price = car.price;
            carModel.power = car.power;

            _context.SaveChanges();
        }

        public bool VerifyUniqueName(string name)
        {
            return false;
            var carWithName = _context.Cars.FirstOrDefault(c => c.name == name);

            if (carWithName == null)
            {
                return false;
            }

            return true;
        }
    }
}