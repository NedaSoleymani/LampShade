using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore
{
    public class AccountContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuillder)
        {
            var assembly = typeof(AccountMapping).Assembly;
            modelBuillder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuillder);
        }
    }
}
