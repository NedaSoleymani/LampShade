﻿using _0_Framework.Application;
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
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operationResult = new OperationResult();
            //اگر وجود داشت
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
            {
                operationResult.Failed("امکان ثبت رکورد تکراری وجود ندارد.لطفا مجدد تلاش کنید. ");
            }

            var slug = command.Slug.ToSlug();
            var productCategory = new ProductCategory(
                 command.Name, command.Description, command.Picture, command.MetaDescription,
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
                operationResult.Failed("رکورد با اطلاعات درخواست شده یافت نشد.لطفا مجدد تلاش کنید. ");
            //چک کردن نام و آیدی یعنی غیر از خودش
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                operationResult.Failed("امکان ثبت رکورد تکراری وجود ندارد.لطفا مجدد تلاش کنید. ");

            var slug = command.Slug.ToSlug();
            productCategory.Edit(command.Name, command.Description, command.Picture
                , command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            return operationResult.Successed();
        }

        public EditProductCategory GetDetail(long id)
        {
            return _productCategoryRepository.GetDetail(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySerachModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}