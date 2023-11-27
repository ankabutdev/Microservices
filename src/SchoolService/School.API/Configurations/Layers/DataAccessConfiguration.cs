using School.Application.Interfaces.Schools;

namespace School.API.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingConfiguration));

        builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
    }
}
