using Apartment.Infrastructure.Interfaces.Apartments;
using Apartment.Infrastructure.Services.Apartments;

namespace Apartment.API.Configurations.Layers;

public static class ServiceConfiguration
{
    public static void ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IApartmentService, ApartmentService>();
    }
}
