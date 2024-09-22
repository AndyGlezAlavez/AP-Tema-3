using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Contracts.Maintenances
{
    public interface IMaintenanceRepository
    {
        /// <summary>
        /// Añade un mantenimiento a la abse de datos
        /// </summary>
        /// <param name="maintenance"></param>
        void AddMaintenance(Maintenance maintenance);

        /// <summary>
        /// Obitnene un mantenimiento de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Maintenance? GetMaintenanceById(Guid id);

        /// <summary>
        /// Obtiene todos los mantenimientos en la base de datos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Maintenance> GetAllMaintenance();

        /// <summary>
        /// Modifica los valores de un mantenimiento de la base de datos
        /// </summary>
        /// <param name="maintenance"></param>
        void UpdateMaintenance(Maintenance maintenance);

        /// <summary>
        /// Elimina un mantenimiento de la base de datos
        /// </summary>
        /// <param name="maintenance"></param>
        void DeleteMaintenance(Maintenance maintenance);
    }
}
