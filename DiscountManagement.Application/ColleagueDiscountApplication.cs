using _0_Framework.Application;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueRepository)
        {
            this._colleagueDiscountRepository = colleagueRepository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operation = new OperationResult();
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var customerDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);

            _colleagueDiscountRepository.Create(customerDiscount);
            _colleagueDiscountRepository.SaveChange();
            return operation.Successed();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operation = new OperationResult();
            var customerDiscount = _colleagueDiscountRepository.Get(command.Id);

            if (customerDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId
             && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

;
            customerDiscount.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.SaveChange();
            return operation.Successed();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var customerDiscount = _colleagueDiscountRepository.Get(id);

            if (customerDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            ;
            customerDiscount.Remove();
            _colleagueDiscountRepository.SaveChange();
            return operation.Successed();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var customerDiscount = _colleagueDiscountRepository.Get(id);

            if (customerDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            ;
            customerDiscount.Restore();
            _colleagueDiscountRepository.SaveChange();
            return operation.Successed();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}
