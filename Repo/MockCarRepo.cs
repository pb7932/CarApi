using System.Collections.Generic;
using CarApi.Models;

namespace CarApi.Repo
{
    public class MockCarRepo : ICarRepo
    {
        public IEnumerable<Car> GetAllCars()
        {
            var cars = new List<Car>
            {
                new Car { Id = 0, name = "bmw", price = 200000, power = 100 },
                new Car { Id = 1, name = "seat", price = 50000, power = 70 },
                new Car { Id = 2, name = "citroen", price = 100000, power = 80 }
            };

            return cars;
        }

        public Car GetCarById(int id)
        {
            return new Car { Id = 0, name = "bmw", price = 200000, power = 100 };
        }
    }
}