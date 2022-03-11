using _0_Framwork.Domain;
using ShopManagment.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {
        //void Create(ProductCategory entiy);
        //void SaveChange();
        //ProductCategory Get(long id);
        //bool Exists(Expression<Func<ProductCategory, bool>> expression);
        //List<ProductCategory> GetAll();
        List<ProductCategoryViewModel> GetProductCategories();
       EditProductCategory GetDetail(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySerachModel searchModel);
       
    }
}
