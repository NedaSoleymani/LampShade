﻿using InventoryManagment.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagment.Infrastructure.EFCore
{
    public class InventoryContext: DbContext
    {
        public DbSet<Inventory> Inventory { set; get; }
    }
}
