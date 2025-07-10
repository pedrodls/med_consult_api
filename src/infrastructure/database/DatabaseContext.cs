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

        modelBuilder.Entity<UserProfile>().OwnsOne(
            u => u.Address, address =>
            {
                address.Property(a => a.Street).HasColumnName("Street");
                address.Property(a => a.City).HasColumnName("City");
                address.Property(a => a.State).HasColumnName("State");
            }
        );

        modelBuilder.Entity<UserProfile>().OwnsOne(
            u => u.Birthdate, birthdate =>
            {
                birthdate.Property(a => a.Date).HasColumnName("Birthdate");
            }
        );

        modelBuilder.Entity<UserProfile>().OwnsOne(
            u => u.Email, email =>
            {
                email.Property(a => a.Value).HasColumnName("Email");
            }
        );

        modelBuilder.Entity<UserProfile>().OwnsOne(
            u => u.FullName, fullName =>
            {
                fullName.Property(a => a.FirstName).HasColumnName("FirstName");
                fullName.Property(a => a.LastName).HasColumnName("LastName");
            }
        );

        modelBuilder.Entity<UserProfile>().OwnsOne(
            u => u.Gender, gender =>
            {
                gender.Property(a => a.value).HasColumnName("Gender");
            });

        modelBuilder.Entity<UserProfile>().OwnsOne(
           u => u.Telephone, telephone =>
           {
               telephone.Property(a => a.Value).HasColumnName("Telephone");
           });


        modelBuilder.Entity<AuthUser>().OwnsOne(
            u => u.Password, password =>
            {
                password.Property(a => a.Value).HasColumnName("Password");
            });

        modelBuilder.Entity<AuthUser>().OwnsOne(
                  u => u.ResetPasswordCode, resetPasswordCode =>
                  {
                      resetPasswordCode.Property(a => a.Value).HasColumnName("ResetPasswordCode");
                  });
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<AuthUser> AuthUsers { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

}