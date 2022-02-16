using App.CooperShip.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CooperShip.Infra.Mappings
{
    public class VooMapping : IEntityTypeConfiguration<Voo>
    {
        public void Configure(EntityTypeBuilder<Voo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo).IsRequired().HasMaxLength(40).HasColumnType("varchar");
            builder.Property(x => x.Nota).IsRequired().HasMaxLength(100).HasColumnType("varchar");

            builder.HasMany(x => x.Pessoas).WithOne(x => x.Voo).HasForeignKey(fk => fk.VooId);
        }
    }
}
