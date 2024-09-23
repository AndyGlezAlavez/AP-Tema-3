using MaintenanceModel.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Maintenances.Commands.DeleteMaintenance
{
    public record class DeleteMaintenanceCommand(Guid id) : ICommand;
}
