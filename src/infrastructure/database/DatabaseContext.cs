
using med_consult_api.src.domain;
using Microsoft.EntityFrameworkCore;

namespace med_consult_api.src.infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; } 
}