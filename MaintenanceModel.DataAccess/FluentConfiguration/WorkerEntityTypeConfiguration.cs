using MaintenanceModel.DataAccess.FluentConfiguration.Common;
using MaintenanceModel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.DataAccess.FluentConfiguration
{
    public class WorkerEntityTypeConfiguration : EntityTypeConfigurationBase<Worker>
    {
        public override void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Workers");
            builder.HasOne(x => x.Maintenance).WithMany(x=>x.Workers).HasForeignKey(x => x.MaintenanceId);  
            base.Configure(builder);
        }
    }
}
