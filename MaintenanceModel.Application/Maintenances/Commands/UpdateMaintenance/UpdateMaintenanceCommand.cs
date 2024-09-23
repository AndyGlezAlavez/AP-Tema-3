using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Maintenances.Commands.UpdateMaintenance
{
    public record class UpdateMaintenanceCommand(Maintenance Maintenance): ICommand;
}
