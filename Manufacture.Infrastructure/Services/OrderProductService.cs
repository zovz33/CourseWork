using Manufacture.BusinessLogic.Interfaces;
using Manufacture.Core.Entities;
using Manufacture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.Infrastructure.Services;

public class OrderProductService : IOrderProductService
{
    private readonly ApplicationDbContext _context;
    private readonly IUserService userService;
    public OrderProductService(ApplicationDbContext context, IUserService UserService)
    {
        _context = context;
        userService = UserService;
    }

    public async Task<List<ProductToOrder>> GetAllAsync()
    {
        return await _context.OrderProduct.ToListAsync();
    }

    public async Task<ProductToOrder> GetByIdAsync(int id)
    {
        return await _context.OrderProduct.FindAsync(id);
    }
    public async Task<ProductToOrder> GetByNameAsync(string name)
    {
        return await _context.OrderProduct.FirstOrDefaultAsync(m => m.Name == name);
    }
    public async Task AddAsync(ProductToOrder entity)
    {
        var adminId = await userService.GetCurrentUserIdAsync();
        if (entity != null)
        {
            entity.CreatedBy = adminId;
            entity.UpdatedBy = 0;
            entity.CreatedDateTime = DateTime.UtcNow;
            _context.OrderProduct.Add(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(ProductToOrder entity)
    {
        var adminId = await userService.GetCurrentUserIdAsync();
        if (entity != null)
        {
            entity.UpdatedBy = adminId;
            entity.UpdatedDateTime = DateTime.UtcNow;
            _context.OrderProduct.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.OrderProduct.FindAsync(id);
        if (entity != null)
        {
            _context.OrderProduct.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}