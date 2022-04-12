using _0_Framwork.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public Account GetBy(string username)
        {
            return _context.Accounts.FirstOrDefault(x => x.Username == username);
        }

        public EditAccount GetDtails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                Username = x.Username
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel serachModel)
        {
            var query = _context.Accounts.Include(x=>x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                Username = x.Username,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RoleId = x.Role.Id
            });

            if (!string.IsNullOrWhiteSpace(serachModel.Fullname))
                query.Where(x => x.Fullname.Contains(serachModel.Fullname));


            if (!string.IsNullOrWhiteSpace(serachModel.Mobile))
                query.Where(x => x.Fullname.Contains(serachModel.Mobile));


            if (!string.IsNullOrWhiteSpace(serachModel.Username))
                query.Where(x => x.Fullname.Contains(serachModel.Username));

            if (serachModel.RoleId > 0)
                query = query.Where(x => x.RoleId == serachModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
