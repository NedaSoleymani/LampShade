using _01_LampshadeQuery.Contracts.Inventory;
using InventoryManagment.Infrastructure.EFCore;
using ShopManagment.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Contracts.Query
{
    public class InventoryQuery : IInventoryQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;

        public InventoryQuery(ShopContext shopContext, InventoryContext inventoryContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
        }

        public StockStatus CheckStock(IsInStock command)
        {
            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.Id == command.ProductId);
            if (inventory == null || inventory.CalculateCurrencyCount()> command.Count)
            {
                var product = _shopContext.Products.
                    Select(x => new { x.Id, x.Name }).FirstOrDefault(x => x.Id == command.ProductId);
                return new StockStatus 
                {
                    InStock = false, 
                    ProductName = product.Name 
                };
            }
            return new StockStatus 
            {
                InStock = true 
            };
        }
    }
}
