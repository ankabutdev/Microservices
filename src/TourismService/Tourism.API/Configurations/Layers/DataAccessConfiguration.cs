using Microsoft.EntityFrameworkCore;
using Tourism.API.Configurations;
using Tourism.Application.Data;
using Tourism.Application.Interfaces.Tourits;

namespace School.API.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<TouristDbContext>(options =>
        {
            options.UseMySql(
                builder.Configuration.GetConnectionString("Default"),
                new MySqlServerVersion(new Version(8, 0, 26))
            );
        });


        builder.Services.AddAutoMapper(typeof(MappingConfiguration));
        builder.Services.AddScoped<ITouristRepository, TouristRepository>();
    }
}
