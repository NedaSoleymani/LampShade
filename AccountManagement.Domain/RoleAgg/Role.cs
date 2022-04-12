using _0_Framwork.Domain;
using AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role:EntityBase
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }

        public Role(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}
