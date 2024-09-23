using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Workers.Queries.GetWorkerById
{
    public record class GetWorkerByIdQuery(Guid id) : IQuery<Worker?>
    {
    }
}
