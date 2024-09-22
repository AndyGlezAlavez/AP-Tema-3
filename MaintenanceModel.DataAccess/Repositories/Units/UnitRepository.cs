using MaintenanceModel.Contracts.Units;
using MaintenanceModel.DataAccess.Context;
using MaintenanceModel.DataAccess.Repositories.Common;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.DataAccess.Repositories.Units
{
    public class UnitRepository : RepositoryBase, IUnitRepository
    {
        public UnitRepository(ApplicationContext context) : base(context)
        {
        }

        public void Addunit(Unit unit)
        {
            _context.Units.Add(unit);
        }

        public void Deleteunit(Unit unit)
        {
            _context.Units.Remove(unit);    
        }

        public IEnumerable<Unit> GetAllUnit()
        {
            return _context.Units.ToList();
        }

        public Unit? GetUnitById(Guid id)
        {
            return _context.Units.FirstOrDefault(x => x.Id == id);
        }

        public void Updateunit(Unit unit)
        {
            _context.Units.Update(unit);
        }
    }
}
