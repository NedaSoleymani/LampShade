using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepositoy _roleRepository;

        public RoleApplication(IRoleRepositoy roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateRole command)
        {
            OperationResult operation = new OperationResult();
            if (_roleRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var role = new Role(command.Name, new List<Permission>());
            _roleRepository.Create(role);
            _roleRepository.SaveChange();
            return operation.Successed();

        }

        public OperationResult Edit(EditRole command)
        {
            OperationResult operation = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_roleRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var permissions = new List<Permission>();
            command.Permissions.ForEach(code => permissions.Add(new Permission(code)));

            role.Edit(command.Name, permissions);
            _roleRepository.SaveChange();
            return operation.Successed();
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }

        public List<RoleViewModel> List()
        {
            return _roleRepository.List();
        }

    }
}
