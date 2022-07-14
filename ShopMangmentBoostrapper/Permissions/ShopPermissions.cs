using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangment.Configuration.Permissions
{
    public static class ShopPermissions
    {
        //Products
        public const int ListProducts = 10;
        public const int SearchProducts = 11;
        public const int CreateProduct = 12;
        public const int EditProduct = 13;

        //ProductsCategory
        public const int SearchProductCategories = 20;
        public const int ListProductCategories = 21;
        public const int CreateProductCategory = 22;
        public const int EditProductCategory = 23;

    }
}
