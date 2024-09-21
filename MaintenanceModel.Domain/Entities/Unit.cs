using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Domain.Entities
{
    public class Unit
    {
        #region Properties
        /// <summary>
        /// Nombre de la unidad
        /// </summary>
        string Name {  get; set; }

        /// <summary>
        /// Codigo de la unidad
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Fabricante de la unidad
        /// </summary>
        string Manufacture {  get; set; }

        /// <summary>
        /// Fecha de puesta en marcha de la unidad
        /// </summary>
        DateTime StartDate { get; set; }
        #endregion

        /// <summary>
        /// Constructor de unidades
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="manufacture"></param>
        /// <param name="startDate"></param>
        public Unit(string name, string code, string manufacture, DateTime startDate)
        {
            Name = name;
            Code = code;
            Manufacture = manufacture;
            StartDate = startDate;
        }
    }
}
