using App.CooperShip.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.CooperShip.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Remove(Guid id);
        Task<T> Get(Guid? id);
        Task<List<T>> Get();
    }
}
