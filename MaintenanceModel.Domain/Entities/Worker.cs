using MaintenanceModel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Domain.Entities
{
    public class Worker: Entity
    {
        #region Properties
        /// <summary>
        /// Numero de identificacion
        /// </summary>
        public string CI {  get; set; }

        /// <summary>
        /// Nobre del trabajador
        /// </summary>
        public string Name {  get; set; }
        #endregion

        /// <summary>
        /// Mantenimiento que realiza el trabajador
        /// </summary>
        public Maintenance Maintenance { get; set; }
            
        /// <summary>
        /// Identificador del mantenimiento que realiza el trabajador
        /// </summary>
        public Guid MaintenanceId { get; set; }

        /// <summary>
        /// Cosntructor requerido por entityframework
        /// </summary>
        protected Worker() { }

        /// <summary>
        /// Constructor de travajadores
        /// </summary>
        /// <param name="cI"></param>
        /// <param name="name"></param>
        public Worker(Guid id,string cI, string name) : base(id) 
        {
            CI = cI;
            Name = name;
        }
    }
}
