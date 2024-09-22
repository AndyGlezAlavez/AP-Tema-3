using MaintenanceModel.DataAccess.FluentConfiguration;
using MaintenanceModel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        #region Tables
        public DbSet<Unit> Units { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Worker> Workers { get; set; }
        #endregion

        /// <summary>
        /// Requerido por entityFramework para la migracione
        /// </summary>
        public ApplicationContext() { }

        /// <summary>
        /// Inicializa un objeto de tipo applicationContext
        /// </summary>
        /// <param name="connectionString"></param>
        public ApplicationContext(string connectionString) : base(GetOptions(connectionString))
        {
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MaintenanceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnitEntityTypeConfiguration());
        }

        #region Helpers
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }
        #endregion
    }
}
