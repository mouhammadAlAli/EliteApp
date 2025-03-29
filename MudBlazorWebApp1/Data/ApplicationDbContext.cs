using EliteWebApp.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MudBlazorWebApp1.Data.Entities;
using MudBlazorWebApp1.Data.Entities.Identity;

namespace MudBlazorWebApp1.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User, Role, int>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.ApplyIdentityConfiguration();
    }
    public virtual DbSet<UserWorkingPeriod> UserWorkingPeriods { get; set; }
    public virtual DbSet<Attachment> Attachments { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<Announcement> Announcements { get; set; }
    public virtual DbSet<Practice> Practices { get; set; }
    public virtual DbSet<TimeOffRequest> TimeOffRequests { get; set; }
}

