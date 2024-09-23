using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts.Workers;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Workers.Queries.GetWorkerById
{
    public class GetWorkerByIdQueryHandler : IQueryHandler<GetWorkerByIdQuery, Worker?>
    {
        private readonly IWorkerRepository _workerRepository;

        public GetWorkerByIdQueryHandler(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }
        public Task<Worker?> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_workerRepository.GetWorkerById(request.id));
        }
    }
}
