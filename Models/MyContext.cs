using Microsoft.EntityFrameworkCore;
 
namespace Products_Categories.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Product> product { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Association> association { get; set; }

    }
}