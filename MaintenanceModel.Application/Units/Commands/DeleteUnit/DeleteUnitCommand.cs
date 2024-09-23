using MaintenanceModel.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Units.Commands.DeleteUnit
{
    public record class DeleteUnitCommand(Guid id): ICommand;
}
