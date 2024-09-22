﻿using MaintenanceModel.DataAccess.Context;

namespace MaintenanceModel.DataAccess.Repositories.Common
{
    /// <summary>
    /// Clase base para repositorios.
    /// </summary>
    public abstract class RepositoryBase
    {
        /// <summary>
        /// Contexto del soporte de datos.
        /// </summary>
        protected ApplicationContext _context;

        protected RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
    }
}