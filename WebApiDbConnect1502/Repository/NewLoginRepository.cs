using Microsoft.EntityFrameworkCore;
using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Repository
{
    public class NewLoginRepository : iNewLogin
    {
        private readonly AppDbContext context;
        public NewLoginRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<LoginMaster> AuthenticateAsync(string userName, string password)
        {
            var user = await context.LoginMasters.Include(r=>r.Roles).SingleOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower() &&
                                                u.Password == password);
            return user;
        }
    }
}
