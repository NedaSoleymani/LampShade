﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopManagement.Presentation.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductQuery _productQuery;
        //public ProductController(IProductQuery productQuery)
        //{
        //    _productQuery = productQuery;
        //}

        //[HttpGet]
        //public List<ProductQueryModel> GetLatestArrivals()
        //{
        //    return _productQuery.GetLatestArrivals();
        //}
    }
}
