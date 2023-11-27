using Microsoft.EntityFrameworkCore;
using Tourism.Domain.Entities.Tourists;

namespace Tourism.Application.Data;

public class TouristDbContext : DbContext
{
    public TouristDbContext(DbContextOptions<TouristDbContext> options)
        : base(options)
    {
        //try
        //{
        //    Database.EnsureCreated();
        //}
        //catch (Exception ex)
        //{
        //    // Handle the exception (log, rethrow, etc.)
        //    Console.WriteLine($"An error occurred while ensuring the database is created: {ex.Message}");
        //}
    }

    public DbSet<Tourist> Tourists { get; set; }
}
