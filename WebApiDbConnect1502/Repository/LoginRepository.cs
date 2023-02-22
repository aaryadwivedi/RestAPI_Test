using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Repository
{
    public class LoginRepository : iLoginRepository
    {
        List<UserLogin> usersLogin = new List<UserLogin>
        {
            new UserLogin {Id=1,UserName="readuser",Password="readuserpwd",Role="reader"},
            new UserLogin {Id=2,UserName="writeuser",Password="writeuserpwd",Role="author"}
        };
        public async Task<UserLogin> AuthenticateAsync(string username, string password)
        {
            var user= usersLogin.FirstOrDefault(u=> u.UserName.ToLower() == username.ToLower() &&
                                                u.Password == password);
                return user;
        }
    }
}
