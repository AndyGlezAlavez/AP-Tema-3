using MaintenanceModel.Domain.Common;
using MaintenanceModel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Domain.Entities
{
    public class Maintenance : Entity
    {
        #region Properties
        /// <summary>
        /// Tipo de mantenuiento Correctivo predictivo o preventivo
        /// </summary>
        public MaintenanceTypes Type { get; set; }

        /// <summary>
        /// Descripcion de los mantenimientos
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Fecha del mantenimiento
        /// </summary>
        public DateTime Date {  get; set; }


        /// <summary>
        /// lista de trabajadores que realizan el mantenimiento
        /// </summary>
        public List<Worker> Workers { get; set; }

        /// <summary>
        /// Unidad a la que se le realiza el mantenimiento
        /// </summary>
        public Unit Unit { get; set; }

        /// <summary>
        /// Identificador de la unidad a la que se le realiza el mantenimiento
        /// </summary>
        public Guid UnitId { get; set; }

        #endregion

        /// <summary>
        /// Constructor requerido por entityframework
        /// </summary>
        protected Maintenance() { }

        /// <summary>
        /// Constructor de los mantenimientos
        /// </summary>
        /// <param name="type"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        public Maintenance(Guid id,MaintenanceTypes type,string description, DateTime date, Unit unit): base(id) 
        {
            Type = type;
            Description = description;
            Date = date.ToUniversalTime();
            Unit = unit;
        }
    }
}
