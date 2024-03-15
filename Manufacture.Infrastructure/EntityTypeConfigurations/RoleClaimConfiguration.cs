using Manufacture.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manufacture.Infrastructure.EntityTypeConfigurations;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.HasKey("Id");
        builder.HasIndex("Id").IsUnique();
        builder.Property(u => u.ClaimType).HasMaxLength(32).IsRequired();
        builder.Property(u => u.ClaimValue).HasMaxLength(128).IsRequired();;
    }
}