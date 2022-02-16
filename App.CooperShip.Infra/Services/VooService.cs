using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.DTOs;
using App.CooperShip.Infra.Interfaces;
using App.CooperShip.Infra.Orm;
using App.CooperShip.Infra.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.CooperShip.Infra.Services
{
    public class VooService : IVooService
    {
        private readonly ApplicationDbContext _context;
        private readonly IVooRepository _vooRepository;
        private readonly IMapper _mapper;

        public VooService(ApplicationDbContext context, IMapper mapper, IVooRepository vooRepository)
        {
            _context = context;
            _mapper = mapper;
            _vooRepository = vooRepository;
        }

        public async Task CriarVoo(VooDTO vooDTO)
        {
            var voo = _mapper.Map<Voo>(vooDTO);
            await _vooRepository.Create(voo);
        }

        public async Task<Voo> SelecionarPorId(Guid id)
        {
            return await _vooRepository.Get(id);
        }

        public async Task UpdateVoo(VooDTO vooDTO)
        {
            var voo = _mapper.Map<Voo>(vooDTO);
            await _vooRepository.Update(voo);
        }
    }
}
