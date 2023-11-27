using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Students;

namespace School.Application.Data;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options) { }

    public DbSet<SchoolModel> Schools { get; set; }
}
