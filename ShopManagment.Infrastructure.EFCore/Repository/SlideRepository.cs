using _0_Framework.Application;
using _0_Framwork.Infrastructure;
using ShopManagement.Domain.SlidAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagment.Application.Contracts.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                BtnText = x.BtnText,
                Heading = x.Heading,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Title = x.Title

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(x => new SlideViewModel
            {
                Heading = x.Heading,
                Id = x.Id,
                Picture = x.Picture,
                Title = x.Title,
                IsRemoved=x.IsRemoved,
                CreationDate = x.CreationDate.ToFarsi()

            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
