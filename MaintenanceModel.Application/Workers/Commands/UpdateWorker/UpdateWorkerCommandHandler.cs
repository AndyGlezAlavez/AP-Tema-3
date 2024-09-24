using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Workers.Commands.UpdateWorker
{
    public class UpdateWorkerCommandHandler : ICommandHandler<UpdateWorkerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkerRepository  _workerRepository;

        public UpdateWorkerCommandHandler(IUnitOfWork unitOfWork, IWorkerRepository workerRepository)
        {
            _unitOfWork = unitOfWork;
            _workerRepository = workerRepository;
        }

        public Task Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            _workerRepository.UpdateWorker(request.worker);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
