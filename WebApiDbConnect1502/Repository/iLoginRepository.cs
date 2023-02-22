using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Repository
{
    public interface iLoginRepository
    {
        Task<UserLogin>AuthenticateAsync(string username, string password);
    }
}
