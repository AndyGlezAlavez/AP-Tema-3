using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Domain.Entities;
using MaintenanceModel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Maintenances.Commands.CreateMaintenance
{
    public record CreateMaintenanceCommand(MaintenanceTypes Type,
        string Description , 
        DateTime Date,
        Unit Unit )
        : ICommand<Maintenance>;

}
