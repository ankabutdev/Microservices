using Car.Domain.Entities.Cars;
using Microsoft.EntityFrameworkCore;

namespace Car.Application.Data;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options) { }

    public DbSet<CarModel> Cars { get; set; }
}
