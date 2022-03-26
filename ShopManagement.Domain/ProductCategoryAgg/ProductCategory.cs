using _0_Framwork.Domain;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory: EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }//عنوان کویری استرینگ لینک صفحه که برابر با عنوان کتگوری پروتاکت هست برای SEO 
        public List<Product> Prodcuts { get; private set; }

        public ProductCategory()
        {
            Prodcuts = new List<Product>();
        }
        public ProductCategory(string name, string description, string picture,
            string pictureAlt, string pictureTitle, string keywords
            , string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = PictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;

        }

        public void Edit(string name, string description, string picture,
            string pictureAlt, string pictureTitle, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            if(!string.IsNullOrWhiteSpace(Picture))
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = PictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public bool Exists(string name)
        {
            return false;
        }
    }
}