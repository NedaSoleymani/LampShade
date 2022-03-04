
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagment.Infrastructure.EFCore.Mapping;

namespace ShopManagment.Infrastructure.EFCore
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductCategory> productCategories { set; get; }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }     
    }
}
