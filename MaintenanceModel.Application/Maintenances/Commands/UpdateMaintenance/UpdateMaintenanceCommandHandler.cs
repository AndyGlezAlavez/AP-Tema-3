using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Maintenances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Maintenances.Commands.UpdateMaintenance
{
    public class UpdateMaintenanceCommandHandler : ICommandHandler<UpdateMaintenanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaintenanceRepository _maintenanceRepository;

        public UpdateMaintenanceCommandHandler(IUnitOfWork unitOfWork, IMaintenanceRepository maintenanceRepository)
        {
            _unitOfWork = unitOfWork;
            _maintenanceRepository = maintenanceRepository;
        }

        public Task Handle(UpdateMaintenanceCommand request, CancellationToken cancellationToken)
        {
            _maintenanceRepository.UpdateMaintenance(request.Maintenance);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
