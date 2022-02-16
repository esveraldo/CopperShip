using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.DTOs;
using App.CooperShip.Infra.Interfaces;
using App.CooperShip.Infra.Orm;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.CooperShip.Infra.Repositories
{
    public class VooRepository : BaseRepository<Voo>, IVooRepository, IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VooRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task DecrementarVaga(Guid? vooId)
        {
            if (vooId == null)
                throw new Exception("Id do voo não pode ser nulo.");

            var voo = await _context.Voos.FindAsync(vooId);

            if (voo == null)
                throw new Exception("Voo não encontrado.");

            if (!voo.TemDisponibilidade())
                throw new Exception("Não há mais vagas disponiveis para esse Voo.");

            voo.DecrementaDisponibilidade();

            _context.Set<Voo>().Update(voo);
        }

        public async Task<IEnumerable<Voo>> SelecionarTodos(Expression<Func<Voo, bool>> quando = null)
        {
            if (quando == null)
            {
                return await _context.Set<Voo>().Include(p => p.Pessoas).AsNoTracking().ToListAsync();
            }
            return await _context.Set<Voo>().Include(p => p.Pessoas).AsNoTracking().Where(quando).ToListAsync();
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
