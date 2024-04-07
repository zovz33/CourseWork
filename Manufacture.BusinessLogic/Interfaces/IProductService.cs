using Manufacture.Core.Entities;

namespace Manufacture.BusinessLogic.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> GetByNameAsync(string name);
    Task AddAsync(Product entity);
    Task UpdateAsync(Product entity);
    Task DeleteAsync(int id);
}