using AutoMapper;
using CarApi.Dtos;
using CarApi.Models;

namespace CarApi.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Car, CarReadDto>();
            CreateMap<CarCreateDto, Car>();
            CreateMap<CarUpdateDto, Car>();
            CreateMap<Car, CarUpdateDto>();
        }
    }
}