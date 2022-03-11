using _01_LampshadeQuery.Contracts.Inventory;
using _01_LampshadeQuery.Contracts.Query;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagment.Infrastructure.Configuration
{
    public class InventoryManagmentBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IInventoryQuery, InventoryQuery>();
        }
    }
}
