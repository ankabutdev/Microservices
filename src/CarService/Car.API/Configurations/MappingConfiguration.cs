using AutoMapper;
using Car.Domain.Entities.Cars;
using Car.Infrastracture.DTOs.Cars;

namespace Car.API.Configurations;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        CreateMap<CarCreateDto, CarModel>().ReverseMap();
        CreateMap<CarUpdateDto, CarModel>().ReverseMap();
    }
}
