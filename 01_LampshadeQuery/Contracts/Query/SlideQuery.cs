﻿using _01_LampshadeQuery.Contracts.Slide;
using ShopManagment.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Contracts.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _shopContext.Slides.Where(x => x.IsRemoved == false).Select(x => new SlideQueryModel 
            { 
            Picture=x.Picture,
             BtnText=x.BtnText,
             Heading=x.Heading,
             Link=x.Link,
             PictureAlt=x.PictureAlt,
             PictureTitle=x.PictureTitle,
             Text=x.Text,
             Title=x.Title
            }).ToList();
        }
    }
}
