using _01_LampshadeQuery.Contracts.ProductCategory;
using ShopManagment.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Contracts.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext context;

        public ProductCategoryQuery(ShopContext context)
        {
            this.context = context;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return context.ProductCategories.Select(x => new ProductCategoryQueryModel { 
            Name=x.Name,
            Picture=x.Picture,
            PictureAlt=x.PictureAlt,
            PictureTitle=x.PictureTitle,
            Slug=x.Slug            
            
            }).ToList();
        }
    }
}
