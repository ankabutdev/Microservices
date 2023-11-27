using School.Infrastracture.Interfaces.Schools;
using School.Infrastracture.Services.Schools;

namespace School.API.Configurations.Layers;

public static class ServiceConfiguration
{
    public static void ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISchoolService, SchoolService>();
    }
}
