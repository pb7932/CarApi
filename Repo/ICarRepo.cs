using System.Collections.Generic;
using CarApi.Models;

namespace CarApi.Repo
{
    public interface ICarRepo
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void CreateCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);

        bool VerifyUniqueName(string name);
    }
}