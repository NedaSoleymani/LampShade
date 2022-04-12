using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.Contracts.Slide
{
    public class CreateSlide
    {
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Heading { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Text { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string BtnText { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequeired)]
        public string Link { get; set; }
    }
}
