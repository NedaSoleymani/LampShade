
using _0_Framework.Application;
using ShopManagment.Application.Contracts.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1,100000,ErrorMessage=ValidationMessages.IsRequeired)]
        public long ProductId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string PictureTitle { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}