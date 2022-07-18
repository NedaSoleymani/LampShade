using _0_Framework.Application;
using _0_Framwork.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _acountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepositoy _roleRepository;

        public AccountApplication(IAccountRepository acountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepositoy roleRepository)
        {
            _acountRepository = acountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();
            if (_acountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var Path = $"profilePhotos";
            var pictuerPath = _fileUploader.Upload(command.ProfilePhoto, password);
            var account = new Account(command.Fullname, command.Username, password,
                command.Mobile, command.RoleId, pictuerPath);
            _acountRepository.Create(account);
            _acountRepository.SaveChange();
            return operation.Successed();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _acountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_acountRepository.Exists(x => (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id == command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);


            var path = $"profilePhotos";
            var pictuerPath = _fileUploader.Upload(command.ProfilePhoto, path);
            account.Edit(command.Fullname, command.Username,
                command.Mobile, command.RoleId, pictuerPath);
            _acountRepository.SaveChange();
            return operation.Successed();
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _acountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);


            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _acountRepository.SaveChange();
            return operation.Successed();
        }

        public EditAccount GetDtails(long id)
        {
            return _acountRepository.GetDtails(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel serachModel)
        {
            return _acountRepository.Search(serachModel);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _acountRepository.GetBy(command.Username);
            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            (bool Verified, bool NeedsUpgrade) result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var permissions = _roleRepository.Get(account.RoleId).Permissions.Select(x => x.Code).ToList();
            //set coockei in response
            var authViewModel = new AuthViewModel(
                account.Id,
                account.RoleId, account.Fullname,
                account.Username, account.Mobile, permissions
                );
            _authHelper.Signin(authViewModel);
            return operation.Successed();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public AccountViewModel GetAccountById(long id)
        {
            var account = _acountRepository.Get(id);
            return new AccountViewModel() { Fullname = account.Fullname, Mobile = account.Mobile };
        }
    }
}
