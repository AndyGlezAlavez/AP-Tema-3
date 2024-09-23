using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Units.Commands.UpdateUnit
{
    public record class UpdateUnitCommand(Unit Unit): ICommand;
}
