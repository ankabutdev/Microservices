using Car.Application.Data;
using Car.Application.Interfaces.Cars;
using Car.Application.Repositories.Cars;
using Microsoft.EntityFrameworkCore;

namespace Car.API.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        // get connection string from appsettings.json
        builder.Services.AddDbContext<CarDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        // Mapping
        builder.Services.AddAutoMapper(typeof(MappingConfiguration));

        // addscoped
        builder.Services.AddScoped<ICarRepository, CarRepository>();
    }
}
