using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Repository
{
    public interface IUserRepository
    {

        Task<List<User>>GetUsers();
        Task<User?> GetUserById(int id);
        Task AddUser(User user);
        Task DeleteUser(int id);
        Task UpdateUser(User user);
    }
}
