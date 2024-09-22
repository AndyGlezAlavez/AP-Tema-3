using MaintenanceModel.Contracts.Workers;
using MaintenanceModel.DataAccess.Context;
using MaintenanceModel.DataAccess.Repositories.Common;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.DataAccess.Repositories.Workers
{
    public class WorkerRepository : RepositoryBase, IWorkerRepository
    {
        public WorkerRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddWorker(Worker worker)
        {
            _context.Workers.Add(worker);
        }

        public void DeleteWorker(Worker worker)
        {
            _context?.Workers.Remove(worker);
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            return _context.Workers.ToList();
        }

        public Worker? GetWorkerById(Guid id)
        {
            return _context.Workers.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateWorker(Worker worker)
        {
            _context.Workers.Update(worker);
        }
    }
}
