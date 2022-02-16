using App.CooperShip.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.CooperShip.Infra.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150).HasColumnType("varchar");
            builder.Property(pk => pk.VooId).IsRequired();

            // Redundância
            builder.HasOne(x => x.Voo).WithMany(x => x.Pessoas).HasForeignKey(fk => fk.VooId);    
            
        }
    }
}
