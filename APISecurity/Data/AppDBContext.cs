using APISecurity.Model;
using Microsoft.EntityFrameworkCore;

namespace APISecurity.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
