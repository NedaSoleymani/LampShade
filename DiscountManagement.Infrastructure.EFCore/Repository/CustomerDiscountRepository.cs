﻿using _0_Framework.Application;
using _0_Framwork.Domain;
using _0_Framwork.Infrastructure;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagment.Application.Contract.CustomerDiscount;
using ShopManagment.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _context.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToString(),
                ProductId = x.ProductId,
                Reason = x.Reason,
                StartDate = x.StartDate.ToString()
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {

                Id = x.Id,
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                EndDateGr = x.EndDate,
                ProductId = x.ProductId,
                Reason = x.Reason,
                StartDate = x.StartDate.ToFarsi(),
                StartDateGr = x.StartDate,
                CreationDate=x.CreationDate.ToFarsi()
            });

            if (searchModel.ProductId > 0)
                query.Where(x => x.ProductId == searchModel.ProductId);

            if (string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                query.Where(x => x.StartDateGr > searchModel.StartDate.ToGeorgianDateTime());
            }

            if (string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                query.Where(x => x.EndDateGr > searchModel.EndDate.ToGeorgianDateTime());
            }

            var discounts = query.OrderByDescending(x => x.Id).ToList();

            discounts.ForEach(discount =>
            discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId) ?.Name);
            return discounts;
        }
    }
}
