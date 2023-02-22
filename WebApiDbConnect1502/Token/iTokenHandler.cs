using Microsoft.AspNetCore.Identity;
using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Token
{
    public interface iTokenHandler
    {
        Task<string> CreateToken(UserLogin user);
        Task<string> CreateToken(LoginMaster user);
    }
}
