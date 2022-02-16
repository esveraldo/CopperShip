using App.CooperShip.Infra.Interfaces;

namespace App.CooperShip.Infra.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<PessoaDTO> Create(PessoaDTO pessoa);
        Task ExcluirPessoaDoVoo(Guid id);
    }
}
