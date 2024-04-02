using Manufacture.Core.Entities;
using Manufacture.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.BusinessLogic.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<RawMaterial> Materials { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<ProductToOrder> OrderProduct { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<RoleClaim> RoleClaims { get; set; }
    Task<int> SaveChangesAsync();
}