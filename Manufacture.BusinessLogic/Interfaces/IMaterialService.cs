using Manufacture.Core.Entities;

namespace Manufacture.BusinessLogic.Interfaces;

public interface IMaterialService
{
    Task<List<RawMaterial>> GetAllMaterialsAsync();
    Task<RawMaterial> GetMaterialByIdAsync(int id);
    Task<RawMaterial> GetMaterialByNameAsync(string name);
    Task AddMaterialAsync(RawMaterial material);
    Task UpdateMaterialAsync(RawMaterial material);
    Task DeleteMaterialAsync(int id);
}