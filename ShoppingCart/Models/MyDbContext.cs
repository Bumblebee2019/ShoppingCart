using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<ShoppingCartClass> ShoppingCartDb { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext>options) : base(options)
        {
            
        }

    }
}
