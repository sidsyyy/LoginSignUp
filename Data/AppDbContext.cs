using Microsoft.EntityFrameworkCore;
using LoginSignup.Data.Entity;

namespace LoginSignup.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public required DbSet<User> Users { get; set; }//initializing the table name in AppDbContext to use it in Database.
    }

   
}
