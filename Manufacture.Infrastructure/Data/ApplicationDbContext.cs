using System.Reflection;
using Manufacture.BusinessLogic.Interfaces;
using Manufacture.Core.Entities;
using Manufacture.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, int,
    UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RawMaterial> Materials { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductToOrder> OrderProduct { get; set; }
    public DbSet<Order> Orders { get; set; }
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(entity => entity.ToTable("Users"));
        builder.Entity<Role>(entity => entity.ToTable("Roles"));
        builder.Entity<UserRole>(entity =>
            entity.ToTable("UserRoles"));
        builder.Entity<UserClaim>(entity =>
            entity.ToTable("UserClaim"));
        builder.Entity<UserLogin>(entity =>
            entity.ToTable("UserLogins"));
        builder.Entity<UserToken>(entity =>
            entity.ToTable("UserTokens"));
        builder.Entity<RoleClaim>(entity =>
            entity.ToTable("RoleClaims"));
        builder.Entity<RawMaterial>(entity =>
            entity.ToTable("RawMaterials"));
        builder.Entity<Product>(entity =>
            entity.ToTable("Products"));
        builder.Entity<ProductToOrder>(entity =>
            entity.ToTable("ProductToOrder"));
        builder.Entity<Order>(entity =>
            entity.ToTable("Orders"));
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}