using _0_Framework.Application;
using ShopManagement.Domain.SlidAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagment.Application.Contracts.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operationResult = new OperationResult();
            var slide = new Slide(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading,
                command.Title, command.Text, command.BtnText,command.Link);

            _slideRepository.Create(slide);
            _slideRepository.SaveChange();
            return operationResult.Successed();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operationResult = new OperationResult();
            var slide = _slideRepository.Get(command.Id);

            if (slide == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            slide.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading,
           command.Title, command.Text, command.BtnText,command.Link);

            _slideRepository.SaveChange();
            return operationResult.Successed();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operationResult = new OperationResult();
            var slide = _slideRepository.Get(id);

            if (slide == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            slide.Remove();
            _slideRepository.SaveChange();
            return operationResult.Successed();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var slide = _slideRepository.Get(id);

            if (slide == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            slide.Restore();
            _slideRepository.SaveChange();
            return operationResult.Successed();
        }
    }
}
