using _0_Framwork.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopMangment.Configuration.Permissions;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    //دسترسی نقش ها به صفحه
    [Authorize(Roles = Roles.Administator)]
    public class IndexModel : PageModel
    {
        public ProductCategorySerachModel SearchModel;
        public List<ProductCategoryViewModel> ProductCategories;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        [NeedsPermission(ShopPermissions.ListProductCategories)]
        public void OnGet(ProductCategorySerachModel searchModel)
        {
            ProductCategories = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        [NeedsPermission(ShopPermissions.CreateProductCategory)]
        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var productCategory = _productCategoryApplication.GetDetail(id);
            return Partial("Edit", productCategory);
        }

        [NeedsPermission(ShopPermissions.EditProductCategory)]
        public JsonResult OnPostEdit(EditProductCategory command)
        {
            if (ModelState.IsValid)
            {

            }
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
