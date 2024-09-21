using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Domain.Entities
{
    public class Worker
    {
        /// <summary>
        /// Numero de identificacion
        /// </summary>
        string CI {  get; set; }

        /// <summary>
        /// Nobre del trabajador
        /// </summary>
        string Name {  get; set; }

        /// <summary>
        /// Constructor de travajadores
        /// </summary>
        /// <param name="cI"></param>
        /// <param name="name"></param>
        public Worker(string cI, string name) 
        {
            CI = cI;
            Name = name;
        }
    }
}
