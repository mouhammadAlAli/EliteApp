using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudBlazorWebApp1.Data.Entities;

namespace MudBlazorWebApp1.Data.Configurations;

public class TeamsConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder
           .HasMany(t => t.Members)
           .WithOne(u => u.Team)
           .HasForeignKey(u => u.TeamId)
           .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(t => t.Leader)
            .WithMany()
            .HasForeignKey(t => t.LeaderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
