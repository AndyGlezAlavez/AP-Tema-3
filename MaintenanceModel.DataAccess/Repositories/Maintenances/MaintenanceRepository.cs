using MaintenanceModel.Contracts.Maintenances;
using MaintenanceModel.DataAccess.Context;
using MaintenanceModel.DataAccess.Repositories.Common;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.DataAccess.Repositories.Maintenances
{
    public class MaintenanceRepository : RepositoryBase, IMaintenanceRepository
    {
        public MaintenanceRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddMaintenance(Maintenance maintenance)
        {
            _context.Maintenances.Add(maintenance);
        }

        public void DeleteMaintenance(Maintenance maintenance)
        {
            _context.Maintenances.Remove(maintenance);
        }

        public IEnumerable<Maintenance> GetAllMaintenance()
        {
            return _context.Maintenances.ToList();
        }

        public Maintenance? GetMaintenanceById(Guid id)
        {
            return _context.Maintenances.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateMaintenance(Maintenance maintenance)
        {
            _context.Maintenances.Update(maintenance);
        }
    }
}
