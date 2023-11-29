using Apartment.Domain.Entities.Apartments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Apartment.Application.Data;

public class ApartmentDbContext : DbContext
{
    public ApartmentDbContext(DbContextOptions<ApartmentDbContext> options)
        : base(options)
    {
        Database.Migrate();
        //var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        //try
        //{
        //    if (databaseCreator != null)
        //    {
        //        if (!databaseCreator.CanConnect()) databaseCreator.CreateAsync();
        //        if (!databaseCreator.HasTables()) databaseCreator.CreateTablesAsync();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
    }

    public virtual DbSet<ApartmentModel> ApartmentModel { get; set; }
}
