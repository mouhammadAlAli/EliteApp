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
    public DbSet<Team> Teams { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
}

