using Manufacture.BusinessLogic.Interfaces;
using Manufacture.Core.Entities;
using Manufacture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    private readonly IUserService userService;
    public ProductService(ApplicationDbContext context, IUserService UserService)
    {
        _context = context;
        userService = UserService;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }
    public async Task<Product> GetByNameAsync(string name)
    {
        return await _context.Products.FirstOrDefaultAsync(m => m.ProductToOrder.Name == name);
    }
    public async Task AddAsync(Product entity)
    {
        var adminId = await userService.GetCurrentUserIdAsync();
        if (entity != null)
        {
            entity.CreatedBy = adminId;
            entity.UpdatedBy = 0;
            entity.CreatedDateTime = DateTime.UtcNow;
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Product entity)
    {
        var adminId = await userService.GetCurrentUserIdAsync();
        if (entity != null)
        {
            entity.UpdatedBy = adminId;
            entity.UpdatedDateTime = DateTime.UtcNow;
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Products.FindAsync(id);
        if (entity != null)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}