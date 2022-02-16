using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.Intefaces.FailedRepository;
using App.CooperShip.Infra.Interfaces;
using App.CooperShip.Infra.Orm;
using App.CooperShip.Infra.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CooperShip.Infra.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPessoaFailedRepository _pessoaFailed;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaService(IMapper mapper, IPessoaFailedRepository pessoaFailed, IPessoaRepository pessoaRepository, ApplicationDbContext context)
        {
            _mapper = mapper;
            _pessoaFailed = pessoaFailed;
            _pessoaRepository = pessoaRepository;
            _context = context;
        }
        public async Task<PessoaDTO> Create(PessoaDTO pessoaDTO)
        {
            var pessoaRequest = _mapper.Map<Pessoa>(pessoaDTO);
            await _pessoaFailed.Create(pessoaRequest);

            return pessoaDTO;
        }

        public async Task ExcluirPessoaDoVoo(Guid id)
        {
            await _pessoaRepository.Remove(id);
        }
    }
}
