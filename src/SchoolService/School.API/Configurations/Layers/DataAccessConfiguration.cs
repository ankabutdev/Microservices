using School.Application.Data;
using School.Application.Interfaces.Schools;
using School.Application.Repositories.Schools;

namespace School.API.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this IHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
            services.Configure<MongoDbSettings>(context.Configuration.GetSection("MongoDb"));
            services.AddScoped(typeof(MongoDbContext<>));
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<MongoDbContext<CounterModel>>();
        });
    }
}
