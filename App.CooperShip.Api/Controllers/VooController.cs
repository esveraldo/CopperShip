using App.CooperShip.Infra.Configurations.Settings;
using App.CooperShip.Infra.DTOs;
using App.CooperShip.Infra.Interfaces;
using App.CooperShip.Infra.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace App.CooperShip.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VooController : Controller
    {
        private readonly IVooService _vooService;
        private readonly IPessoaService _pessoaService;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IVooRepository _vooRepository;

        private readonly VooSettings _vooSettings;

        public VooController(IVooService vooService, IPessoaService pessoaService, IPessoaRepository pessoaRepository, IVooRepository vooRepository, IOptions<VooSettings> vooSettings)
        {
            _vooService = vooService;
            _pessoaService = pessoaService;
            _pessoaRepository = pessoaRepository;
            _vooRepository = vooRepository;
            _vooSettings = vooSettings.Value;
        }

        [HttpPost("resetar-voo")]
        [ProducesResponseType(typeof(VooDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ResetarVoo(Guid id)
        {
            id = Guid.Parse("380579CA-8DBE-45AF-9221-1D1C066FAF48");
            var voo = _vooService.SelecionarPorId(id);
            if (voo == null)
            {
                var vooDTO = new VooDTO
                {
                    Id = id,
                    Capacidade = 4,
                    Disponibilidade = 4,
                    Codigo = "101 - Rio/Miami.",
                    Nota = "Saida às 10:34 - Horário de Brasilia."
                };

                await _vooService.CriarVoo(vooDTO);
                return CreatedAtAction(nameof(ResetarVoo), vooDTO);
            }

            var vooDTOReset = new VooDTO
            {
                Id = id,
                Capacidade = 4,
                Disponibilidade = 4,
                Codigo = "101 - Rio/Miami.",
                Nota = "Saida às 10:34 - Horário de Brasilia."
            };

            await _pessoaRepository.ExcluirPessoaDoVoo(id);
            await _vooService.UpdateVoo(vooDTOReset);
            await _pessoaRepository.Commit();
            return Ok(vooDTOReset);
        }

        [HttpGet("listar-voos")]
        public async Task<IActionResult> ListarVoos()
        {
            var result = await _vooRepository.SelecionarTodos();
            return Ok(result);
        }

        [HttpPost("criar-voo")]
        [ProducesResponseType(typeof(VooDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarNovoVoo(VooDTO vooDTO)
        {
            if(!ModelState.IsValid) return BadRequest(vooDTO);  

            vooDTO.Id = _vooSettings.Id;

            try
            {
                await _vooService.CriarVoo(vooDTO);
                return CreatedAtAction(nameof(CriarNovoVoo), vooDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("criar-voo-settings")]
        [ProducesResponseType(typeof(VooDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarNovoVooSettings(VooDTO vooDTO)
        {
            if (!ModelState.IsValid) return BadRequest(vooDTO);

            vooDTO.Id = _vooSettings.Id;
            vooDTO.Codigo = _vooSettings.Codigo;
            vooDTO.Nota = _vooSettings.Nota;
            vooDTO.Capacidade = _vooSettings.Capacidade;
            vooDTO.Disponibilidade = _vooSettings.Disponibilidade;

            try
            {
                await _vooService.CriarVoo(vooDTO);
                return CreatedAtAction(nameof(CriarNovoVoo), vooDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
