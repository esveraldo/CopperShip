using App.CooperShip.Infra;
using App.CooperShip.Infra.Intefaces.FailedRepository;
using App.CooperShip.Infra.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.CooperShip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PessoaFailedController : ControllerBase
    {
        private readonly IPessoaFailedRepository _pessoaRepository;
        private readonly IVooFailedRepository _vooFailedRepository;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaFailedController(IPessoaFailedRepository pessoaRepository, IVooFailedRepository vooFailedRepository, IMapper mapper, IPessoaService pessoaService)
        {
            _pessoaRepository = pessoaRepository;
            _vooFailedRepository = vooFailedRepository;
            _mapper = mapper;
            _pessoaService = pessoaService;
        }

        [HttpPost("adicionar-passageiro")]
        [ProducesResponseType(typeof(PessoaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarPassageiro([FromBody] PessoaRequest pessoa)
        {
            if(!ModelState.IsValid) return BadRequest("O modelo está inválido.");

            try
            {
                PessoaDTO pessoaDTO = new PessoaDTO();

                //pessoaDTO.Id = Guid.NewGuid();
                pessoaDTO.Nome = pessoa.Nome;  
                pessoaDTO.VooId = pessoa.VooId;

                var _pessoa = await _pessoaService.Create(pessoaDTO);

                await _pessoaRepository.AdicionarAoVoo(pessoaDTO);
                await _vooFailedRepository.AdicionarPassageiro(_pessoa.VooId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
