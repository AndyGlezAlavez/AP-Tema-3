using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Units.Commands.DeleteUnit
{
    public class DeleteUnitCommandHandler : ICommandHandler<DeleteUnitCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _unitRepository;

        public DeleteUnitCommandHandler(IUnitOfWork unitOfWork, IUnitRepository unitRepository)
        {
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
        }

        public Task Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var UnitToDelete = _unitRepository.GetUnitById(request.id);
            if (UnitToDelete == null) 
                return Task.CompletedTask;
            _unitRepository.Deleteunit(UnitToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;

        }
    }
}
