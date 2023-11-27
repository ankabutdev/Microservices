using Car.Infrastracture.Interfaces.Cars;
using Car.Infrastracture.Services.Cars;

namespace Car.API.Configurations.Layers;

public static class ServiceConfiguration
{
    public static void ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICarService, CarService>();
    }
}
