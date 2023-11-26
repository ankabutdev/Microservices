using Microsoft.EntityFrameworkCore;

namespace Apartment.Application.Data;

public class ApartmentDbContext : DbContext
{
    public ApartmentDbContext(DbContextOptions<ApartmentDbContext> options)
        : base(options) { }

    //public DbSet<Apartment> Apartments { get; set; }
}
