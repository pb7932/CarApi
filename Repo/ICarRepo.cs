using System.Collections.Generic;
using CarApi.Models;

namespace CarApi.Repo
{
    public interface ICarRepo
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
    }
}