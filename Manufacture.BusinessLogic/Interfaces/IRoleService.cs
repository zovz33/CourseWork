using Manufacture.Core.Entities.Identity;

namespace Manufacture.BusinessLogic.Interfaces;

public interface IRoleService
{
    Task<List<Role>> GetRoles();
    Task<Role> GetRoleById(int? id);
    Task Delete(int id);
    Task Add(Role entity, int adminId);
    Task Update(Role role, int id, int adminId);

}