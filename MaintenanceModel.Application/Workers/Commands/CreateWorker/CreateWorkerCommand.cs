using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Workers.Commands.CreateWorker
{
    public record class CreateWorkerCommand(string CI,string Name,Maintenance Maintenance):
        ICommand<Worker>;
}
