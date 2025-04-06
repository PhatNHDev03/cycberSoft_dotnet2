using Microsoft.EntityFrameworkCore;
using session37_api.Models;
namespace session37_api.Data
{

    public class AppDbContext : DbContext
    {
        //contructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}
