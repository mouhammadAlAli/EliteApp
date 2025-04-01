using EliteDashboard.Data.NewEntities;
using EliteWebApp.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MudBlazorWebApp1.Data.Entities;
using MudBlazorWebApp1.Data.Entities.Identity;
using MudBlazorWebApp1.Data.Entities.PracticeDashbaord;

namespace MudBlazorWebApp1.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User, Role, int>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.ApplyIdentityConfiguration();

        modelBuilder.Entity<ClaimAccounting>().HasNoKey();
        modelBuilder.Entity<Refund>().HasNoKey();
        modelBuilder.Entity<ClaimAccountingError>().HasNoKey();
        modelBuilder.Entity<PaymentClaims>().HasNoKey();
    }
    public virtual DbSet<UserWorkingPeriod> UserWorkingPeriods { get; set; }
    public virtual DbSet<Attachment> Attachments { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<Announcement> Announcements { get; set; }
    public virtual DbSet<Practice> Practices { get; set; }
    public virtual DbSet<TimeOffRequest> TimeOffRequests { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<Claim> Claims { get; set; }

    public DbSet<ClaimAccounting> ClaimAccountings { get; set; }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Encounter> Encounters { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<EncounterProcedure> EncounterProcedures { get; set; }

    public DbSet<ClaimTransaction> ClaimTransactions { get; set; }

    public DbSet<ServiceLocation> ServiceLocations { get; set; }

    public DbSet<Refund> Refunds { get; set; }

    public DbSet<ClaimAccountingError> ClaimAccountingErrors { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<PaymentClaims> PaymentClaims { get; set; }
}

