using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Maintenances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Maintenances.Commands.DeleteMaintenance
{
    public class DeleteMaintenanceCommandHandler : ICommandHandler<DeleteMaintenanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaintenanceRepository _maintenanceRepository;

        public DeleteMaintenanceCommandHandler(IUnitOfWork unitOfWork, IMaintenanceRepository maintenanceRepository)
        {
            _unitOfWork = unitOfWork;
            _maintenanceRepository = maintenanceRepository;
        }

        public Task Handle(DeleteMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var MainteannceToDelete = _maintenanceRepository.GetMaintenanceById(request.id);
            if(MainteannceToDelete == null) 
                return Task.CompletedTask;

            _maintenanceRepository.DeleteMaintenance(MainteannceToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
