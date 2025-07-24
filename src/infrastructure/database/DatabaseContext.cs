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

        //Campos unicos
        modelBuilder.Entity<Role>()
            .HasIndex(r => r.Name)
            .IsUnique().HasDatabaseName("IX_Role_Name");

        modelBuilder.Entity<UserProfile>().OwnsOne(
                u => u.Email, email =>
                {
                    email.Property(a => a.Value).HasColumnName("Email");
                    email.HasIndex(a => a.Value).IsUnique().HasDatabaseName("IX_UserProfile_Email");
                }
            );

        modelBuilder.Entity<UserProfile>().OwnsOne(
              u => u.Telephone, telephone =>
              {
                  telephone.Property(a => a.Value).HasColumnName("Telephone");
                  telephone.HasIndex(a => a.Value).IsUnique().HasDatabaseName("IX_UserProfile_Telephone"); ;

              });

        modelBuilder.Entity<AuthUser>()
                       .HasIndex(r => r.UserName)
                       .IsUnique().HasDatabaseName("IX_AuthUser_UserName");

        modelBuilder.Entity<Exam>()
                            .HasIndex(r => r.Name)
                            .IsUnique().HasDatabaseName("IX_Exam_Name");

        modelBuilder.Entity<ExamCategory>()
                                 .HasIndex(r => r.Name)
                                 .IsUnique().HasDatabaseName("IX_ExamCategory_Name");

        modelBuilder.Entity<Consult>()
                                  .HasIndex(r => r.Name)
                                  .IsUnique().HasDatabaseName("IX_Consult_Name");

        modelBuilder.Entity<SubsystemHealth>()
                               .HasIndex(r => r.Name)
                               .IsUnique().HasDatabaseName("IX_SubsystemHealth_Name");

        modelBuilder.Entity<Speciality>()
                                 .HasIndex(r => r.Name)
                                 .IsUnique().HasDatabaseName("IX_Speciality_Name");


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

        modelBuilder.Entity<Professional>()
            .HasOne(p => p.Speciality)
            .WithMany()
            .HasForeignKey(p => p.SpecialityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AppointmentConsultRequest>()
        .HasOne(a => a.UserProfile)
        .WithMany()
        .HasForeignKey(a => a.UserProfileId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AppointmentConsultSchedule>()
            .HasOne(a => a.Administrative)
                 .WithMany()
                 .HasForeignKey(a => a.AdministrativeId)
                 .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<AppointmentConsultDone>()
            .HasOne(a => a.Administrative)
                 .WithMany()
                 .HasForeignKey(a => a.AdministrativeId)
                 .OnDelete(DeleteBehavior.NoAction);

 modelBuilder.Entity<AppointmentExamRequest>()
        .HasOne(a => a.UserProfile)
        .WithMany()
        .HasForeignKey(a => a.UserProfileId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AppointmentExamSchedule>()
            .HasOne(a => a.Administrative)
                 .WithMany()
                 .HasForeignKey(a => a.AdministrativeId)
                 .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<AppointmentExamDone>()
            .HasOne(a => a.Administrative)
                 .WithMany()
                 .HasForeignKey(a => a.AdministrativeId)
                 .OnDelete(DeleteBehavior.NoAction);

    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamCategory> ExamCategories { get; set; }
    public DbSet<Consult> Consults { get; set; }
    public DbSet<ClinicalConsultAct> ClinicalConsultActs { get; set; }
    public DbSet<ClinicalExamAct> ClinicalExamActs { get; set; }
    public DbSet<SubsystemHealth> SubsystemHealths { get; set; }
    public DbSet<Speciality> Specialities { get; set; }
    public DbSet<Professional> Professionals { get; set; }
    public DbSet<AuthUser> AuthUsers { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<AppointmentConsultRequest> AppointmentConsultRequests { get; set; }
    public DbSet<AppointmentConsultDone> AppointmentConsultDones { get; set; }
    public DbSet<AppointmentConsultSchedule> AppointmentConsultSchedules { get; set; }
    public DbSet<AppointmentExamRequest> AppointmentExamRequests { get; set; }
    public DbSet<AppointmentExamDone> AppointmentExamDones { get; set; }
    public DbSet<AppointmentExamSchedule> AppointmentExamSchedules { get; set; }

}