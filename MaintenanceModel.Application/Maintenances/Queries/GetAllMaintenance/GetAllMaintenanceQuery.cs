using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Maintenances.Queries.GetAllMaintenance
{
    public record class GetAllMaintenanceQuery : IQuery<IEnumerable<Maintenance>>;
}
