using Manufacture.BusinessLogic.Interfaces;
using Manufacture.Core.Entities;
using Manufacture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;
    private readonly IUserService userService;
    public OrderService(ApplicationDbContext context, IUserService UserService)
    {
        _context = context;
        userService = UserService;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }
    public async Task<Order> GetByNameAsync(string name)
    {
        return await _context.Orders.FirstOrDefaultAsync(m => m.ProductToOrder.Name == name);
    }
    public async Task AddAsync(Order entity)
    {
        var adminId = await userService.GetCurrentUserIdAsync();
        if (entity != null)
        {
            if (entity.OrderDate == null)
                entity.OrderDate = DateTime.UtcNow;
            entity.CreatedBy = adminId;
            entity.UpdatedBy = 0;
            entity.CreatedDateTime = DateTime.UtcNow;
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Order entity)
    {
        var adminId = await userService.GetCurrentUserIdAsync();
        if (entity != null)
        {
            entity.UpdatedBy = adminId;
            entity.UpdatedDateTime = DateTime.UtcNow;
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Orders.FindAsync(id);
        if (entity != null)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}