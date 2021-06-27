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
        }
    }
}