using KanesKitchenServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KanesKitchenServer.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
