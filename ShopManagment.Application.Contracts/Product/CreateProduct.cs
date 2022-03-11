
using _0_Framework.Application;
using ShopManagment.Application.Contracts.ProductCategory;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage =ValidationMessages.IsRequeired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Code { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public double UnitPrice { get; set; }
        public bool IsInStock { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string MetaDescription { get; set; }

        [Range(0,100000,ErrorMessage = ValidationMessages.IsRequeired)]
        public long CategoryId { get; set; }
        public List<ProductCategoryViewModel> Categories { get; set; }
    }
}
