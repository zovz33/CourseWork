using Manufacture.Core.Entities;

namespace Manufacture.BusinessLogic.Interfaces;

public interface IOrderProductService
{
    Task<List<ProductToOrder>> GetAllAsync();
    Task<ProductToOrder> GetByIdAsync(int id);
    Task<ProductToOrder> GetByNameAsync(string name);
    Task AddAsync(ProductToOrder material);
    Task UpdateAsync(ProductToOrder material);
    Task DeleteAsync(int id);
}