using Microsoft.EntityFrameworkCore;

namespace WebApiDbConnect1502.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<LoginMaster> LoginMasters { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set;}
    }
}
