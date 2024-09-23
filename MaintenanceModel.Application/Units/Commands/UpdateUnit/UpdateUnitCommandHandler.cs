using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Units.Commands.UpdateUnit
{
    public class UpdateUnitCommandHandler : ICommandHandler<UpdateUnitCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _unitRepository;

        public UpdateUnitCommandHandler(IUnitOfWork unitOfWork, IUnitRepository unitRepository)
        {
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
        }

        public Task Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            _unitRepository.Updateunit(request.Unit);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
