using MaintenanceModel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Domain.Entities
{
    public class Unit : Entity
    {
        #region Properties
        /// <summary>
        /// Nombre de la unidad
        /// </summary>
        public string Name {  get; set; }

        /// <summary>
        /// Codigo de la unidad
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Fabricante de la unidad
        /// </summary>
        public string Manufacture {  get; set; }

        /// <summary>
        /// Fecha de puesta en marcha de la unidad
        /// </summary>
        public DateTime StartDate { get; set; }

        public List<Maintenance> Maintenances { get; set; }
        #endregion

        /// <summary>
        /// Constructor requerido por entityframework
        /// </summary>
        protected Unit() { }

        /// <summary>
        /// Constructor de unidades
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="manufacture"></param>
        /// <param name="startDate"></param>
        public Unit(Guid id,string name, string code, string manufacture, DateTime startDate): base(id)
        {
            Name = name;
            Code = code;
            Manufacture = manufacture;
            StartDate = startDate.ToUniversalTime();
        }
    }
}
