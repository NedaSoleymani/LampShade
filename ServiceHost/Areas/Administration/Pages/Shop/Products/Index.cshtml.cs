using _0_Framwork.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopMangment.Configuration.Permissions;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;

        }
      
        [NeedsPermission(ShopPermissions.ListProducts)]
        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Products = _productApplication.Serach(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetProductCategories()
            };

            return Partial("./Create", command);
        }


        [NeedsPermission(ShopPermissions.CreateProduct)]
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var product = _productApplication.GetDetails(id);
            product.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("Edit", product);
        }


        [NeedsPermission(ShopPermissions.EditProduct)]
        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetNotInStock(long id)
        {
            var result = _productApplication.NotInStock(id);
            if (result.ISSuccessed)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetIsInStock(long id)
        {
            var result = _productApplication.Isstock(id);
            if (result.ISSuccessed)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
