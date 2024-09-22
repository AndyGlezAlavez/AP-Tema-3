﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.DataAccess.Test.Utilities
{
    /// <summary>
    /// Proveedor de cadena de conexión.
    /// </summary>
    public static class ConnectionStringProvider
    {
        /// <summary>
        /// Obtiene la cadena de conexion a utilizar en 
        /// las pruebas unitarias.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString() => "Data Source=Data.sqlite";
    }
}