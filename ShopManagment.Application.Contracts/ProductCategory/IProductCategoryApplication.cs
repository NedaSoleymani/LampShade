using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagment.Application.Contracts.ProductCategory
{
   public  interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetail(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySerachModel searchModel);

    }
}
