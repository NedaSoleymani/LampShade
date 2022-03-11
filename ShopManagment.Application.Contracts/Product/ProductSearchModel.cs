﻿namespace ShopManagment.Application.Contracts.Product
{
    public class ProductSearchModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long CategoryId { get; set; }
        public string Picture { get; private set; }
    }
}
