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
    public class MaintenanceEntityTypeConfiguration : EntityTypeConfigurationBase<Maintenance>
    {
        public override void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.ToTable("Maintenances");
            builder.HasOne(x => x.Unit).WithMany(x=>x.Maintenances).HasForeignKey(x => x.UnitId);
            base.Configure(builder);
        }
    }
}
