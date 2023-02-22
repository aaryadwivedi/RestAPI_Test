using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Repository
{
    public interface iNewLogin
    {
        Task<LoginMaster> AuthenticateAsync(string UserName, string Password);
    }
}
