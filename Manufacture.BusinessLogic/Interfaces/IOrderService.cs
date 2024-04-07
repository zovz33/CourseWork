using Manufacture.Core.Entities;

namespace Manufacture.BusinessLogic.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int id);
    Task<Order> GetByNameAsync(string name);
    Task AddAsync(Order entity);
    Task UpdateAsync(Order entity);
    Task DeleteAsync(int id);
}