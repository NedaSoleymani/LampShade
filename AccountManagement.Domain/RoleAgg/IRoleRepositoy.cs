using _0_Framwork.Domain;
using AccountManagement.Application.Contracts.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepositoy:IRepository<long,Role>
    {
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
    }
}
