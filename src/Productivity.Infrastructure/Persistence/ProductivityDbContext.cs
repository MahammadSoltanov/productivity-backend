using Microsoft.EntityFrameworkCore;
using Productivity.Domain.UserAggregate;

namespace Productivity.Infrastructure.Persistence;
public class ProductivityDbContext : DbContext
{
    public ProductivityDbContext(DbContextOptions<ProductivityDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductivityDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; } = null!;
}
