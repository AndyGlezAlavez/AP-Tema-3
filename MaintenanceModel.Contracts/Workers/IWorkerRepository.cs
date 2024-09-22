using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Contracts.Workers
{
    public interface IWorkerRepository
    {
        /// <summary>
        /// Añade un trabajador a la base de datos
        /// </summary>
        /// <param name="worker"></param>
        void AddWorker(Worker worker);

        /// <summary>
        /// Obtiene un trabajador de la base de datos por su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Worker? GetWorkerById(Guid id);

        /// <summary>
        /// Obitene todos los trabajadores de la base de datos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Worker> GetAllWorkers();

        /// <summary>
        /// Modifica los parametros de un trabajador de la base de datos
        /// </summary>
        /// <param name="worker"></param>
        void UpdateWorker(Worker worker);

        /// <summary>
        /// Elimina un trabajador de la base de datos
        /// </summary>
        /// <param name="worker"></param>
        void DeleteWorker(Worker worker);
    }
}
