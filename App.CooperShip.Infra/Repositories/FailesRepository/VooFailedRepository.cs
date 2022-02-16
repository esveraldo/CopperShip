using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.Intefaces.FailedRepository;
using App.CooperShip.Infra.Orm;
using Microsoft.EntityFrameworkCore;

namespace App.CooperShip.Infra.Repositories.FailedRepository;

public class VooFailedRepository : BaseRepository<Voo>, IVooFailedRepository
{
    private readonly ApplicationDbContext _context;
    protected readonly DbSet<Voo> _dbSet;
    public VooFailedRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task AdicionarPassageiro(Guid? vooId)
    {
        if (vooId == null)
            throw new Exception("Id do voo não pode ser nulo.");

        var voo = await _context.Voos.AsNoTracking().FirstOrDefaultAsync(v => v.Id == vooId); 

        if (voo == null)
            throw new Exception("Voo não encontrado.");

        if (!voo.TemDisponibilidade())
            throw new Exception("Não há mais vagas disponiveis para esse Voo.");

        voo.DecrementaDisponibilidade();

        _context.Set<Voo>().Update(voo);
        await _context.SaveChangesAsync();
    }
}
