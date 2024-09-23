using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts.Maintenances;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Maintenances.Queries.GetMaintenanceById
{
    public class GetMaintenanceByIdQueryHandler : IQueryHandler<GetMaintenanceByIDQuery, Maintenance?>
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public GetMaintenanceByIdQueryHandler(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public Task<Maintenance?> Handle(GetMaintenanceByIDQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_maintenanceRepository.GetMaintenanceById(request.id));
        }
    }
}
