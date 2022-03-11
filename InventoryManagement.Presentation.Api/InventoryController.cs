﻿using _01_LampshadeQuery.Contracts.Inventory;
using InventoryManagment.Application.Contract.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryQuery _inventoryQuery;
        private readonly IInventoryApplication _inventoryApplication;

        public InventoryController(IInventoryApplication inventoryApplication, IInventoryQuery inventoryQuery)
        {
            _inventoryApplication = inventoryApplication;
            _inventoryQuery = inventoryQuery;
        }


        //[HttpGet]
        //public List<InventoryOperationViewModel> GetOperationsBy(long id)
        //{
        //    return _inventoryApplication.GetOperationLog(id);
        //}

        [HttpPost]
        public StockStatus CheckStock(IsInStock command)
        {
            return _inventoryQuery.CheckStock(command);
        }
    }
}
