using Apartment.Application.Data;
using Apartment.Application.Interfaces.Apartments;
using Apartment.Application.Repositories.Apartments;
using Microsoft.EntityFrameworkCore;

namespace Apartment.API.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DockerConnection");

        builder.Services.AddDbContext<ApartmentDbContext>(options =>
        {
            options.UseSqlServer(connectionString);

        });

        // AutoMapping
        builder.Services.AddAutoMapper(typeof(MappingConfiguration));

        // Database Configuration
        builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();
    }
}
