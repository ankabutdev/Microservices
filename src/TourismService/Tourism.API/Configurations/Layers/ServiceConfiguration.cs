using Tourism.Infrastructure.Interfaces.Tourists;
using Tourism.Infrastructure.Services.Tourists;

namespace School.API.Configurations.Layers;

public static class ServiceConfiguration
{
    public static void ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITouristService, TouristService>();
    }
}
