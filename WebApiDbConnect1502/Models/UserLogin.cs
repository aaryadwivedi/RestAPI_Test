using System.Security.Claims;

namespace WebApiDbConnect1502.Models
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public UserLogin() {
            Id = 0;
            UserName = "";
            Password = "";
            Role = "";
        }

    }
}
