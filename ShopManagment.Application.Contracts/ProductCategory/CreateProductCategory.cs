using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Name { get; set; }
        public string Description { get; set; }

        //[Required(ErrorMessage = ValidationMessages.IsRequeired)]
        [MaxFileSize(3*1024 * 1024, ErrorMessage =ValidationMessages.MaxFileSize)]
        [FileExtentionLimitationAttribute(new string[] {".jepg",".jpg",".png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Slug { get; set; }
    }
}
