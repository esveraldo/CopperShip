using App.CooperShip.Domain.Entities;
using App.CooperShip.Infra.DTOs;
using App.CooperShip.Infra.Orm;
using System.Linq.Expressions;

namespace App.CooperShip.Infra.Interfaces
{
    public interface IVooRepository : IBaseRepository<Voo>, IUnitOfWork
    {
        public Task DecrementarVaga(Guid? vooId);
        public Task<IEnumerable<Voo>> SelecionarTodos(Expression<Func<Voo, bool>> quando = null);

    }
}
