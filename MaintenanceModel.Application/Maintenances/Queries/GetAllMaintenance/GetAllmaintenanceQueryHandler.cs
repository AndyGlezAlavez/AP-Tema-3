using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts.Maintenances;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Maintenances.Queries.GetAllMaintenance
{
    public class GetAllmaintenanceQueryHandler : IQueryHandler<GetAllMaintenanceQuery, IEnumerable<Maintenance>>
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public GetAllmaintenanceQueryHandler(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public Task<IEnumerable<Maintenance>> Handle(GetAllMaintenanceQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_maintenanceRepository.GetAllMaintenance());
        }
    }
}
