using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace App.CooperShip.Infra.Orm
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
        {
        }

        public DbSet<Pessoa>? Pessoas { get; set; }
        public DbSet<Voo>? Voos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CONFIGURA TODAS AS STRINGS PARA VARCHAR COM TAMANHO DE 100 CARACTERES
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                //CONFIGURA TODAS AS STRINGS PARA VARCHAR COM TAMANHO DE 100 CARACTERES
                property.SetColumnType("varchar(100)");
            }

            foreach (var relationalship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                //NÃO REMOVER A EXCLUSÃO EM CASCATA(NÃO TEM AÇÃO DEFINIDA)
                relationalship.DeleteBehavior = DeleteBehavior.ClientNoAction;
                //REMOVER A EXCLUSÃO EM CASCATA
                //relationalship.DeleteBehavior = DeleteBehavior.Cascade;
            }
            //BUSCA TODOS OS MAPPINGS DE UMA SÓ VEZ
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new PessoaMapping());
            modelBuilder.ApplyConfiguration(new VooMapping());  

            base.OnModelCreating(modelBuilder);
        }
    }
}
