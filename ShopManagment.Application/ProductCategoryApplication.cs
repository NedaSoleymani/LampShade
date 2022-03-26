using _0_Framework.Application;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagment.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace ShopManagment.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operationResult = new OperationResult();
            //اگر وجود داشت
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
            {
                operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var picturePath = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            var productCategory = new ProductCategory(
                 command.Name, command.Description, fileName, command.MetaDescription,
                 command.PictureAlt, command.PictureTitle, command.Keywords, slug
                );

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChange();
            return operationResult.Successed();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operationResult = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                operationResult.Failed(ApplicationMessages.RecordNotFound);
            //چک کردن نام و آیدی یعنی غیر از خودش
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var picturePath = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);
            productCategory.Edit(command.Name, command.Description, fileName
                , command.PictureAlt, command.PictureTitle, command.Keywords,
                command.MetaDescription, slug);

            _productCategoryRepository.SaveChange();
            return operationResult.Successed();
        }

        public EditProductCategory GetDetail(long id)
        {
            return _productCategoryRepository.GetDetail(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySerachModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}
