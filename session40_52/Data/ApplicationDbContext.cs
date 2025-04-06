using Microsoft.EntityFrameworkCore;
using session40_52.Models;
namespace session40_52.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //add model enitity
        public DbSet<Product> products { get; set; }
    }

}