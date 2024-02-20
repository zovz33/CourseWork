using Manufacture.Core.Entities.Identity;

namespace Manufacture.BusinessLogic.Interfaces;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetUserById(int? id);
    Task AddUser(User user, int adminId);
    Task UpdateUser(User user, int id, int adminId);
    Task DeleteUser(int id);
}