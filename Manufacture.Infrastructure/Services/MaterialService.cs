using Manufacture.BusinessLogic.Interfaces;
using Manufacture.Core.Entities;
using Manufacture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.Infrastructure.Services;

public class MaterialService : IMaterialService
{
    private readonly ApplicationDbContext _context;
    private readonly IUserService userService;

    public MaterialService(ApplicationDbContext context, IUserService UserService)
    {
        _context = context;
        userService = UserService;
    }

    public async Task<List<RawMaterial>> GetAllMaterialsAsync()
    {
        return await _context.Materials.ToListAsync();
    }

    public async Task<RawMaterial> GetMaterialByIdAsync(int id)
    {
        return await _context.Materials.FindAsync(id);
    }

    public async Task<RawMaterial> GetMaterialByNameAsync(string name)
    {
        return await _context.Materials.FirstOrDefaultAsync(m => m.Name == name);
    }

    public async Task AddMaterialAsync(RawMaterial material)
    {
        var adminId = await userService.GetCurrentUserIdAsync();
        if (material != null)
        {
            material.CreatedBy = adminId;
            material.UpdatedBy = 0;
            material.CreatedDateTime = DateTime.UtcNow;
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateMaterialAsync(RawMaterial material)
    {
        var adminId = await userService.GetCurrentUserIdAsync();
        if (material != null)
        {
            material.UpdatedBy = adminId;
            material.UpdatedDateTime = DateTime.UtcNow;
            _context.Materials.Update(material);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteMaterialAsync(int id)
    {
        var material = await _context.Materials.FindAsync(id);
        if (material != null)
        {
            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
        }
    }
}