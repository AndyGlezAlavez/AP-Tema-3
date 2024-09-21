using MaintenanceModel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Domain.Entities
{
    public class Maintenance
    {
        /// <summary>
        /// Tipo de mantenuiento Correctivo predictivo o preventivo
        /// </summary>
        MaintenanceTypes Type { get; set; }

        /// <summary>
        /// Descripcion de los mantenimientos
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Fecha del mantenimiento
        /// </summary>
        DateTime Date {  get; set; }

        /// <summary>
        /// Constructor de los mantenimientos
        /// </summary>
        /// <param name="type"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        public Maintenance(MaintenanceTypes type,string description, DateTime date)
        {
            Type = type;
            Description = description;
            Date = date;
        }
    }
}
