using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SharedLibrary.Models.Blog;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Models.Users;

namespace KanesKitchenServer.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            /*
            modelBuilder.Entity<ProductCategory>().HasData(
                               new ProductCategory { Id = 1, CategoryName = "Food", CategoryNameSvk = "Jedlo" },
                                              new ProductCategory { Id = 2, CategoryName = "Drinks", CategoryNameSvk = "Napoje" }
                                                         );

            modelBuilder.Entity<Product>().HasData(
                               new Product { Id = 1, ProductName = "Pizza", ProductNameSvk = "Pizza", ProductDescription = "Tasty pizza", ProductDescriptionSvk = "Chutná pizza", ProductPrice = 5.99, ProductStock = 100, ProductCategoryId = 1 },
                                              new Product { Id = 2, ProductName = "Cola", ProductNameSvk = "Cola", ProductDescription = "Cold cola", ProductDescriptionSvk = "Ľadová cola", ProductPrice = 1.99, ProductStock = 200, ProductCategoryId = 2 }
                                                         );

            modelBuilder.Entity<Roles>().HasData(
                               new Roles { Id = 1, Role = "Admin" },
                                              new Roles { Id = 2, Role = "User" }
                                                         );

            modelBuilder.Entity<User>().HasData(
                               new User { Id = 1, Email = ""})
            */

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Basket>(_ =>
            {
                _.HasKey(_ => new { _.UserId, _.ProductId });
            });

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Basket>()
                .HasOne(_ => _.User)
                .WithMany(_ => _.Baskets)
                .HasForeignKey(_ => _.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Basket>()
                .HasOne(_ => _.Product)
                .WithMany(_ => _.Baskets)
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
