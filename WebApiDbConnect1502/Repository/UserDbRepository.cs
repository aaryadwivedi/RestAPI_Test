using Microsoft.EntityFrameworkCore;
using WebApiDbConnect1502.Models;

namespace WebApiDbConnect1502.Repository
{
    public class UserDbRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserDbRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddUser(User user)
        {
            await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            User user= await this.context.Users.SingleOrDefaultAsync(x => x.Id == id);
            this.context.Users.Remove(user);
            await this.context.SaveChangesAsync();
            //return user;
        }

        public async Task<User?> GetUserById(int id)
        {
            return await this.context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await this.context.Users.ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            this.context.Users.Update(user);
            await this.context.SaveChangesAsync();
        }
    }
}
