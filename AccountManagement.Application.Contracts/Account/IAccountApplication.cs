using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contracts.Account
{
    public  interface IAccountApplication
    {
        AccountViewModel GetAccountById(long id);
        OperationResult Register(RegisterAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Login(Login command);
        EditAccount GetDtails(long id);
        List<AccountViewModel> Search(AccountSearchModel serachModel);
        void Logout();
    }
}
