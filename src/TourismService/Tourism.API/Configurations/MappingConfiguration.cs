using AutoMapper;
using Tourism.Application.DTOs.Tourists;
using Tourism.Domain.Entities.Tourists;

namespace Tourism.API.Configurations;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        CreateMap<TouristCreateDto, Tourist>().ReverseMap();
        CreateMap<TouristUpdateDto, Tourist>().ReverseMap();
    }
}
