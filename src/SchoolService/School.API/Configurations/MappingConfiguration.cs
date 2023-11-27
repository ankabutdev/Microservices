using AutoMapper;
using School.Domain.Entities.Students;
using School.Infrastracture.DTOs.Schools;

namespace School.API.Configurations;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        CreateMap<SchoolCreateDto, SchoolModel>().ReverseMap();
        CreateMap<SchoolUpdateDto, SchoolModel>().ReverseMap();
    }
}
