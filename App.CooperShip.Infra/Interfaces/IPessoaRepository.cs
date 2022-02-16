using App.CooperShip.Domain.Entities;

namespace App.CooperShip.Infra.Interfaces
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>, IUnitOfWork
    {
        Task AdicionarAoVoo(PessoaDTO pessoaDTO);
        public Task ExcluirPessoaDoVoo(Guid id);
    }
}
