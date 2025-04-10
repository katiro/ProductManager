using Microsoft.EntityFrameworkCore;
using ProductManager.Model.Entity;

namespace ProductManager.Model
{
    public class ProductManagerDBContext : DbContext
    {
        public ProductManagerDBContext(DbContextOptions<ProductManagerDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
