using Manufacture.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manufacture.Infrastructure.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey("Id");
        builder.HasIndex("Id").IsUnique();
        builder.Property(u => u.UserName).HasMaxLength(50);
        builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
        builder.Property(user => user.Email).HasMaxLength(256).IsRequired();
        builder.HasIndex(user => user.Email).IsUnique();
        builder.Property(u => u.NormalizedEmail).HasMaxLength(256);
        builder.Property(user => user.PasswordHash).HasMaxLength(256).IsRequired();

        builder.Property(user => user.PhoneNumber).HasMaxLength(20);
        builder.Property(user => user.FirstName).HasMaxLength(20);
        builder.Property(user => user.MiddleName).HasMaxLength(20);
        builder.Property(user => user.LastName).HasMaxLength(20);
        builder.Property(user => user.Gender).HasMaxLength(1);
        builder.Property(user => user.Address).HasMaxLength(30);
        builder.Property(user => user.ProfileImage).HasMaxLength(200);

        builder.Property("CreatedBy").HasMaxLength(20);
        builder.Property("CreatedDateTime").IsRequired();
        builder.Property("UpdatedBy").HasMaxLength(20);
        builder.Property("UpdatedDateTime");


        builder.HasMany(e => e.Claims)
            .WithOne(e => e.User)
            .HasForeignKey(uc => uc.UserId)
            .IsRequired();

        builder.HasMany(e => e.Logins)
            .WithOne(e => e.User)
            .HasForeignKey(ul => ul.UserId)
            .IsRequired();

        builder.HasMany(e => e.Tokens)
            .WithOne(e => e.User)
            .HasForeignKey(ut => ut.UserId)
            .IsRequired();

        builder.HasMany(e => e.UserRoles)
            .WithOne(e => e.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
    }
}