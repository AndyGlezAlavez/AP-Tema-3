using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Maintenances;
using MaintenanceModel.Contracts.Units;
using MaintenanceModel.Contracts.Workers;
using MaintenanceModel.DataAccess.Repositories.Maintenances;
using MaintenanceModel.DataAccess.Repositories.Units;
using MaintenanceModel.DataAccess.Repositories.Workers;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Maintenances.Commands.CreateMaintenance
{
    public class CreateMaintenanceCommandHandler : ICommandHandler<CreateMaintenanceCommand, Maintenance>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaintenanceRepository _maintenanceRepository;

        public CreateMaintenanceCommandHandler(IUnitRepository unitRepository, IUnitOfWork unitOfWork,IMaintenanceRepository maintenanceRepository)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
           _maintenanceRepository = maintenanceRepository;
        }

        public Task<Maintenance> Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var unit = _unitRepository.GetUnitById(request.Unit.Id);
            Maintenance result = new Maintenance(
                Guid.NewGuid(),
                request.Type,
                request.Description,
                request.Date,
                unit);
            _maintenanceRepository.AddMaintenance( result );
            _unitOfWork.SaveChanges();
            return Task.FromResult( result );
        }
    }
}
