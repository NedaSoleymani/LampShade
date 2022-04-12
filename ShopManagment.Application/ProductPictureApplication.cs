using _0_Framework.Application;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagment.Application.Contracts.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProducRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IProducRepository productRepository, IFileUploader fileUploader)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreateProductPicture command)
        {
            var operationResult = new OperationResult();
            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
            //    return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var product = _productRepository.GetProductWithCategory(command.ProductId);
            var path = $"{product.Category.Slug}//{product.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            var productPicture = new ProductPicture(command.ProductId, picturePath, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChange();
            return operationResult.Successed();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operationResult = new OperationResult();
            var productPicture = _productPictureRepository.GetWithProductAndCategory(command.Id);
            if (productPicture == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
            //    return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var product = _productRepository.GetProductWithCategory(command.ProductId);
            var path = $"{productPicture.Product.Category.Slug}//{productPicture.Product.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            productPicture.Edit(command.ProductId, picturePath, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChange();
            return operationResult.Successed();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operationResult = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Remove();
            _productPictureRepository.SaveChange();
            return operationResult.Successed();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Restore();
            _productPictureRepository.SaveChange();
            return operationResult.Successed();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
