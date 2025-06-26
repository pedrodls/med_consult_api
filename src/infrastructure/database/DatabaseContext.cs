using med_consult_api.src.domain;
using Microsoft.EntityFrameworkCore;

namespace med_consult_api.src.infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>()
            .HasIndex(r => r.Name)
            .IsUnique();
    }

    public DbSet<Role> Roles { get; set; }
}