using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagment.Application;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Infrastructure.EFCore;
using ShopManagment.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagement.Domain.SlideAgg;
using ShopManagment.Application.Contracts.Slide;
using _01_LampshadeQuery.Contracts.Slide;
using _01_LampshadeQuery.Contracts.Query;

namespace ShopMangment.Configuration
{
    public class ShopMangmentBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProducRepository, ProductRepository>();

            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();

            services.AddTransient<ISlideRepository,  SlideRepository>();
            services.AddTransient<ISlideApplication, SlideApplication>();

            services.AddTransient<ISlideQuery, SlideQuery>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
