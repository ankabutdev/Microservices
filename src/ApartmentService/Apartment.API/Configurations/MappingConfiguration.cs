using Apartment.Domain.Entities.Apartments;
using Apartment.Infrastructure.DTOs.Apartments;
using AutoMapper;

namespace Apartment.API.Configurations;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        CreateMap<ApartmentCreateDto, ApartmentModel>().ReverseMap();
        CreateMap<ApartmentUpdateDto, ApartmentModel>().ReverseMap();
    }
}
