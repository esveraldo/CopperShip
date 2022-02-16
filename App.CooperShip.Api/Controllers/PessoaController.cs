using App.CooperShip.Infra;
using App.CooperShip.Infra.Interfaces;
using App.CooperShip.Infra.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.CooperShip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IVooRepository _vooRepository;
        private readonly IMapper _mapper;

        public PessoaController(IMapper mapper, IPessoaRepository pessoaRepository, IVooRepository vooRepository)
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
            _vooRepository = vooRepository;
        }

        [HttpPost("adicionar-passageiro")]
        [ProducesResponseType(typeof(PessoaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarPassageiro([FromBody] PessoaRequest pessoa)
        {
            if (!ModelState.IsValid) return BadRequest("O modelo está inválido.");

            PessoaDTO pessoaDTO = new PessoaDTO();

            pessoaDTO.Nome = pessoa.Nome;
            pessoaDTO.VooId = pessoa.VooId;

            try
            {
                await _pessoaRepository.AdicionarAoVoo(pessoaDTO);
                await _vooRepository.DecrementarVaga(pessoa.VooId);

                await _vooRepository.Commit();
                var confirmado = await _pessoaRepository.Commit();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
