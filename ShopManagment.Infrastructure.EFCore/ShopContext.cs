
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlidAgg;
using ShopManagment.Infrastructure.EFCore.Mapping;

namespace ShopManagment.Infrastructure.EFCore
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductPicture> ProductPictures { set; get; }
        public DbSet<Slide> Slides { set; get; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
