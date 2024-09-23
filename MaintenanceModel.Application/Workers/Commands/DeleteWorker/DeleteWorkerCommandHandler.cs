using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Workers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Workers.Commands.DeleteWorker
{
    public class DeleteWorkerCommandHandler : ICommandHandler<DeleteWorkerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkerRepository _workerRepository;

        public DeleteWorkerCommandHandler(IUnitOfWork unitOfWork, IWorkerRepository workerRepository)
        {
            _unitOfWork = unitOfWork;
            _workerRepository = workerRepository;
        }

        public Task Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
        {
            var WorkerToDelete = _workerRepository.GetWorkerById(request.id);
            if (WorkerToDelete == null) 
                return Task.CompletedTask;
            _workerRepository.DeleteWorker(WorkerToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
