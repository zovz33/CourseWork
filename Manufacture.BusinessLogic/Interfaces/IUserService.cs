using Manufacture.Core.Entities.Identity;

namespace Manufacture.BusinessLogic.Interfaces;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetUserById(int? id);
    Task AddUser(User user);
    Task UpdateUser(User user, int id);
    Task DeleteUser(int id);
    Task<string> FindNameById(int? createdById);
    Task<int> GetCurrentUserIdAsync();
    Task<User> GetCurrentUserAsync();

    Task<string> GetUserNameById(int? userId);


}