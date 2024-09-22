using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Contracts.Units
{
    public interface IUnitRepository
    {
        /// <summary>
        /// Añade una unidad a la base de datos
        /// </summary>
        /// <param name="unit"></param>
        void Addunit(Unit unit);

        /// <summary>
        /// Obtiene una unidad por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Unit? GetUnitById(Guid id);

        /// <summary>
        /// OBtiene todas las unidades de la base de datos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Unit> GetAllUnit();

        /// <summary>
        /// Modifica los valores de una unidad de la base de datos
        /// </summary>
        /// <param name="unit"></param>
        void Updateunit(Unit unit);

        /// <summary>
        /// Elimina una unidad de la base de datos
        /// </summary>
        /// <param name="unit"></param>
        void Deleteunit(Unit unit);
    }
}
