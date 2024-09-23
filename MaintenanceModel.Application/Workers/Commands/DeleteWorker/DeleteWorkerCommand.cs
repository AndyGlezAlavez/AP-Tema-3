using MaintenanceModel.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Workers.Commands.DeleteWorker
{
    public record class DeleteWorkerCommand(Guid id) : ICommand;
}
