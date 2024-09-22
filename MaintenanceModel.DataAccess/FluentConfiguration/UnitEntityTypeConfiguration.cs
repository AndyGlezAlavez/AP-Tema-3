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
    public class UnitEntityTypeConfiguration : EntityTypeConfigurationBase<Unit>
    {
        public override void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");
            base.Configure(builder);
        }
    }
}
