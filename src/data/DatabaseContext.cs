
using Microsoft.EntityFrameworkCore;

namespace med_consult_api.src.data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DbContext> options) : base(options)
    {

    }

    //public DbSet<User> Users { get; set; } 
}