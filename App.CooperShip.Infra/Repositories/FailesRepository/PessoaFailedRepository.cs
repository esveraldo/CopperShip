using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.Intefaces.FailedRepository;
using App.CooperShip.Infra.Orm;
using App.CooperShip.Infra.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.CooperShip.Infra.Repositories.FailedRepository;
public class PessoaFailedRepository : BaseRepository<Pessoa>, IPessoaFailedRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PessoaFailedRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AdicionarAoVoo(PessoaDTO pessoaDTO)
    {
        await _context.Set<Pessoa>().AddAsync(_mapper.Map<Pessoa>(pessoaDTO));
        await _context.SaveChangesAsync();
    }
}
