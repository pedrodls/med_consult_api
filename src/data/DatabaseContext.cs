
using med_consult_api.src.models;
namespace med_consult_api.src.data;
using Microsoft.EntityFrameworkCore;


public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; } 
}