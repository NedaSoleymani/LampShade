using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagment.Application;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Infrastructure.EFCore;
using ShopManagment.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;


namespace ShopMangment.Configuration
{
    public class ShopMangmentBoostrapper
    {
        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
