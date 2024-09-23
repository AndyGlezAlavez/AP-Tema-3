using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Units.Commands.CreateUnit
{
    public record class CreateUnitCommand(string Name,
        string Code,
        string Manufacture,
        DateTime StartDate): 
        ICommand<Unit>;
}
