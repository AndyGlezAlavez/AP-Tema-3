using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Maintenances;
using MaintenanceModel.Contracts.Workers;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Workers.Commands.CreateWorker
{
    public class CreateWorkerCommandHandler : ICommandHandler<CreateWorkerCommand, Worker>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaintenanceRepository _maintenanceRepository;

        public CreateWorkerCommandHandler(IWorkerRepository workerRepository, IUnitOfWork unitOfWork, IMaintenanceRepository maintenanceRepository)
        {
            _workerRepository = workerRepository;
            _unitOfWork = unitOfWork;
            _maintenanceRepository = maintenanceRepository;
        }

        public Task<Worker> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            var maintenance = _maintenanceRepository.GetMaintenanceById(request.Maintenance.Id);
            Worker result = new Worker(
                Guid.NewGuid(),
                request.CI,
                request.Name,
                maintenance);
            _workerRepository.AddWorker(result);
            _unitOfWork.SaveChanges();
            return Task.FromResult(result);
        }
    }
}
