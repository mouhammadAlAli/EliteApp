using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazorWebApp1.Data.Entities.Identity;

namespace EliteWebApp.Data.Configurations;

public static class IdentityConfiguration
{
    public static void ApplyIdentityConfiguration(this ModelBuilder builder)
    {
        builder.Entity<User>(entity =>
        {
            entity.ToTable("Users", "Identity");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
        });

        builder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles", "Identity");
            entity.Metadata.RemoveIndex(new[] { entity.Property(r => r.NormalizedName).Metadata });
        });


        builder.Entity<IdentityRoleClaim<int>>(entity =>
        {
            entity.ToTable("RoleClaims", "Identity");
        });

        // Configure other identity entities
        builder.Entity<IdentityUserRole<int>>(entity =>
        {
            entity.ToTable("UserRoles", "Identity");
        });

        builder.Entity<IdentityUserClaim<int>>(entity =>
        {
            entity.ToTable("UserClaims", "Identity");
        });

        builder.Entity<IdentityUserLogin<int>>(entity =>
        {
            entity.ToTable("UserLogins", "Identity");
        });

        builder.Entity<IdentityUserToken<int>>(entity =>
        {
            entity.ToTable("UserTokens", "Identity");
        });
    }
}

