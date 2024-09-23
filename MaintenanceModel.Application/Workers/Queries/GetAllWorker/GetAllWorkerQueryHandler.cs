using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts.Workers;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Workers.Queries.GetAllWorker
{
    public class GetAllWorkerQueryHandler : IQueryHandler<GetAllWorkerQuery, IEnumerable<Worker>>
    {
        private readonly IWorkerRepository _workerRepository;

        public GetAllWorkerQueryHandler(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }
        public Task<IEnumerable<Worker>> Handle(GetAllWorkerQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_workerRepository.GetAllWorkers());
        }
    }
}
