using _0_Framework.Application;
using _0_Framwork.Infrastructure;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagment.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;
        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        #region MyRegion
        //public void Create(ProductCategory entiy)
        //{
        //    return _context.productCategories.Add(entiy);
        //}

        //public bool Exists(Expression<Func<ProductCategory, bool>> expression)
        //{
        //    return _context.productCategories.Any(expression);
        //}

        //public ProductCategory Get(long id)
        //{
        //    return _context.productCategories.Find(id);
        //}

        //public List<ProductCategory> GetAll()
        //{
        //    return _context.productCategories.ToList();
        //}

        //public void SaveChange()
        //{
        //    _context.SaveChange();
        //}
        #endregion


        public EditProductCategory GetDetail(long id)
        {
            return _context.productCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.productCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySerachModel searchModel)
        {
            var query = _context.productCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi()
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
