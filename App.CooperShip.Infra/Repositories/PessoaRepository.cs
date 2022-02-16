using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.Interfaces;
using App.CooperShip.Infra.Orm;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CooperShip.Infra.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PessoaRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AdicionarAoVoo(PessoaDTO pessoaDTO)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            await _context.Set<Pessoa>().AddRangeAsync(pessoa);
        }

        public async Task ExcluirPessoaDoVoo(Guid id)
        {
            var pessoas = await _context.Set<Pessoa>().AsNoTracking().Where(p => p.VooId == id).ToListAsync();
            _context.Set<Pessoa>().RemoveRange(pessoas);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Roolback()
        {
            return Task.CompletedTask;
        }
    }
}
