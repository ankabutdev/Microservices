using Microsoft.EntityFrameworkCore;
using Tourism.API.Configurations;
using Tourism.Application.Data;
using Tourism.Application.Interfaces.Tourits;

namespace School.API.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        var connectionstring = builder.Configuration.GetConnectionString("Default")!;

        builder.Services.AddDbContext<TouristDbContext>(options =>
        {
            options.UseMySql(
                builder.Configuration.GetConnectionString(connectionstring),
                //Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql")
                new MySqlServerVersion(new Version(8, 0, 30))
                //ServerVersion.AutoDetect(connectionstring)
            );
        });


        builder.Services.AddAutoMapper(typeof(MappingConfiguration));
        builder.Services.AddScoped<ITouristRepository, TouristRepository>();
    }
}
